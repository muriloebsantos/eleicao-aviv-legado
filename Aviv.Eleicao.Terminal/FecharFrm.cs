using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aviv.Eleicao.Terminal
{
    public partial class FecharFrm : Form
    {
        public FecharFrm()
        {
            InitializeComponent();
        }

        private void Fechar()
        {
            if (txtSenha.Text.Equals("sysadmin"))
            {
                Application.Exit();
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Fechar();
        }

        private void FecharFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                Fechar();
            }
        }
    }
}
