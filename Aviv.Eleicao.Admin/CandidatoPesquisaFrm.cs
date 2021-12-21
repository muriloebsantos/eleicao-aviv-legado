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
    public partial class CandidatoPesquisaFrm : Form
    {
        CandidatoFrm objCandidatoFrm;
        public CandidatoPesquisaFrm()
        {
            InitializeComponent();
        }

        public CandidatoPesquisaFrm(CandidatoFrm candidatoFrm)
        {
            objCandidatoFrm = candidatoFrm;
            InitializeComponent();
        }

        private void CandidatoPesquisaFrm_Load(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            MsSqlConnection objAcessoDados = new MsSqlConnection();
            gdvCandidato.DataSource = objAcessoDados.RetornaDataTable("sp_gerencia_candidato",
                                                                    new SqlParameter("str_acao", "PES"),
                                                                    new SqlParameter("@int_id_candidato", txtCodigo.Text),
                                                                    new SqlParameter("@str_nome_candidato", txtNome.Text.Trim()),
                                                                    new SqlParameter("@str_apelido_candidato", txt_apelido.Text.Trim()));


        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void txtApelido_TextChanged(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void gdvCandidato_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            objCandidatoFrm.CarregarDadosCandidato(Convert.ToInt32(gdvCandidato.CurrentRow.Cells[0].Value));
            this.Close();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            objCandidatoFrm.CarregarDadosCandidato(Convert.ToInt32(gdvCandidato.CurrentRow.Cells[0].Value));
            this.Close();
        }
    }
}
