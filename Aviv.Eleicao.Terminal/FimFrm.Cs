using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Aviv.Eleicao.Terminal
{
    public partial class FimFrm : Form
    {
        public FimFrm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FimFrm_Load(object sender, EventArgs e)
        {
            label1.Top = (this.Height / 2) - label1.Height;
            label1.Left = (this.Width / 2) - label1.Width;
        }

    }
}
