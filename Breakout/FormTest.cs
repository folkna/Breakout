using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Breakout
{
    public partial class FormTest : Form
    {
        private int mouse_move;
        private const int playerspeed = 15;
        bool IsLeftKeyDown;
        bool IsRightKeyDown;
        bool Isleft;
        int block_x;
        int block_y = 3;
        int ball_x, ball_y = 0;
        bool ball_outform = true;
        bool ball_cooldown = false;
        SoundPlayer ball_bound_player = new SoundPlayer(Properties.Resources.ballplayerbound);
        SoundPlayer ball_bound_wall = new SoundPlayer(Properties.Resources.ballwallbound);
        SoundPlayer ball_out_form = new SoundPlayer(Properties.Resources.balloutform);
        SoundPlayer ball_bound_block = new SoundPlayer(Properties.Resources.ballblockbound);
        string nameplayer = FormName.name_start;
        int[][] colors = { new int[] {193,57,76}
          , new int[] {202,66,71}
          , new int[] {211,103,54}
          , new int[] {194,156,11}
          , new int[] {70,167,65}
          , new int[] {53,58,206}
          , new int[] {115,65,208}
          , new int[] {6,179,182}
         };
        Random rand = new Random();
        Panel panel2 = new Panel();
        System.Windows.Forms.Label GameoverandStart = new System.Windows.Forms.Label();
        System.Windows.Forms.Label text_pause = new System.Windows.Forms.Label();
        PictureBox[,] pic = new PictureBox[8, 13];

        public FormTest()
        {
            InitializeComponent();
            if (nameplayer.Length >= 20)
            {
                label_player.Text = "Player : " + nameplayer.Substring(0, 10) + "...";
            }
            else
            {
                label_player.Text = "Player : " + FormName.name_start;
            }
            label_Status.Text = "กด R เพื่อวางบล็อคใหม่";
        }

        //Form_Load
        private void FormTest_Load(object sender, EventArgs e)
        {
            Update.Start();
            text_pause.Text = "Pause".PadLeft(13) + "\n กดคลิกเพื่อเล่นต่อ";
            text_pause.Font = new Font("Microsoft Sans Serif", 20);
            text_pause.ForeColor = Color.White;
            text_pause.AutoSize = true;
            text_pause.Anchor = AnchorStyles.None;
            text_pause.BackColor = Color.Transparent;
            text_pause.Location = new Point((this.Width / 2) - 110, (this.Height / 2) - 60);

            this.Controls.Add(panel2);
            panel2.Size = new Size(895, 575);
            panel2.BackColor = Color.FromArgb(30, Color.Gray);
            panel2.Visible = false;
            panel2.BringToFront();
            panel2.Controls.Add(text_pause);
            Ball.Visible = false;

            GameoverandStart.Text = "Game Start";
            GameoverandStart.AutoSize = true;
            GameoverandStart.Font = new Font("Microsoft Sans Serif", 20);
            GameoverandStart.ForeColor = Color.White;
            GameoverandStart.Location = new Point(365, 345);
            this.Controls.Add(GameoverandStart);

            place_block();
        }

        //ผู้เล่นอยู่หน้าจอ
        private void FormTest_Activated(object sender, EventArgs e)
        {
            panel2.Visible = false;
            Update.Start();
        }

        //ผู้เล่นไม่อยู่หน้าจอ
        private void FormTest_Deactivate(object sender, EventArgs e)
        {
            panel2.Visible = true;
            Update.Stop();
        }

        //ผู้เล่นกดปุ่มเพื่อทำงาน
        private void FormTest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                IsLeftKeyDown = true;
                Isleft = true;
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                IsRightKeyDown = true;
                Isleft = false;
            }
            if (e.KeyCode == Keys.Space && ball_outform)
            {
                GameoverandStart.Visible = false;
                Ball.Visible = true;
                Ball.Location = new Point(410, 190);
                ball_cooldown = true;
                ball_outform = false;
                ball_x = 5;
                ball_y = 5;
            }
            if (e.KeyCode == Keys.R) 
            {
                panel1.Controls.Clear();
                block_y = 3;
                place_block();
            }
        }

        //ผู้เล่นปล่อยปุ่ม
        private void FormTest_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                IsLeftKeyDown = false;
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                IsRightKeyDown = false;
            }
        }

        //ทำบอล
        private void Ball_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int diameter = 12;
            int x = (Ball.Width - diameter) / 2;
            int y = (Ball.Height - diameter) / 2;

            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(x, y, diameter, diameter);
            Ball.Region = new Region(path);

            Brush brush = new SolidBrush(Color.White);

            g.FillEllipse(brush, x, y, diameter, diameter);
        }

        //Update
        private void Update_Tick(object sender, EventArgs e)
        {
            if ((Control.MouseButtons == MouseButtons.Right || Control.MouseButtons == MouseButtons.Left) && ball_outform)
            {
                GameoverandStart.Visible = false;
                Ball.Visible = true;
                Ball.Location = new Point(410, 190);
                ball_cooldown = true;
                ball_outform = false;
                ball_x = 5;
                ball_y = 5;
            }

            if (mouse_move != MousePosition.X)
            {
                int mouse_x = MousePosition.X - this.Location.X;
                int player_x = mouse_x - (player.Width / 2);
                mouse_move = MousePosition.X;
                player_x = Math.Max(0, player_x);
                player_x = Math.Min(780, player_x);
                player.Left = player_x;
            }
            if (Isleft)
            {
                if (IsLeftKeyDown && player.Left > 0)
                {
                    player.Left -= playerspeed;
                }
                else if (IsRightKeyDown && player.Left < 770)
                {
                    player.Left += playerspeed;
                }
            }
            else if (!Isleft)
            {
                if (IsRightKeyDown && player.Left < 770)
                {
                    player.Left += playerspeed;
                }
                else if (IsLeftKeyDown && player.Left > 0)
                {
                    player.Left -= playerspeed;
                }
            }
            Ball.Left += ball_x;
            Ball.Top += ball_y;

            if (Ball.Left > 850 || Ball.Left < 0)
            {
                if (!ball_outform) 
                {
                    ball_bound_wall.Play();
                }
                ball_x = -ball_x;
            }
            if (Ball.Top < 0)
            {
                if (!ball_outform)
                {
                    ball_bound_wall.Play();
                }
                ball_y = -ball_y;
            }
            // เช็ค Ball ชน player
            if (Ball.Bounds.IntersectsWith(player.Bounds))
            {
                ball_bound_player.Play();
                ball_cooldown = false;
                Ball.Top = player.Top - Ball.Height;
                ball_y = rand.Next(5, 10) * -1;
                if (ball_x < 0)
                {
                    ball_x = rand.Next(5, 10) * -1;
                }
                else
                {
                    ball_x = rand.Next(5, 10);
                }
            }
            if (Ball.Top > 605 && !ball_outform)
            {
                ball_out_form.Play();
                ball_cooldown = true;
                ball_outform = true;
            }
            foreach (Control c in panel1.Controls)
            {
                //เช็ค Ball ชน Block
                if (Ball.Bounds.IntersectsWith(new Rectangle(c.Left, c.Top + 30, c.Width, c.Height)) && !ball_cooldown)
                {
                    panel1.Controls.Remove(c);
                    ball_y = -ball_y;
                    if (!ball_cooldown)
                    {
                        ball_bound_block.Play();
                    }

                    while (ball_bound_block.IsLoadCompleted == false)
                    {
                        Application.DoEvents();
                    }
                    break;
                }
            }

        }

        private void FormTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //กดปุ่ม home
        private void home_Click(object sender, EventArgs e)
        {
            Update.Stop();
            DialogResult dialogResult = MessageBox.Show("คุณต้องการกลับหน้าแรกไหม?" + Environment.NewLine + "คะแนนจะไม่ถูกทำการบันทึก", "กลับหน้าแรก", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Restart();
            }
            else
            {
                Update.Start();
            }
        }

        //วาง Block
        private void place_block()
        {
            for (int i = 0; i < 8; i++)
            {
                block_x = 5;
                for (int j = 0; j < 13; j++)
                {
                    pic[i, j] = new PictureBox();
                    pic[i, j].Height = 19;
                    pic[i, j].Width = 65;
                    pic[i, j].Location = new Point(block_x, block_y);
                    pic[i, j].BackColor = Color.FromArgb(colors[i][0], colors[i][1], colors[i][2]);
                    pic[i, j].BorderStyle = BorderStyle.FixedSingle;
                    pic[i, j].Tag = "block";
                    pic[i, j].TabIndex = 0;
                    panel1.Controls.Add(pic[i, j]);
                    block_x += 65;
                }
                block_y += 21;
            }
        }
    }
}
