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
    public partial class CandidatoPesquisaInserirFrm : Form
    {
        EleicaoFrm objEleicaoFrm;
        int int_id_eleicao_cargo;
        public CandidatoPesquisaInserirFrm()
        {
            InitializeComponent();
        }

        public CandidatoPesquisaInserirFrm(EleicaoFrm eleicaoFrm, int int_id_eleicao_cargo)
        {
            objEleicaoFrm = eleicaoFrm;
            this.int_id_eleicao_cargo = int_id_eleicao_cargo;
            InitializeComponent();
        }

        private void CandidatoPesquisaInserirFrm_Load(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            MsSqlConnection objAcessoDados = new MsSqlConnection();
            gdvCandidato.DataSource = objAcessoDados.RetornaDataTable("sp_gerencia_candidato",
                                                                    new SqlParameter("str_acao", "P-I"),
                                                                    new SqlParameter("int_id_eleicao_cargo", int_id_eleicao_cargo),
                                                                    new SqlParameter("int_id_candidato", txtCodigo.Text),
                                                                    new SqlParameter("str_nome_candidato", txtNome.Text.Trim()),
                                                                    new SqlParameter("str_apelido_candidato", txt_apelido.Text.Trim()));
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void txt_apelido_TextChanged(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void btnMarcarTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gdvCandidato.Rows)
            {
                row.Cells[0].Value = true;
            }
        }

        private void btnDesmarcarTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gdvCandidato.Rows)
            {
                row.Cells[0].Value = false;
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            MsSqlConnection objAcessoDados = new MsSqlConnection();
            int inseridos = 0;
            foreach (DataGridViewRow row in gdvCandidato.Rows)
            {
                bool isChecked = (Boolean)row.Cells[0].FormattedValue;
                if (isChecked)
                {
                    using (SqlDataReader sdr = objAcessoDados.RetornaSqlDataReader("sp_gerencia_eleicao_cargo_candidato",
                                                                                   new SqlParameter("str_acao", "INS"),
                                                                                   new SqlParameter("int_id_eleicao_cargo", int_id_eleicao_cargo),
                                                                                   new SqlParameter("int_id_candidato", row.Cells[1].Value)))
                    {
                        if (sdr.HasRows)
                        {
                            inseridos++;
                        }
                    }
                }
            }

            if (inseridos.Equals(0))
            {
                MessageBox.Show("Nenhum candidato inserido para ser votado no cargo", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                objEleicaoFrm.CarregarCandidatosCargo();
                MessageBox.Show(inseridos + " candidatos inseridos para serem votados no cargo", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gdvCandidato_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                bool isChecked = (Boolean)gdvCandidato[0, e.RowIndex].FormattedValue;
                if (isChecked)
                    gdvCandidato[0, e.RowIndex].Value = false;
                else
                    gdvCandidato[0, e.RowIndex].Value = true;
            }
        }
    }
}
