using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Net.Http.Headers;
using System.Media;
using System.Drawing.Printing;

namespace Breakout
{
    public partial class Form1ball : Form
    {
        private int mouse_move;
        private const int playerspeed = 15;
        bool IsLeftKeyDown;
        bool IsRightKeyDown;
        bool Isleft;
        int block_x;
        int block_y = 3;
        int ball_x, ball_y = 0;
        public static int score = 0;
        int life = 3;
        int level = 1;
        bool ball_outform = true;
        bool IsWin = false;
        bool ball_cooldown = false;
        bool IsGameover = false;
        public string nameplayer = FormName.name_start;
        SoundPlayer ball_bound_player = new SoundPlayer(Properties.Resources.ballplayerbound);
        SoundPlayer ball_bound_wall = new SoundPlayer(Properties.Resources.ballwallbound);
        SoundPlayer ball_out_form = new SoundPlayer(Properties.Resources.balloutform);
        SoundPlayer ball_bound_block = new SoundPlayer(Properties.Resources.ballblockbound);
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
        Panel panel_secondary = new Panel();
        Label GameoverandStart = new Label();
        Label text_pause = new Label();
        PictureBox[,] pic = new PictureBox[8, 13];
        string[][] player_data;


        public Form1ball()
        {
            InitializeComponent();
            label_score.Text = "Score : " + score;
            label_life.Text = "Life : " + life;
            label_level.Text = "Level : " + level;
            label_Status.Visible = false;
            if (nameplayer.Length >= 20)
            {
                label_player.Text = "Player : " + nameplayer.Substring(0,10)+"...";
            }
            else
            {
                label_player.Text = "Player : " + FormName.name_start;
            }
        }

        //Form_Load
        private void Form1ball_Load(object sender, EventArgs e)
        {
            Update.Start();
            text_pause.Text = "Pause".PadLeft(13) + "\n กดคลิกเพื่อเล่นต่อ";
            text_pause.Font = new Font("Microsoft Sans Serif", 20);
            text_pause.ForeColor = Color.White;
            text_pause.AutoSize = true;
            text_pause.Anchor = AnchorStyles.None;
            text_pause.BackColor = Color.Transparent;
            text_pause.Location = new Point((this.Width / 2) - 110, (this.Height / 2) - 60);

            this.Controls.Add(panel_secondary);
            panel_secondary.Size = new Size(895, 575);
            panel_secondary.BackColor = Color.FromArgb(30, Color.Gray);
            panel_secondary.Visible = false;
            panel_secondary.BringToFront();
            panel_secondary.Controls.Add(text_pause);
            Ball.Visible = false;

            GameoverandStart.Text = "Game Start";
            GameoverandStart.AutoSize = true;
            GameoverandStart.Font = new Font("Microsoft Sans Serif", 20);
            GameoverandStart.ForeColor = Color.White;
            GameoverandStart.Location = new Point(365, 345);
            this.Controls.Add(GameoverandStart);

            place_block();
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

        //ผู้เล่นกดเพื่อทำงาน
        private void Form1ball_KeyDown(object sender, KeyEventArgs e)
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
            if (e.KeyCode == Keys.Space && ball_outform && life > 0)
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
                if (IsWin)
                {
                    level += 1;
                    label_level.Text = "Level : " + level;
                    IsWin = false;
                    Restart();
                }
                else if (!IsWin && life == 0)
                {
                    level = 1;
                    score = 0;
                    life = 3;
                    IsGameover = false;
                    label_level.Text = "Level : " + level;
                    label_life.Text = "Life : " + life;
                    label_score.Text = "Score : " + score;
                    Restart();
                }
            }
        }

        //ผู้เล่นปล่อยปุ่ม
        private void Form1ball_KeyUp(object sender, KeyEventArgs e)
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


        //ผู้เล่นอยู่ไม่หน้าจอ
        private void Form1ball_Deactivate(object sender, EventArgs e)
        {
            panel_secondary.Visible = true;
            Update.Stop();
        }

        //ผู้เล่นอยู่หน้าจอ
        private void Form1ball_Activated(object sender, EventArgs e)
        {
            panel_secondary.Visible = false;
            if (life > 0)
            {
                Update.Start();
            }
        }

        //Update
        private void Update_Tick(object sender, EventArgs e)
        {
            if (life == 0)
            {
                GameoverandStart.Visible = true;
                GameoverandStart.Text = "Game Over";
                label_Status.Visible = true;
                label_Status.Text = "กด R เพื่อเล่น (นับคะแนนใหม่)";
                Update.Stop();
                IsGameover = true;

            }
            if ((Control.MouseButtons == MouseButtons.Right || Control.MouseButtons == MouseButtons.Left) && ball_outform && life > 0)
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
                int mouseX = MousePosition.X - this.Location.X;
                int player_x = mouseX - (player.Width / 2);
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
                ball_cooldown = false;
                ball_bound_player.Play();
                Ball.Top = player.Top - Ball.Height;
                ball_y = rand.Next(5 + level - 1, 10 + level - 1) * -1;
                if (ball_x < 0)
                {
                    ball_x = rand.Next(5 + level - 1, 10 + level - 1) * -1;
                }
                else
                {
                    ball_x = rand.Next(5 + level - 1, 10 + level - 1);
                }
            }
            if (Ball.Top > 605 && !ball_outform)
            {
                ball_out_form.Play();
                life -= 1;
                ball_outform = true;
                label_life.Text = "Life : " + life;
            }
            foreach (Control c in panel1.Controls)
            {
                //เช็ค Ball ชน Block
                if (Ball.Bounds.IntersectsWith(new Rectangle(c.Left, c.Top + 30, c.Width, c.Height)) && !ball_cooldown)
                {
                    panel1.Controls.Remove(c);
                    ball_y = -ball_y;
                    ball_bound_block.Play();
                    while (ball_bound_block.IsLoadCompleted == false)
                    {
                        Application.DoEvents();
                    }
                    int count = 1;
                    for (int i = 7; i > -1; i--)
                    {
                        if (c.Location.Y == 3 + (21 * i))
                        {
                            score += count;
                            break;
                        }
                        count++;
                    }
                    label_score.Text = "Score : " + score;
                    break;
                }
            }

            if (score == 468 * level)
            {
                label_Status.Visible = true;
                label_Status.Text = "ยินดีด้วยคุณได้ชนะเกมเรียบร้อยแล้ว!!!!!";
                GameoverandStart.Location = new Point(315, 345);
                GameoverandStart.Text = "กด R เพื่อเล่นในเลเวลต่อไป";
                GameoverandStart.Visible = true;
                IsWin = true;
                Update.Stop();
            }
        }

        //Form1ball_Click
        private void Form1ball_Click(object sender, EventArgs e)
        {
            if (IsGameover)
            {
                this.Hide();
                FormHighScore formHighScore = new FormHighScore();
                formHighScore.Show();
            }
        }

        //Restart
        private void Restart()
        {
            Ball.Location = new Point(430, 357);
            GameoverandStart.Location = new Point(365, 345);
            label_Status.Visible = false;
            GameoverandStart.Text = "";
            GameoverandStart.Text = "Game Start";
            ball_x = 0;
            ball_y = 0;
            block_y = 3;
            panel1.Controls.Clear();
            place_block();
            ball_outform = true;
            Ball.Visible = false;
            Update.Start();
        }


        private void Form1ball_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //กดปุ่ม home
        private void Home_Click(object sender, EventArgs e)
        {
            Update.Stop();
            DialogResult dialogResult = MessageBox.Show("คุณต้องการกลับหน้าแรกไหม?" + Environment.NewLine + "คะแนนจะไม่ถูกทำการบันทึก","กลับหน้าแรก",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Restart();
            }
            else 
            {
                Update.Start();
            }
        }
    }
}

   

