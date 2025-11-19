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
    public partial class FormName : Form
    {
        public static string name_start;
        public FormName()
        {
            InitializeComponent();
        }

        private void buttonName_Click(object sender, EventArgs e)
        {
            name_start = textBoxName.Text;
            foreach (char c in name_start)
            {
                if (((Char.IsLetterOrDigit(c)) && !((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')) && (c >= 0x0E01 && c <= 0x0E5B)))
                {
                    MessageBox.Show("โปรดกรอกชื่อเป็นภาษาอังกฤษหรือตัวเลข", "กรอกชื่อไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (!String.IsNullOrEmpty(name_start))
            {
                if (string.Equals(FormStart._labelMode, "1 Ball"))
                {
                    Form1ball form1ball = new Form1ball();
                    this.Hide();
                    form1ball.Show();
                }
                else
                {
                    FormTest formTest = new FormTest();
                    this.Hide();
                    formTest.Show();
                }
            }

            else
            {
                MessageBox.Show("โปรดกรอกชื่อในช่องว่าง", "ไม่มีการกรอกชื่อผู้เล่น", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormName_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
    }

