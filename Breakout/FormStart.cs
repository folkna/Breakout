using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Breakout
{
    public partial class FormStart : Form
    {
        string[] mode = {"1 Ball", "Test"};
        int idx_mode;
        public static string _labelMode;
        bool IsChange = false;
        public FormStart()
        {
            InitializeComponent();
        }

        private void FormStart_Load(object sender, EventArgs e)
        {
            labelMode.Text = mode[0];
            idx_mode = Array.IndexOf(mode,labelMode.Text);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.ForeColor = IsChange ? Color.White : Color.FromArgb(47, 48, 51);
            IsChange = !IsChange;
        }

        private void pictureLeft_Click(object sender, EventArgs e)
        {
            idx_mode--;
            if (idx_mode < 0)
            {
                idx_mode = mode.Length - 1;
            }
            labelMode.Text = mode[idx_mode];
        }

        private void pictureRight_Click(object sender, EventArgs e)
        {
            idx_mode++;
            if (idx_mode >= mode.Length)
            {
                idx_mode = 0;
            }
            labelMode.Text = mode[idx_mode];
        }

        private void FormStart_Click(object sender, EventArgs e)
        {
            _labelMode = labelMode.Text;
            FormName formName = new FormName();
            this.Hide();
            formName.Show();
        }

        private void FormStart_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
