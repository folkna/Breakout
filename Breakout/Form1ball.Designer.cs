using System.Drawing;

namespace Breakout
{
    partial class Form1ball
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.player = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_score = new System.Windows.Forms.Label();
            this.Update = new System.Windows.Forms.Timer(this.components);
            this.label_life = new System.Windows.Forms.Label();
            this.label_Status = new System.Windows.Forms.Label();
            this.label_level = new System.Windows.Forms.Label();
            this.label_player = new System.Windows.Forms.Label();
            this.Ball = new System.Windows.Forms.PictureBox();
            this.Home = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Home)).BeginInit();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.White;
            this.player.Location = new System.Drawing.Point(400, 488);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(86, 13);
            this.player.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(853, 256);
            this.panel1.TabIndex = 0;
            // 
            // label_score
            // 
            this.label_score.AutoSize = true;
            this.label_score.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_score.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_score.Location = new System.Drawing.Point(298, 13);
            this.label_score.Name = "label_score";
            this.label_score.Size = new System.Drawing.Size(52, 16);
            this.label_score.TabIndex = 0;
            this.label_score.Text = "Score : ";
            // 
            // Update
            // 
            this.Update.Interval = 20;
            this.Update.Tick += new System.EventHandler(this.Update_Tick);
            // 
            // label_life
            // 
            this.label_life.AutoSize = true;
            this.label_life.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_life.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_life.Location = new System.Drawing.Point(408, 13);
            this.label_life.Name = "label_life";
            this.label_life.Size = new System.Drawing.Size(34, 16);
            this.label_life.TabIndex = 1;
            this.label_life.Text = "Life :";
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_Status.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_Status.Location = new System.Drawing.Point(658, 13);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(63, 17);
            this.label_Status.TabIndex = 2;
            this.label_Status.Text = "congrats";
            // 
            // label_level
            // 
            this.label_level.AutoSize = true;
            this.label_level.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_level.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_level.Location = new System.Drawing.Point(507, 13);
            this.label_level.Name = "label_level";
            this.label_level.Size = new System.Drawing.Size(54, 17);
            this.label_level.TabIndex = 3;
            this.label_level.Text = "Level : ";
            // 
            // label_player
            // 
            this.label_player.AutoSize = true;
            this.label_player.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_player.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_player.Location = new System.Drawing.Point(667, 508);
            this.label_player.Name = "label_player";
            this.label_player.Size = new System.Drawing.Size(56, 17);
            this.label_player.TabIndex = 4;
            this.label_player.Text = "Player :";
            // 
            // Ball
            // 
            this.Ball.BackColor = System.Drawing.Color.Transparent;
            this.Ball.Location = new System.Drawing.Point(430, 359);
            this.Ball.Name = "Ball";
            this.Ball.Size = new System.Drawing.Size(20, 20);
            this.Ball.TabIndex = 0;
            this.Ball.TabStop = false;
            this.Ball.Paint += new System.Windows.Forms.PaintEventHandler(this.Ball_Paint);
            // 
            // Home
            // 
            this.Home.Image = global::Breakout.Properties.Resources.home;
            this.Home.Location = new System.Drawing.Point(40, 4);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(34, 33);
            this.Home.TabIndex = 12;
            this.Home.TabStop = false;
            this.Home.Click += new System.EventHandler(this.Home_Click);
            // 
            // Form1ball
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(869, 541);
            this.Controls.Add(this.Home);
            this.Controls.Add(this.label_player);
            this.Controls.Add(this.label_level);
            this.Controls.Add(this.label_Status);
            this.Controls.Add(this.label_life);
            this.Controls.Add(this.Ball);
            this.Controls.Add(this.label_score);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.player);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1ball";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Breakout";
            this.Activated += new System.EventHandler(this.Form1ball_Activated);
            this.Deactivate += new System.EventHandler(this.Form1ball_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1ball_FormClosed);
            this.Load += new System.EventHandler(this.Form1ball_Load);
            this.Click += new System.EventHandler(this.Form1ball_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1ball_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1ball_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Home)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label player;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox Ball;
        private System.Windows.Forms.Label label_score;
        private System.Windows.Forms.Timer Update;
        private System.Windows.Forms.Label label_life;
        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.Label label_level;
        private System.Windows.Forms.Label label_player;
        private System.Windows.Forms.PictureBox Home;
    }
}