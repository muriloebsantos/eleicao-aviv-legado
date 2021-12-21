using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aviv.Eleicao.Admin
{
    public partial class CandidatoFrm : Form
    {
        private long tamanhoArquivoImagem = 0;
        private byte[] vetorImagens = null;

        public CandidatoFrm()
        {
            InitializeComponent();
        }

        private void CandidatoFrm_Activated(object sender, EventArgs e)
        {
            txt_nome.Focus();
        }

        private void btnAbrirFoto_Click(object sender, EventArgs e)
        {
            try
            {
                this.openFileDialog1.ShowDialog(this);
                string strFn = this.openFileDialog1.FileName;

                if (string.IsNullOrEmpty(strFn))
                    return;

                this.img_candidato.Image = Image.FromFile(strFn);
                FileInfo arqImagem = new FileInfo(strFn);
                tamanhoArquivoImagem = arqImagem.Length;
                FileStream fs = new FileStream(strFn, FileMode.Open, FileAccess.Read, FileShare.Read);
                vetorImagens = new byte[Convert.ToInt32(this.tamanhoArquivoImagem)];
                int iBytesRead = fs.Read(vetorImagens, 0, Convert.ToInt32(this.tamanhoArquivoImagem));
                fs.Close();
            }
            catch
            {
                vetorImagens = null;
            }
        }

        public void CarregarDadosCandidato(int int_id_candidato)
        {
            MsSqlConnection objAcessoDados = new MsSqlConnection();
            using (SqlDataReader sdr = objAcessoDados.RetornaSqlDataReader("sp_gerencia_candidato",
                                                                          new SqlParameter("str_acao", "SEL"),
                                                                          new SqlParameter("int_id_candidato", int_id_candidato)))
            {
                if (sdr.HasRows)
                {
                    btnNovo.Enabled = true;
                    btnExcluir.Enabled = true;

                    sdr.Read();
                    txt_codigo.Text = sdr["int_id_candidato"].ToString();
                    txt_nome.Text = sdr["str_nome_candidato"].ToString();
                    txt_apelido.Text = sdr["str_apelido_candidato"].ToString();
                    txt_data_cadastro.Text = sdr["dte_data_cadastro"].ToString();

                    if (sdr["img_foto_candidato"] != DBNull.Value)
                    {
                        CarregarImagem(sdr["img_foto_candidato"]);
                    }
                    else
                    {
                        img_candidato.Image = null;
                        vetorImagens = null;
                    }
                }
            }
        }

        private void CarregarImagem(object imagem)
        {
            byte[] vetorImagem = (byte[])imagem;
            string strNomeArquivo = Convert.ToString(DateTime.Now.ToFileTime());
            using (FileStream fs = new FileStream(strNomeArquivo, FileMode.CreateNew, FileAccess.Write))
            {
                fs.Write(vetorImagem, 0, vetorImagem.Length);
                fs.Flush();
                fs.Close();
                img_candidato.Image = Image.FromFile(strNomeArquivo);
                vetorImagens = vetorImagem;
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_nome.Text.Equals(string.Empty))
                {
                    txt_nome.Focus();
                    MessageBox.Show("Entre com o nome", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MsSqlConnection objAcessoDados = new MsSqlConnection();
                    string acao = "", mensagem = "";
                    int int_id_candidato = 0;
                    if (txt_codigo.Text.Equals(string.Empty))
                    {
                        acao = "INS";
                        mensagem = "Inserido com sucesso";
                    }
                    else
                    {
                        acao = "UPD";
                        mensagem = "Atualizado com sucesso";
                        int_id_candidato = Convert.ToInt32(txt_codigo.Text);
                    }
                    using (SqlDataReader sdr = objAcessoDados.RetornaSqlDataReader("sp_gerencia_candidato",
                                                                                   new SqlParameter("str_acao", acao),
                                                                                   new SqlParameter("int_id_candidato", int_id_candidato),
                                                                                   new SqlParameter("str_nome_candidato", txt_nome.Text.Trim()),
                                                                                   new SqlParameter("str_apelido_candidato", txt_apelido.Text.Trim()),
                                                                                   new SqlParameter("img_foto_candidato", vetorImagens)))
                    {
                        if (sdr.HasRows)
                        {
                            sdr.Read();
                            CarregarDadosCandidato(Convert.ToInt32(sdr["int_id_candidato"]));
                            MessageBox.Show(mensagem, "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarImagem_Click(object sender, EventArgs e)
        {
            if (txt_codigo.Text.Equals(string.Empty))
            {
                vetorImagens = null;
                img_candidato.Image = null;
            }
            else
            {
                MsSqlConnection objAcessoDados = new MsSqlConnection();
                using (SqlDataReader sdr = objAcessoDados.RetornaSqlDataReader("sp_gerencia_candidato",
                                                                                     new SqlParameter("str_acao", "SEL"),
                                                                                     new SqlParameter("int_id_candidato", txt_codigo.Text)))
                {
                    if (sdr.HasRows)
                    {
                        sdr.Read();
                        if (sdr["img_foto_candidato"] != DBNull.Value)
                        {
                            CarregarImagem(sdr["img_foto_candidato"]);
                        }
                    }
                }
            }
        }

        private void btnRemoverImagem_Click(object sender, EventArgs e)
        {
            vetorImagens = null;
            img_candidato.Image = null;
        }

        private void NovoCandidato()
        {
            ClearTextBoxes(this);
            img_candidato.Image = null;
            vetorImagens = null;
            btnNovo.Enabled = false;
            btnExcluir.Enabled = false;
            txt_nome.Focus();
        }

        public void ClearTextBoxes(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                if (c.HasChildren)
                {
                    ClearTextBoxes(c);
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja excluir esse candidato?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                {
                    MsSqlConnection objAcessoDados = new MsSqlConnection();
                    objAcessoDados.ExecutaProcedure("sp_gerencia_candidato",
                                                     new SqlParameter("str_acao", "DEL"),
                                                     new SqlParameter("@int_id_candidato", txt_codigo.Text.Trim()));

                    MessageBox.Show("Candidato excluido com sucesso!", "SUCESSO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NovoCandidato();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível excluir o candidato pois há registros relacionados ao mesmo", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            NovoCandidato();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            CandidatoPesquisaFrm frm = new CandidatoPesquisaFrm(this);
            frm.ShowDialog();
        }
    }
}
