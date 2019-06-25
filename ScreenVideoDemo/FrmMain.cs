using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenVideoDemo
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            ShowInTaskbar = false;
            ControlBox = true;
            Text = string.Empty;
            FormBorderStyle = FormBorderStyle.None;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Top = 100;
            Left = 100;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            videoSourcePanel1.BeginRecordVideo(panel1);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
