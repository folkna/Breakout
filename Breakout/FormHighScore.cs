using Breakout.Properties;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout
{
    public partial class FormHighScore : Form
    {
        string[][] player_data;
        public FormHighScore()
        {
            InitializeComponent();
        }

        private void FormHighScore_Load(object sender, EventArgs e)
        {
            label_player.Text = "";
            label_score.Text = "";
            string filePath = Path.Combine(Environment.CurrentDirectory, "Highscores.txt");
            if (!File.Exists(filePath)) 
            {
                using (StreamWriter writer = new StreamWriter("Highscores.txt")) 
                {
                    for (int j = 0; j < 5; j++) 
                    {
                        writer.WriteLine("none,0");
                    }
                }
            }
            Console.WriteLine(filePath);
            player_data = Read2DArrayFromFile(filePath);
            order_highscore();
            string[] player_top5_decoded = new string[5];
            string[] player_top5_score = new string[5];
            int i = 0;
            foreach (string[] row in player_data) 
            {
                Console.WriteLine(i);
                if (i > 4) { break; }
                player_top5_decoded[i] = Shift_Cipher(row[0], "decoded");
                if (player_top5_decoded[i].Length >= 20)
                {
                    string substr = player_top5_decoded[i].Substring(0,12);
                    player_top5_decoded[i] = substr + "...";
                }
                player_top5_score[i] = row[1];
                i++;
            }
            label_player.Text = String.Join(Environment.NewLine + Environment.NewLine, player_top5_decoded);
            label_score.Text = String.Join(Environment.NewLine + Environment.NewLine, player_top5_score);

        }

        private string[][] Read2DArrayFromFile(string file)
        {
            int column = File.ReadLines(file).First().Split(',').Length;
            string[][] player_highscore = new string[5][];

            using (StreamReader reader = new StreamReader(file))
            {
                string line;
                int i = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] arr = new string[column];
                    string[] value = line.Split(',');
                    for (int j = 0; j < value.Length; j++)
                    {
                        arr[j] = value[j];
                    }
                    player_highscore[i] = arr;
                    i++;
                }
            }
            int idx = 0;
            foreach (string[] s in player_highscore)
            {
                if (s[0] != "none")
                {
                    s[0] = Shift_Cipher(s[0], "decoded");
                    player_highscore[idx] = new string[] { s[0], s[1] };
                }
                idx++;
            }
            return player_highscore;
        }

        private string Shift_Cipher(string cal, string en_or_de)
        {
            int shift = 11;
            if (en_or_de != "encoded")
            {

                shift = -shift;
            }
            StringBuilder result = new StringBuilder();
            foreach (char c in cal)
            {
                if (char.IsLetter(c))
                {
                    int charcode = c + shift;
                    if (char.IsLower(c))
                    {
                        if (charcode < 'a') charcode += 26;
                        else if (charcode > 'z') charcode -= 26;
                    }
                    else if ((char.IsUpper(c)))
                    {
                        if (charcode < 'A') charcode += 26;
                        else if (charcode > 'Z') charcode -= 26;
                    }
                    result.Append((char)charcode);
                }
                else if (char.IsDigit(c))
                {
                    int digitcode = ((c - '0') + shift) % 10;
                    if (digitcode < 0) digitcode += 10;
                    result.Append(digitcode.ToString());
                }
                else
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }

        private void order_highscore()
        {
            for (int i = 0; i < player_data.Length; i++)
            {
                if (Form1ball.score >= Convert.ToInt32(player_data[i][1]))
                {
                    string[][] new_data = new string[player_data.Length + 1][];
                    for (int j = 0; j < new_data.Length; j++)
                    {
                        if (j < i)
                        {
                            new_data[j] = player_data[j];
                        }
                        else if (j == i)
                        {
                            new_data[j] = new string[] { FormName.name_start, Form1ball.score.ToString() };
                        }
                        else
                        {
                            new_data[j] = player_data[j - 1];
                        }
                    }
                    player_data = new_data.OrderByDescending(row => Convert.ToInt32(row[1])).ToArray();
                    break;
                }
            }
            using (StreamWriter writer = new StreamWriter("Highscores.txt"))
            {
                int i = 0;
                foreach (string[] row in player_data)
                {
                    if (i > 4)
                    {
                        break;
                    }
                    row[0] = Shift_Cipher(row[0], "encoded");
                    Console.WriteLine(row[0]);
                    writer.WriteLine(string.Join(",", row));
                    i++;
                }
            }
        }

        private void buttonback_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void FormHighScore_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
