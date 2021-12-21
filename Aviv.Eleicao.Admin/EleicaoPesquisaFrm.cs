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
    public partial class EleicaoPesquisaFrm : Form
    {
        EleicaoFrm objEleicaoFrm;
        public EleicaoPesquisaFrm(EleicaoFrm frm)
        {
            objEleicaoFrm = frm;
            InitializeComponent();
        }

        private void CarregaGrid()
        {
            MsSqlConnection objAcessoDados = new MsSqlConnection();
            gdvEleicao.DataSource = objAcessoDados.RetornaDataTable("sp_gerencia_eleicao",
                                                                    new SqlParameter("@str_acao", "PES"),
                                                                    new SqlParameter("@int_id_eleicao", txtCodigo.Text),
                                                                    new SqlParameter("@str_nome", txtNome.Text.Trim()));
                                

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void EleicaoPesquisaFrm_Load(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void gdvEleicao_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            objEleicaoFrm.CarregaDadosEleicao(Convert.ToInt32(gdvEleicao.CurrentRow.Cells[0].Value));
            this.Close();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            objEleicaoFrm.CarregaDadosEleicao(Convert.ToInt32(gdvEleicao.CurrentRow.Cells[0].Value));
            this.Close();
        }
    }
}
