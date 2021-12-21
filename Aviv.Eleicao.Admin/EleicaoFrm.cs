using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aviv.Eleicao.Admin
{
    public partial class EleicaoFrm : Form
    {

        public EleicaoFrm()
        {
            InitializeComponent();
        }

        private void EleicaoFrm_Activated(object sender, EventArgs e)
        {
            txt_nome.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_nome.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Entre com o nome da eleição", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_nome.Focus();
                }
                else
                {
                    string acao, mensagem;
                    int int_id_eleicao = 0;
                    if (txt_codigo.Text.Equals(string.Empty))
                    {
                        acao = "INS";
                        mensagem = "Eleição inserida com sucesso!";
                    }
                    else
                    {
                        acao = "UPD";
                        mensagem = "Eleição atualizada com sucesso!";
                        int_id_eleicao = Convert.ToInt32(txt_codigo.Text);
                    }

                    MsSqlConnection objAcessoDados = new MsSqlConnection();
                    using (SqlDataReader sdr = objAcessoDados.RetornaSqlDataReader("sp_gerencia_eleicao",
                                                                                   new SqlParameter("str_acao", acao),
                                                                                   new SqlParameter("int_id_eleicao", int_id_eleicao),
                                                                                   new SqlParameter("str_nome", txt_nome.Text.Trim()),
                                                                                   new SqlParameter("int_numero_eleitores", txt_numero_eleitores.Text)))
                    {
                        if (sdr.HasRows)
                        {
                            sdr.Read();
                            CarregaDadosEleicao(Convert.ToInt32(sdr["int_id_eleicao"]));
                            MessageBox.Show(mensagem, "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Erro ao salvar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAbrirEleicao_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Deseja abrir a votação para essa eleição? Nenhum cargo ou candidato poderam ser adicionados", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                {
                    MsSqlConnection objAcessoDados = new MsSqlConnection();
                    using (SqlDataReader sdr = objAcessoDados.RetornaSqlDataReader("sp_gerencia_eleicao",
                                                                                   new SqlParameter("str_acao", "ABR"),
                                                                                   new SqlParameter("@int_id_eleicao", txt_codigo.Text.Trim()),
                                                                                   new SqlParameter("int_numero_eleitores", txt_numero_eleitores.Text)))
                    {
                        CarregaDadosEleicao(Convert.ToInt32(txt_codigo.Text));
                        MessageBox.Show("Eleição aberta com sucesso!", "SUCESSO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            EleicaoPesquisaFrm frm = new EleicaoPesquisaFrm(this);
            frm.ShowDialog();
        }

        public void CarregaDadosEleicao(int int_id_eleicao)
        {
            MsSqlConnection objAcessoDados = new MsSqlConnection();
            using (SqlDataReader sdr = objAcessoDados.RetornaSqlDataReader("sp_gerencia_eleicao",
                                                                           new SqlParameter("str_acao", "SEL"),
                                                                           new SqlParameter("int_id_eleicao", int_id_eleicao)))
            {
                if (sdr.HasRows)
                {
                    btnNovo.Enabled = true;
                    btnExcluir.Enabled = true;
                    tabEleicao.Visible = true;
                    btnRefresh.Enabled = true;
                    btnExportar.Enabled = true;

                    sdr.Read();
                    txt_codigo.Text = sdr["int_id_eleicao"].ToString();
                    txt_nome.Text = sdr["str_nome_eleicao"].ToString();
                    txt_data_cadastro.Text = sdr["dte_data_cadastro"].ToString();
                    txt_data_inicio.Text = sdr["dte_data_inicio"].ToString();
                    txt_data_fim.Text = sdr["dte_data_fim"].ToString();
                    txt_numero_eleitores.Text = sdr["int_numero_eleitores"].ToString();
                    txt_votos.Text = sdr["int_votos"].ToString();
                    txt_votos_validos.Text = sdr["int_votos_validos"].ToString();
                    txt_votos_brancos.Text = sdr["int_votos_brancos"].ToString();
                    txt_votos_nulos.Text = sdr["int_votos_nulos"].ToString();

                    if (txt_data_inicio.Text.Equals(string.Empty))
                    {
                        btnAbrirEleicao.Enabled = true;
                        btnFecharEleicao.Enabled = false;
                        btnIniciarVotacaoCargo.Enabled = false;
                        btnEncerrarVotacaoCargo.Enabled = false;
                        btnAdicionarCandidatos.Enabled = true;
                        btnExcluirCandSelecionados.Enabled = true;
                        txt_numero_eleitores.Enabled = true;

                    }
                    else if (txt_data_inicio.Text != string.Empty && txt_data_fim.Text.Equals(string.Empty))
                    {
                        btnFecharEleicao.Enabled = true;
                        btnAbrirEleicao.Enabled = false;
                        btnIniciarVotacaoCargo.Enabled = true;
                        btnEncerrarVotacaoCargo.Enabled = true;
                        btnAdicionarCandidatos.Enabled = false;
                        btnExcluirCandSelecionados.Enabled = false;
                        txt_numero_eleitores.Enabled = false;
                        MostraBotoesCargos(false);
                    }
                    else
                    {
                        btnAbrirEleicao.Enabled = false;
                        btnFecharEleicao.Enabled = false;
                        btnIniciarVotacaoCargo.Enabled = false;
                        btnEncerrarVotacaoCargo.Enabled = false;
                        btnAdicionarCandidatos.Enabled = false;
                        btnExcluirCandSelecionados.Enabled = false;
                        txt_numero_eleitores.Enabled = false;
                        MostraBotoesCargos(false);
                    }

                    CarregarCargosEleicao(int_id_eleicao);
                }
            }
        }

        private void MostraBotoesCargos(bool visible)
        {
            btnIniciarVotacaoCargo.Visible = visible;
            btnEncerrarVotacaoCargo.Visible = visible;
            btnEditarCargo.Visible = visible;
            btnExcluirCargo.Visible = visible;
        }

        private void CarregarCargosEleicao(int int_id_eleicao)
        {
            MsSqlConnection objAcessoDados = new MsSqlConnection();
            gdvCargosEleicao.DataSource = objAcessoDados.RetornaDataTable("sp_gerencia_eleicao_cargo",
                                                                          new SqlParameter("str_acao", "SEL"),
                                                                          new SqlParameter("int_id_eleicao", int_id_eleicao));

            cbCargos.DisplayMember = "str_nome_cargo";
            cbCargos.ValueMember = "int_id_cargo_eleicao";
            cbCargos.DataSource = objAcessoDados.RetornaDataTable("sp_gerencia_eleicao_cargo",
                                                                   new SqlParameter("str_acao", "SEL"),
                                                                   new SqlParameter("int_id_eleicao", int_id_eleicao));


            if (gdvCargosEleicao.Rows.Count.Equals(0))
            {
                MostraBotoesCargos(false);
            }
            else
            {
                MostraBotoesCargos(true);
            }
        }

        public void CarregarCandidatosCargo()
        {
            if (cbCargos.Items.Count > 0)
            {
                MsSqlConnection objAcessoDados = new MsSqlConnection();
                DataRowView row = (DataRowView)cbCargos.SelectedValue;
                int int_id_eleicao_cargo = Convert.ToInt32(row["int_id_eleicao_cargo"]);
                gdvCandidatos.DataSource = objAcessoDados.RetornaDataTable("sp_gerencia_eleicao_cargo_candidato",
                                                                           new SqlParameter("str_acao", "SEL"),
                                                                           new SqlParameter("int_id_eleicao_cargo", int_id_eleicao_cargo));
            }
        }

        private void btnFecharEleicao_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja fechar a votação para essa eleição? Nenhuma estação da rede poderá votar nessa eleição.", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                {
                    MsSqlConnection objAcessoDados = new MsSqlConnection();
                    using (SqlDataReader sdr = objAcessoDados.RetornaSqlDataReader("sp_gerencia_eleicao",
                                                                                   new SqlParameter("str_acao", "FEC"),
                                                                                   new SqlParameter("@int_id_eleicao", txt_codigo.Text.Trim())))
                    {
                        CarregaDadosEleicao(Convert.ToInt32(txt_codigo.Text));
                        MessageBox.Show("Eleição fechada com sucesso!", "SUCESSO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NovaEleicao()
        {
            ClearTextBoxes(this);
            btnNovo.Enabled = false;
            btnExcluir.Enabled = false;
            btnAbrirEleicao.Enabled = false;
            btnFecharEleicao.Enabled = false;
            btnRefresh.Enabled = false;
            btnExportar.Enabled = false;
            tabEleicao.Visible = false;
            txt_nome.Focus();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            NovaEleicao();
        }

        public void ClearTextBoxes(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                if (c is MaskedTextBox)
                {
                    ((MaskedTextBox)c).Clear();
                }
                if (c.HasChildren)
                {
                    ClearTextBoxes(c);
                }
            }
        }

        private void btnInserirCargo_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_nome_cargo.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Entre com o nome do cargo", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_nome_cargo.Focus();
                }
                else if (txt_vagas_cargo.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Entre com o número de vagas para o cargo", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_vagas_cargo.Focus();
                }
                else
                {
                    MsSqlConnection objAcessoDados = new MsSqlConnection();
                    string acao = "", mensagem = "";
                    int int_id_eleicao_cargo = 0;

                    if (btnInserirAtualizarCargo.Text.Equals("Inserir"))
                    {
                        acao = "INS";
                        mensagem = "Inserido com sucesso";
                    }
                    else if (btnInserirAtualizarCargo.Text.Equals("Atualizar"))
                    {
                        acao = "UPD";
                        mensagem = "Atualizado com sucesso";
                        int_id_eleicao_cargo = Convert.ToInt32(gdvCargosEleicao.CurrentRow.Cells[0].Value);
                    }

                    objAcessoDados.ExecutaProcedure("sp_gerencia_eleicao_cargo",
                                                    new SqlParameter("str_acao", acao),
                                                    new SqlParameter("int_id_eleicao_cargo", int_id_eleicao_cargo),
                                                    new SqlParameter("int_id_eleicao", txt_codigo.Text),
                                                    new SqlParameter("str_nome_cargo", txt_nome_cargo.Text),
                                                    new SqlParameter("int_numero_vagas", txt_vagas_cargo.Text));
                    txt_nome_cargo.Clear();
                    txt_vagas_cargo.Clear();
                    txt_nome_cargo.Focus();

                    if (acao.Equals("UPD"))
                    {
                        btnInserirAtualizarCargo.Text = "Inserir";
                        btnCancelarEdtCargo.Visible = false;
                        gdvCargosEleicao.Enabled = true;
                    }

                    CarregarCargosEleicao(Convert.ToInt32(txt_codigo.Text));
                    MessageBox.Show(mensagem, "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja excluir essa eleição?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                MsSqlConnection objAcessoDados = new MsSqlConnection();
                objAcessoDados.ExecutaProcedure("sp_gerencia_eleicao",
                                                 new SqlParameter("str_acao", "DEL"),
                                                 new SqlParameter("@int_id_eleicao", txt_codigo.Text.Trim()));

                MessageBox.Show("Eleição excluida com sucesso!", "SUCESSO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NovaEleicao();
            }
        }

        private void btnIniciarVotacaoCargo_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja abrir a votação para esse cargo?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                {
                    MsSqlConnection objAcessoDados = new MsSqlConnection();
                    objAcessoDados.ExecutaProcedure("sp_gerencia_eleicao_cargo",
                                                     new SqlParameter("str_acao", "INI"),
                                                     new SqlParameter("@int_id_eleicao", txt_codigo.Text.Trim()),
                                                     new SqlParameter("@int_id_eleicao_cargo", gdvCargosEleicao.CurrentRow.Cells[0].Value));

                    MessageBox.Show("Votação para o cargo aberta com sucesso!", "SUCESSO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarCargosEleicao(Convert.ToInt32(txt_codigo.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEncerrarVotacaoCargo_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja fechar a votação para esse cargo?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                {
                    MsSqlConnection objAcessoDados = new MsSqlConnection();
                    objAcessoDados.ExecutaProcedure("sp_gerencia_eleicao_cargo",
                                                     new SqlParameter("str_acao", "FEC"),
                                                     new SqlParameter("@int_id_eleicao", txt_codigo.Text.Trim()),
                                                     new SqlParameter("@int_id_eleicao_cargo", gdvCargosEleicao.CurrentRow.Cells[0].Value));

                    MessageBox.Show("Votação para o cargo encerrada com sucesso!", "SUCESSO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarCargosEleicao(Convert.ToInt32(txt_codigo.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditarCargo_Click(object sender, EventArgs e)
        {
            txt_nome_cargo.Text = gdvCargosEleicao.CurrentRow.Cells[1].Value.ToString();
            txt_vagas_cargo.Text = gdvCargosEleicao.CurrentRow.Cells[2].Value.ToString();
            txt_nome_cargo.Focus();
            btnInserirAtualizarCargo.Text = "Atualizar";
            btnCancelarEdtCargo.Visible = true;
            gdvCargosEleicao.Enabled = false;
        }

        private void btnExcluirCargo_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja excluir esse cargo?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                {
                    MsSqlConnection objAcessoDados = new MsSqlConnection();
                    objAcessoDados.ExecutaProcedure("sp_gerencia_eleicao_cargo",
                                                     new SqlParameter("str_acao", "DEL"),
                                                     new SqlParameter("@int_id_eleicao", txt_codigo.Text.Trim()),
                                                     new SqlParameter("@int_id_eleicao_cargo", gdvCargosEleicao.CurrentRow.Cells[0].Value));

                    MessageBox.Show("Cargo excluido com sucesso!", "SUCESSO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarCargosEleicao(Convert.ToInt32(txt_codigo.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarEdtCargo_Click(object sender, EventArgs e)
        {
            btnInserirAtualizarCargo.Text = "Inserir";
            txt_nome_cargo.Clear();
            txt_vagas_cargo.Clear();
            txt_nome_cargo.Focus();
            btnCancelarEdtCargo.Visible = false;
            gdvCargosEleicao.Enabled = true;
        }

        private void btnAdicionarCandidatos_Click(object sender, EventArgs e)
        {
            if (cbCargos.Items.Count > 0)
            {
                DataRowView row = (DataRowView)cbCargos.SelectedValue;
                int int_id_eleicao_cargo = Convert.ToInt32(row["int_id_eleicao_cargo"]);
                CandidatoPesquisaInserirFrm frm = new CandidatoPesquisaInserirFrm(this, int_id_eleicao_cargo);
                frm.ShowDialog();
            }
        }

        private void cbCargos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarCandidatosCargo();
        }

        private void gdvCandidatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                bool isChecked = (Boolean)gdvCandidatos[0, e.RowIndex].FormattedValue;
                if (isChecked)
                    gdvCandidatos[0, e.RowIndex].Value = false;
                else
                    gdvCandidatos[0, e.RowIndex].Value = true;
            }
        }

        private void btnExcluirCandSelecionados_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja excluir os candidatos selecionados?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                MsSqlConnection objAcessoDados = new MsSqlConnection();
                int removidos = 0;
                foreach (DataGridViewRow row in gdvCandidatos.Rows)
                {
                    bool isChecked = (Boolean)row.Cells[0].FormattedValue;
                    if (isChecked)
                    {
                        using (SqlDataReader sdr = objAcessoDados.RetornaSqlDataReader("sp_gerencia_eleicao_cargo_candidato",
                                                                                       new SqlParameter("str_acao", "DEL"),
                                                                                       new SqlParameter("int_id_eleicao_cargo_candidato", row.Cells[1].Value)))
                        {
                            if (sdr.RecordsAffected > 0)
                            {
                                removidos++;
                            }
                        }
                    }
                }

                if (removidos.Equals(0))
                {
                    MessageBox.Show("Nenhum candidato excluido", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    CarregarCandidatosCargo();
                    MessageBox.Show(removidos + " candidatos removidos", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CarregaDadosEleicao(Convert.ToInt32(txt_codigo.Text));
        }

        private void btnEleger_Click(object sender, EventArgs e)
        {
            try
            {
                if (gdvCandidatos.Rows.Count > 0)
                {
                    if (MessageBox.Show("Deseja eleger " + gdvCandidatos.CurrentRow.Cells[3].Value + "?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        MsSqlConnection objAcessoDados = new MsSqlConnection();
                        DataRowView row = (DataRowView)cbCargos.SelectedValue;
                        int int_id_eleicao_cargo = Convert.ToInt32(row["int_id_eleicao_cargo"]);
                        objAcessoDados.ExecutaProcedure("sp_gerencia_eleicao_cargo_candidato",
                                                        new SqlParameter("str_acao", "ELE"),
                                                        new SqlParameter("int_id_eleicao_cargo", int_id_eleicao_cargo),
                                                        new SqlParameter("int_id_candidato", gdvCandidatos.CurrentRow.Cells[2].Value));
                        CarregarCandidatosCargo();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            CreateExcelDoc excell_app = new CreateExcelDoc();

            //creates the main header
            excell_app.createHeaders(1, 1, "Relatório de Eleição", "A1", "H1", 8, "", true, 10, "n");

            //creates subheaders
            excell_app.createHeaders(3, 1, "Código:", "A3", "A3", 0, "", true, 20, "");
            excell_app.createHeaders(4, 1, "Nome:", "A4", "A4", 0, "", true, 20, "");
            excell_app.createHeaders(5, 1, "Data de cadastro:", "A5", "A5", 0, "", true, 20, "");
            excell_app.createHeaders(6, 1, "Data início:", "A6", "A6", 0, "", true, 20, "");
            excell_app.createHeaders(7, 1, "Data fim:", "A7", "A7", 0, "", true, 20, "");
            excell_app.createHeaders(8, 1, "Eleitores:", "A8", "A8", 0, "", true, 20, "");
            excell_app.createHeaders(9, 1, "Votos:", "A9", "A9", 0, "", true, 20, "");
            excell_app.createHeaders(10, 1, "Válidos:", "A10", "A10", 0, "", true, 20, "");
            excell_app.createHeaders(11, 1, "Brancos:", "A11", "A11", 0, "", true, 20, "");
            excell_app.createHeaders(12, 1, "Nulos:", "A12", "A12", 0, "", true, 20, "");


            excell_app.addData(3, 2, txt_codigo.Text.ToUpper(), "B3", "B3", 30, "");
            excell_app.addData(4, 2, txt_nome.Text.ToUpper(), "B4", "B4", 30, "");
            excell_app.addData(5, 2, "'" + txt_data_cadastro.Text.ToUpper(), "B5", "B5", 30, "");
            excell_app.addData(6, 2, "'" + txt_data_inicio.Text.ToUpper(), "B6", "B6", 30, "");
            excell_app.addData(7, 2, "'" + txt_data_fim.Text, "B7", "B7", 30, "");
            excell_app.addData(8, 2, txt_numero_eleitores.Text.ToUpper(), "B8", "B8", 30, "");
            excell_app.addData(9, 2, txt_votos.Text.ToUpper(), "B9", "B9", 30, "");
            excell_app.addData(10, 2, txt_votos_validos.Text.ToUpper(), "B10", "B10", 30, "");
            excell_app.addData(11, 2, txt_votos_brancos.Text.ToUpper(), "B11", "B11", 30, "");
            excell_app.addData(12, 2, txt_votos_nulos.Text.ToUpper(), "B12", "B12", 30, "");

            excell_app.createHeaders(14, 1, "Cargo", "A14", "A14", 0, "", true, 20, "");
            excell_app.createHeaders(14, 2, "Vagas", "B14", "B14", 0, "", true, 20, "");
            excell_app.createHeaders(14, 3, "Data início", "C14", "C14", 0, "", true, 20, "");
            excell_app.createHeaders(14, 4, "Data fim", "D14", "D14", 0, "", true, 20, "");
            excell_app.createHeaders(14, 5, "Votos", "E14", "E14", 0, "", true, 20, "");
            excell_app.createHeaders(14, 6, "Válidos", "F14", "F14", 0, "", true, 20, "");
            excell_app.createHeaders(14, 7, "Brancos", "G14", "G14", 0, "", true, 20, "");
            excell_app.createHeaders(14, 8, "Nulos", "H14", "H14", 0, "", true, 20, "");

            int linha = 15;
            foreach (DataGridViewRow row in gdvCargosEleicao.Rows)
            {
                excell_app.addData(linha, 1, row.Cells[1].Value.ToString().ToUpper(), "A" + linha, "A" + linha, 20, "");
                excell_app.addData(linha, 2, row.Cells[2].Value.ToString().ToUpper(), "B" + linha, "B" + linha, 20, "");
                excell_app.addData(linha, 3, "'" + row.Cells[3].Value.ToString().ToUpper(), "C" + linha, "C" + linha, 20, "");
                excell_app.addData(linha, 4, "'" + row.Cells[4].Value.ToString().ToUpper(), "D" + linha, "D" + linha, 20, "");
                excell_app.addData(linha, 5, row.Cells[5].Value.ToString().ToUpper(), "E" + linha, "E" + linha, 20, "");
                excell_app.addData(linha, 6, row.Cells[6].Value.ToString().ToUpper(), "F" + linha, "F" + linha, 20, "");
                excell_app.addData(linha, 7, row.Cells[7].Value.ToString().ToUpper(), "G" + linha, "G" + linha, 20, "");
                excell_app.addData(linha, 8, row.Cells[8].Value.ToString().ToUpper(), "H" + linha, "H" + linha, 20, "");
                linha++;
            }

            linha++;
            int int_id_eleicao_cargo = 0;
            MsSqlConnection objAcessoDados = new MsSqlConnection();
            foreach (DataGridViewRow row in gdvCargosEleicao.Rows)
            {
                int_id_eleicao_cargo = Convert.ToInt32(row.Cells[0].Value);
                excell_app.createHeaders(linha, 1, row.Cells[1].Value.ToString(), "A" + linha, "A" + linha, 0, "", true, 20, "");

                linha++;
                excell_app.createHeaders(linha, 1, "Cód. Candidato", "A" + linha, "A" + linha, 0, "", true, 20, "");
                excell_app.createHeaders(linha, 2, "Nome", "B" + linha, "B" + linha, 0, "", true, 20, "");
                excell_app.createHeaders(linha, 3, "Votos", "C" + linha, "C" + linha, 0, "", true, 20, "");
                excell_app.createHeaders(linha, 4, "Status", "D" + linha, "D" + linha, 0, "", true, 20, "");

                linha++;
                using (SqlDataReader sdr = objAcessoDados.RetornaSqlDataReader("sp_gerencia_eleicao_cargo_candidato",
                                                                              new SqlParameter("str_acao", "SEL"),
                                                                              new SqlParameter("int_id_eleicao_cargo", int_id_eleicao_cargo)))
                {
                    while (sdr.Read())
                    {
                        excell_app.addData(linha, 1, sdr["int_id_candidato"].ToString(), "A" + linha, "A" + linha, 20, "");
                        excell_app.addData(linha, 2, sdr["str_nome_candidato"].ToString().ToUpper(), "B" + linha, "B" + linha, 20, "");
                        excell_app.addData(linha, 3, sdr["int_votos"].ToString(), "C" + linha, "C" + linha, 20, "");
                        excell_app.addData(linha, 4, sdr["str_nome_status"].ToString().ToUpper(), "D" + linha, "D" + linha, 30, "");
                        linha++;
                    }
                }

                linha += 2;
            }

        }
    }
}
