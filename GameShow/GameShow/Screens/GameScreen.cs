using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GameShow
{
    public partial class GameScreen : Form
    {
        private System.Windows.Forms.Label[] lblTeams;
        private void loadTeams()
        {
            String[] teams = null;
            try
            {
                //this file stores the list of teams
                String teamsFile = File.ReadAllText("teams.txt");
                teams = teamsFile.Split('\n');
            }
            catch (Exception)
            {
                teams = new String[4];
                teams[0] = "John";
                teams[1] = "Mary";
                teams[2] = "Carol";
                teams[3] = "Ken";
            }
            // Here we dinamically create Label for each team on the 
            this.lblTeams = new System.Windows.Forms.Label[teams.Length];
            for (int i = 0; i < teams.Length; i++)
            {
                teams[i] = teams[i].Replace("\r", ""); //Need to remove new line char at end of line. Optionally use System.Environment.NewLine
                this.lblTeams[i] = new System.Windows.Forms.Label();
                this.lblTeams[i].Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                this.lblTeams[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.lblTeams[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblTeams[i].ForeColor = System.Drawing.Color.Black;
                this.lblTeams[i].ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
                this.lblTeams[i].Location = new System.Drawing.Point(586, 12 + (i * 55));
                this.lblTeams[i].Margin = new System.Windows.Forms.Padding(1);
                this.lblTeams[i].Name = "lblTeams" + i;
                this.lblTeams[i].Size = new System.Drawing.Size(186, 46);
                this.lblTeams[i].TabIndex = 15;
                this.lblTeams[i].Text = teams[i];
                this.lblTeams[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.Controls.Add(this.lblTeams[i]);
            }
        }
        public GameScreen()
        {
            loadTeams();
            InitializeComponent();
        }

        private void ReadyScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            String keyPressed = e.KeyChar.ToString();
            if (keyPressed.ToLower().Equals("w"))
            {
                lblRight.Hide();
                lblWrong.Show();
            }
            else if (keyPressed.ToLower().Equals("r"))
            {
                lblRight.Show();
                lblWrong.Hide();
            }
            else
            {
                switch (keyPressed.ToLower())
                {
                    case "1": highlightTeam(0); break;
                    case "2": highlightTeam(1); break;
                    case "3": highlightTeam(2); break;
                    case "4": highlightTeam(3); break;
                    case "5": highlightTeam(4); break;
                    case "6": highlightTeam(5); break;
                    case "7": highlightTeam(6); break;
                    case "8": highlightTeam(7); break;
                    case "9": highlightTeam(8); break;
                    case "0": highlightTeam(9); break;
                }
                lblRight.Hide();
                lblWrong.Hide();
            }
            //MessageBox.Show(keyPressed);
            return;
        }

        private void highlightTeam(int team)
        {
            try
            {
                lblTeams[team].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(195)))), ((int)(((byte)(106)))));
                lblTeams[team].ForeColor = System.Drawing.Color.White;
                //lblTeams[team].BackColor = System.Drawing.Color.White;
                //lblTeams[team].ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception)
            {

            }
        }

        private void ReadyScreen_Load(object sender, EventArgs e)
        {
            lblRight.Hide();
            lblWrong.Hide();
            lblRight.Parent = lblMainBoxLabel;
            lblWrong.Parent = lblMainBoxLabel;
            lblRight.Top -= 100;
            lblWrong.Top -= 100;
        }

        private void GameScreen_SizeChanged(object sender, EventArgs e)
        {
            lblMainBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", (this.Size.Width * 48 / 800), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", (this.Size.Width * 28 / 800), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblRight.Font = new System.Drawing.Font("Comic Sans MS", (this.Size.Width * 200 / 800), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblWrong.Font = new System.Drawing.Font("Comic Sans MS", (this.Size.Width * 200 / 800), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
    }
}
