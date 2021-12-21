using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aviv.Eleicao.Admin
{
    public partial class MenuFrm : Form
    {
        public MenuFrm()
        {
            InitializeComponent();
        }

        private void eleiçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EleicaoFrm frm = new EleicaoFrm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void candidatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CandidatoFrm frm = new CandidatoFrm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 frm = new AboutBox1();
            frm.MdiParent = this;
            frm.Show();
        }

        private void MenuFrm_Load(object sender, EventArgs e)
        {
            EntrarFrm frm = new EntrarFrm();
            frm.ShowDialog();
        }

       
    }
}
