using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace GameShow
{
    public partial class TestScreen : Form
    {
        private Team[] teams = null;
        private int teamValidating = 1;
        private int cTeam = 0;
        public TestScreen()
        {
            loadTeams();
            InitializeComponent();
        }
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
                cTeam = 0;
                for (int i = 0; i < teamLines.Length; i++)
                {
                    if (!(teamLines[i] == ""))
                    {
                        if (teamLines[i].Contains("\r"))
                            teamLines[i] = teamLines[i].Replace("\r", ""); //Need to remove new line char at end of line. Optionally use System.Environment.NewLine
                        String[] tlColumns = teamLines[i].Split('|');
                        if (tlColumns[0] == "1")
                        {
                            Team newLabel = new Team(cTeam, true, tlColumns[2], tlColumns[3]);
                            newLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
                            newLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                            newLabel.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            newLabel.ForeColor = System.Drawing.Color.Black;
                            newLabel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
                            newLabel.Location = new System.Drawing.Point(280, 15 + (cTeam * 55));
                            newLabel.Margin = new System.Windows.Forms.Padding(1);
                            newLabel.Name = "lblTeams" + i;
                            newLabel.Size = new System.Drawing.Size(186, 46);
                            newLabel.TabIndex = 15;
                            newLabel.Text = tlColumns[1];
                            newLabel.teamName = tlColumns[1];
                            newLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            this.Controls.Add(newLabel);
                            this.teams[cTeam] = newLabel;
                            cTeam++;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error Creating Team Labels with the Config File");
            }
        }
        private void GameScreen_SizeChanged(object sender, EventArgs e)
        {
            //Dinamically change the Font Size of the Texts when resizing the screen
            lblTitle.Font = new System.Drawing.Font("Arial", (this.Size.Width * 28 / 800), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            int i = 0;
            foreach (Team team in teams)
                if (team != null)
                {
                    team.Font = new System.Drawing.Font("Arial", (this.Size.Width * 20 / 800), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    team.Location = new System.Drawing.Point((this.Size.Width * 280 / 800), (15 + i + (i * this.Size.Height * 55 / 600)));
                    team.Size = new System.Drawing.Size((this.Size.Width * 186 / 800), (this.Size.Height * 46 / 600));
                    i++;
                }
        }
        private void GameScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            teams = null;
        }
        private void ReadyScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            String keyPressed = e.KeyChar.ToString().ToLower();
            if (keyPressed.Equals("w"))
            {
                if (teamValidating > 1)
                    teamValidating--;
            }
            else if (keyPressed.Equals("r"))
            {
                if (teamValidating < cTeam)
                    teamValidating++;                
            }
            else
            {
                try
                {
                    switch (keyPressed)
                    {
                        case "1": if (teamValidating == 1 && this.teams[0] != null) { highlightTeam(this.teams[0], true); } break;
                        case "2": if (teamValidating == 2 && this.teams[1] != null) { highlightTeam(this.teams[1], true); } break;
                        case "3": if (teamValidating == 3 && this.teams[2] != null) { highlightTeam(this.teams[2], true); } break;
                        case "4": if (teamValidating == 4 && this.teams[3] != null) { highlightTeam(this.teams[3], true); } break;
                        case "5": if (teamValidating == 5 && this.teams[4] != null) { highlightTeam(this.teams[4], true); } break;
                        case "6": if (teamValidating == 6 && this.teams[5] != null) { highlightTeam(this.teams[5], true); } break;
                        case "7": if (teamValidating == 7 && this.teams[6] != null) { highlightTeam(this.teams[6], true); } break;
                        case "8": if (teamValidating == 8 && this.teams[7] != null) { highlightTeam(this.teams[7], true); } break;
                        case "9": if (teamValidating == 9 && this.teams[8] != null) { highlightTeam(this.teams[8], true); } break;
                        case "0": if (teamValidating == 10 && this.teams[9] != null) { highlightTeam(this.teams[9], true); } break;
                        default: break;
                    }
                }
                catch (Exception)
                {
                };
            }
        }
        private void playSound(SoundPlayer sound)
        {
            try
            {
                sound.Play();
            }
            catch (Exception)
            {
            };
        }
        private void highlightTeam(Team team, bool highlighted)
        {
            try
            {
                if (highlighted)
                {
                    playSound(team.sound);
                    team.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(195)))), ((int)(((byte)(106)))));
                    team.ForeColor = System.Drawing.Color.White;
                    team.selected = true;
                }
                else
                {
                    team.BackColor = System.Drawing.Color.White;
                    team.ForeColor = System.Drawing.Color.Black;
                    team.selected = false;
                }
            }
            catch (Exception)
            {
            };
        }
    }
}
