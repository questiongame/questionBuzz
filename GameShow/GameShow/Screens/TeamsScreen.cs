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
    public partial class TeamsScreen : Form
    {
        private Team[] teams = null;
        private void loadTeams()
        {
            String[] teamLines = null;
            try
            {
                //this file stores the list of teams
                String teamsFile = File.ReadAllText("Resources\\teams.txt");
                teamLines = teamsFile.Split('\n');
            }
            catch (Exception)
            {
                teamLines = new String[4];
                teamLines[0] = "1|John|sound1|avatar1";
                teamLines[1] = "1|Mary|sound2|avatar2";
                teamLines[2] = "1|Carol|sound3|avatar3";
                teamLines[3] = "1|Ken|sound4|avatar4";
            };
            try
            {
                // Here we dinamically create Label for each team on the 
                this.teams = new Team[teamLines.Length];
                int x = 0, y = 0;
                for (int i = 0; i < teamLines.Length; i++)
                {
                    if (teamLines[i] != "")
                    {
                        if (teamLines[i].Contains("\r"))
                            teamLines[i] = teamLines[i].Replace("\r", ""); //Need to remove new line char at end of line. Optionally use System.Environment.NewLine
                        String[] tlColumns = teamLines[i].Split('|');
                        if (tlColumns.Length >= 4)
                        {
                            Team newLabel = new Team(i, tlColumns[0] == "1", tlColumns[2], tlColumns[3]);
                            newLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
                            newLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                            newLabel.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            newLabel.ForeColor = System.Drawing.Color.Black;
                            newLabel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
                            newLabel.Location = new System.Drawing.Point(50 + (x * 170), 100 + (y * 50));
                            y++;
                            if (y > 7) { x++; y = 0; }
                            newLabel.Margin = new System.Windows.Forms.Padding(1);
                            newLabel.Name = "lblTeams" + i;
                            newLabel.Size = new System.Drawing.Size(140, 40);
                            newLabel.TabIndex = 15;
                            newLabel.Text = newLabel.teamName = tlColumns[1];
                            newLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            newLabel.Click += new System.EventHandler(this.Label_Click);
                            this.Controls.Add(newLabel);
                            highlightTeam(newLabel);
                            this.teams[i] = newLabel;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error Creating Team Labels with the Config File");                
            };
        }
        private void highlightTeam(Team team)
        {
            try
            {
                if (team.selected)
                {
                    team.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(195)))), ((int)(((byte)(106)))));
                    team.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    team.BackColor = System.Drawing.Color.White;
                    team.ForeColor = System.Drawing.Color.Black;
                }
            }
            catch (Exception)
            {
            };
        }
        public TeamsScreen()
        {
            loadTeams();
            InitializeComponent();
        }
        private void Label_Click(object sender, EventArgs e)
        {
            Team team = sender as Team;
            if (team.selected)
            {
                team.selected = false;
            }
            else
            {
                team.selected = true;
            }
            highlightTeam(team);
        }
        private void ReadyScreen_Load(object sender, EventArgs e) { }
        private void TeamsScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //will write the new teams config
                File.Delete("Resources\\teams.txt");
                using (StreamWriter teamsFile = new StreamWriter("Resources\\teams.txt"))
                {
                    foreach (Team team in teams)
                    {
                        teamsFile.WriteLine((team.selected?"1":"0") + "|" + team.teamName + "|" + team.strSound + "|" + team.avatar );
                    }
                }
            }
            catch (Exception)
            {
            };
        }
        private void TeamsScreen_SizeChanged(object sender, EventArgs e)
        {
            double fontConstant = Math.Sqrt(Math.Pow(this.Size.Width, 2) + Math.Pow(this.Size.Height, 2));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", ((float)fontConstant * 28 / 1000), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            int x = 0, y = 0;
            foreach (Team team in teams)
                if (team != null)
                {
                    team.Font = new System.Drawing.Font("Arial", ((float)fontConstant * 20 / 1000), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    team.Location = new System.Drawing.Point(50 + (x * this.Size.Width * 170 / 800), (100 + (y * this.Size.Height * 50 / 600)));
                    team.Size = new System.Drawing.Size(this.Size.Width * 140 / 800, (this.Size.Height * 40 / 600));
                    y++;
                    if (y > 7) { x++; y = 0; }
                }
        }
    }
}
