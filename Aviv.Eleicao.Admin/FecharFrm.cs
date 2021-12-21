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
   
    public partial class EntrarFrm : Form
    {
        bool close = false;
        public EntrarFrm()
        {
            InitializeComponent();
        }

        private void Fechar()
        {
            if (txtSenha.Text.Equals("sysadmin"))
            {
                close = true;
                this.Close();
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

        private void EntrarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == false)
            {
                Application.Exit();
            }
        }
    }
}
