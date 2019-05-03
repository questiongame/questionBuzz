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
                //in case the teams file is not present
                teamLines = new String[4];
                teamLines[0] = "1|John|sound1|avatar1";
                teamLines[1] = "1|Mary|sound2|avatar2";
                teamLines[2] = "1|Carol|sound3|avatar3";
                teamLines[3] = "1|Ken|sound4|avatar4";
            };
            try
            {
                // Here we dinamically create Label for each team on the Teams selection screen
                this.teams = new Team[teamLines.Length];
                int x = 0, y = 0, c = 0;
                foreach (String teamLine in teamLines)
                {
                    if (teamLine != "")
                    {
                        String[] tlColumns = teamLine.Contains("\r") ? teamLine.Replace("\r", "").Split('|') : teamLine.Split('|');
                        if (tlColumns.Length >= 4)
                        {
                            Team newLabel = new Team(c, tlColumns[0] == "1", tlColumns[2], tlColumns[3]);
                            newLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                            newLabel.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            newLabel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
                            newLabel.Location = new System.Drawing.Point(50 + (x * 170), 100 + (y++ * 50));
                            if (y > 7) { x++; y = 0; }
                            newLabel.Margin = new System.Windows.Forms.Padding(1);
                            newLabel.Name = "lblTeams" + c;
                            newLabel.Size = new System.Drawing.Size(140, 40);
                            newLabel.TabIndex = 15;
                            newLabel.Text = newLabel.teamName = tlColumns[1];
                            newLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            newLabel.Click += new System.EventHandler(this.Label_Click);
                            this.Controls.Add(newLabel);
                            highlightTeam(newLabel);
                            if (tlColumns.Length > 4) for (int i = 4; i < tlColumns.Length; i++) newLabel.characteristics += tlColumns[i] + "|";
                            this.teams[c++] = newLabel;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error Creating Team Labels from the Config File");                
            };
        }
        private void highlightTeam(Team team)
        {
            try
            {
                if (team.selected)
                {
                    team.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(195)))), ((int)(((byte)(106)))));
                    team.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                }
                else
                {
                    team.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                    team.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
                team.selected = false;
            else
                team.selected = true;
            highlightTeam(team);
        }
        private void ReadyScreen_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            try
            {
                this.BackgroundImage = Image.FromFile("Resources\\SelectTeams.png");
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            }
            catch (Exception)
            {
            };
        }
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
                        teamsFile.WriteLine((team.selected?"1":"0") + "|" + team.teamName + "|" + team.strSound + "|" + team.avatar + "|" + team.characteristics);
                    }
                }
            }
            catch (Exception)
            {
            };
        }
        private void TeamsScreen_SizeChanged(object sender, EventArgs e)
        {
            double fontConstant = Math.Sqrt(Math.Pow(this.Size.Width, 2) + Math.Pow(this.Size.Height, 2)) / 1000;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", ((float)fontConstant * 28), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            int x = 0, y = 0;
            foreach (Team team in teams)
                if (team != null)
                {
                    team.Font = new System.Drawing.Font("Arial", ((float)fontConstant * 20), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    team.Location = new System.Drawing.Point(50 + (x * this.Size.Width * 170 / 800), (100 + (y++ * this.Size.Height * 50 / 600)));
                    team.Size = new System.Drawing.Size(this.Size.Width * 140 / 800, (this.Size.Height * 40 / 600));
                    if (y > 7) { x++; y = 0; }
                }
        }
    }
}
