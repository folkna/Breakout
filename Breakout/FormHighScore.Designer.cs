namespace Breakout
{
    partial class FormHighScore
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_score = new System.Windows.Forms.Label();
            this.label_player = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_back = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label_score);
            this.panel1.Controls.Add(this.label_player);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(135, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(614, 416);
            this.panel1.TabIndex = 0;
            // 
            // label_score
            // 
            this.label_score.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label_score.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_score.Location = new System.Drawing.Point(387, 99);
            this.label_score.Name = "label_score";
            this.label_score.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_score.Size = new System.Drawing.Size(206, 292);
            this.label_score.TabIndex = 2;
            this.label_score.Text = "text_score";
            // 
            // label_player
            // 
            this.label_player.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label_player.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_player.Location = new System.Drawing.Point(15, 99);
            this.label_player.Name = "label_player";
            this.label_player.Size = new System.Drawing.Size(310, 292);
            this.label_player.TabIndex = 1;
            this.label_player.Text = "text_player";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(228, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "HighScore";
            // 
            // button_back
            // 
            this.button_back.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_back.FlatAppearance.BorderSize = 10;
            this.button_back.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button_back.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.button_back.Location = new System.Drawing.Point(384, 480);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(107, 34);
            this.button_back.TabIndex = 1;
            this.button_back.Text = "Back";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.buttonback_Click);
            // 
            // FormHighScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(879, 536);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormHighScore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "breakout";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormHighScore_FormClosed);
            this.Load += new System.EventHandler(this.FormHighScore_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_score;
        private System.Windows.Forms.Label label_player;
        private System.Windows.Forms.Button button_back;
    }
}