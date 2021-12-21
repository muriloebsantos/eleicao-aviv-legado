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
using WMPLib;

namespace Aviv.Eleicao.Terminal
{
    public partial class VotacaoFrm : Form
    {
        int numeroAtual = 0;
        int int_id_eleicao = 0;
        int int_id_eleicao_cargo = 0;
        string tipo_voto = "";
        bool fechar = false;

        public VotacaoFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            Confirma();
        }

        private void Confirma()
        {
            if (btnConfirma.Enabled.Equals(true))
            {
                try
                {
                    MsSqlConnection objAcessoDados = new MsSqlConnection();
                    objAcessoDados.ExecutaProcedure("sp_gerencia_voto",
                                                     new SqlParameter("str_acao", "INS"),
                                                     new SqlParameter("str_tipo_voto", tipo_voto),
                                                     new SqlParameter("int_id_eleicao", int_id_eleicao),
                                                     new SqlParameter("int_id_eleicao_cargo", int_id_eleicao_cargo),
                                                     new SqlParameter("int_numero_candidato", GetNumeroCandidato()));

                    numeroAtual = 0;
                    tipo_voto = "";
                    btnConfirma.Enabled = false;
                    LimparCampos();

                    WindowsMediaPlayer wplayer = new WindowsMediaPlayer();
                    wplayer.URL = "prim_prim_urnaeletronica.mp3";
                    wplayer.controls.play();

                    FimFrm frm = new FimFrm();
                    frm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EntraNumero(int numero)
        {
            if (numeroAtual < 4)
            {
                numeroAtual++;
                switch (numeroAtual)
                {
                    case 1:
                        lbl1.Text = numero.ToString();
                        break;
                    case 2:
                        lbl2.Text = numero.ToString();
                        break;
                    case 3:
                        lbl3.Text = numero.ToString();
                        break;
                    case 4:
                        lbl4.Text = numero.ToString();
                        PesquisaCandidato();
                        btnConfirma.Enabled = true;
                        btnConfirma.Focus();
                        break;
                }
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            EntraNumero(1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            EntraNumero(2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            EntraNumero(3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            EntraNumero(4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            EntraNumero(5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            EntraNumero(6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            EntraNumero(7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            EntraNumero(8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            EntraNumero(9);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            EntraNumero(0);
        }

        private void btnCorrige_Click(object sender, EventArgs e)
        {
            btnConfirma.Enabled = false;
            tipo_voto = "";
            numeroAtual = 0;
            LimparCampos();
        }

        private void btnBranco_Click(object sender, EventArgs e)
        {
            tipo_voto = "B";
            LimparCampos();
            lblNome.Text = "VOTO EM BRANCO";
            btnConfirma.Enabled = true;
        }


        private void LimparCampos()
        {
            lbl1.Text = string.Empty;
            lbl2.Text = string.Empty;
            lbl3.Text = string.Empty;
            lbl4.Text = string.Empty;
            lblNome.Text = string.Empty;
            lblApelido.Text = string.Empty;
            imgCandidato.Image = null;
        }

        private string GetNumeroCandidato()
        {
            return lbl1.Text + lbl2.Text + lbl3.Text + lbl4.Text;
        }

        private void PesquisaCandidato()
        {
            MsSqlConnection objAcessoDados = new MsSqlConnection();
            using (SqlDataReader sdr = objAcessoDados.RetornaSqlDataReader("sp_gerencia_voto",
                                                                            new SqlParameter("str_acao", "PES"),
                                                                            new SqlParameter("int_numero_candidato", GetNumeroCandidato()),
                                                                            new SqlParameter("int_id_eleicao_cargo", int_id_eleicao_cargo)))
            {
                if (sdr.HasRows)
                {
                    sdr.Read();
                    tipo_voto = "V";
                    lblNome.Text = sdr["str_nome_candidato"].ToString().ToUpper();
                    lblApelido.Text = sdr["str_apelido_candidato"].ToString().ToUpper();

                    if (sdr["img_foto_candidato"] != DBNull.Value)
                    {
                        CarregarImagem(sdr["img_foto_candidato"]);
                    }
                    else
                    {
                        imgCandidato.Image = null;
                    }
                }
                else
                {
                    tipo_voto = "N";
                    lblNome.Text = "NÃO ENCONTRADO - VOTO NULO";
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
                imgCandidato.Image = Image.FromFile(strNomeArquivo);
                imagem = null;
            }
        }

        private void VerificarEleicaoAtiva()
        {
            if (fechar)
            {
                panel1.Visible = false;
                fechar = false;
            }
            else
            {
                MsSqlConnection objAcessoDados = new MsSqlConnection();
                using (SqlDataReader sdr = objAcessoDados.RetornaSqlDataReader("sp_gerencia_voto",
                                                                                new SqlParameter("str_acao", "INF")))
                {
                    if (sdr.HasRows)
                    {
                        sdr.Read();
                        int_id_eleicao = Convert.ToInt32(sdr["int_id_eleicao"]);
                        int_id_eleicao_cargo = Convert.ToInt32(sdr["int_id_eleicao_cargo"]);
                        lblEleicao.Text = sdr["str_nome_eleicao"].ToString().ToUpper(); ;
                        lblCargo.Text = sdr["str_nome_cargo"].ToString().ToUpper();
                        panel1.Visible = true;
                    }
                    else
                    {
                        fechar = true;
                        MessageBox.Show("Nenhuma votação aberta. Clique em OK para encerrar", "INFORMAÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void VotacaoFrm_Activated(object sender, EventArgs e)
        {
            VerificarEleicaoAtiva();
        }

        private void VotacaoFrm_Load(object sender, EventArgs e)
        {

        }

        private void VotacaoFrm_KeyDown(object sender, KeyEventArgs e)
        {
            //0 - 9
            if (e.KeyValue >= 48 && e.KeyValue <= 57)
            {
                char numero = (char)e.KeyValue;
                EntraNumero(Convert.ToInt32(numero.ToString()));
            }
            //0-9 teclado numerico
            else if (e.KeyValue >= 96 && e.KeyValue <= 105)
            {
                int numero = (char)e.KeyValue;
                numero = numero - 96;
                EntraNumero(Convert.ToInt32(numero));
            }
             //enter 
            else if (e.KeyValue == 13)
            {
                Confirma();
            }
            //f1
            else if (e.KeyValue == 112)
            {
                FecharFrm frm = new FecharFrm();
                frm.ShowDialog();
            }
            //f5
            else if (e.KeyValue == 116)
            {
                VerificarEleicaoAtiva();
            }
        }

        private void VotacaoFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    e.Cancel = true;
                    FecharFrm frm = new FecharFrm();
                    frm.ShowDialog();
                    break;
            }
        }
    }
}
