using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace GameShow
{
    public partial class TestScreen : Form
    {
        private Team[] teams = null;
        private int teamValidating = 0;
        private int cTeam = 0;
        private GameColors gameColors = new GameColors();
        internal TestScreen(GameColors gameColors)
        {
            this.gameColors = gameColors;
            InitializeComponent();
            loadTeams();
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
                foreach (String teamLine in teamLines)
                {
                    if (teamLine != "")
                    {
                        String[] tlColumns = teamLine.Contains("\r") ? teamLine.Replace("\r", "").Split('|') : teamLine.Split('|');
                        if (tlColumns[0] == "1")
                        {
                            Team newLabel = new Team(cTeam, false, Team.getKey(cTeam), tlColumns);
                            highlightTeam(newLabel, false);
                            this.teams[cTeam++] = newLabel;
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
            setLayout();
        }
        private void setLayout()
        {
            double fontConstant = Math.Sqrt(Math.Pow(this.Size.Width, 2) + Math.Pow(this.Size.Height, 2)) / 1000;
            this.lblTitle.Font = new System.Drawing.Font("Arial", ((float)fontConstant * 30), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Size = new System.Drawing.Size((426 * this.Size.Width / 800), (88 * this.Size.Height / 600));
            this.lblTitle.Location = new System.Drawing.Point(this.Size.Width / 2 - this.lblTitle.Size.Width / 2, 12);
            //this.lblTeamData
            //this.lblTeamName
            //this.lblTeam
            //this.picAvatar
        }
        private void setTeam()
        {
            unselectTeams();
            if (this.teams[this.teamValidating] != null)
            {
                this.lblTeamName.Text = this.teams[this.teamValidating].teamName;
                this.lblTeam.Text = this.teams[this.teamValidating].teamName;
                this.lblTeamData.Text = this.teams[this.teamValidating].characteristics;
                try
                {
                    this.picAvatar.Image = Image.FromFile("Resources\\" + this.teams[this.teamValidating].avatar + ".png");
                    this.picAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                }
                catch (Exception)
                {
                };
            }
        }
        private void GameScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            teams = null;
        }
        private void ReadyScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            String keyPressed = e.KeyChar.ToString().ToLower();
            if (keyPressed.Equals("u"))
            {
                if (teamValidating > 0)
                {
                    teamValidating--;
                    setTeam();
                }
            }
            else if (keyPressed.Equals("v"))
            {
                if (teamValidating < cTeam - 1)
                {
                    teamValidating++;
                    setTeam();
                }
            }
            else
            {
                try
                {
                    if (this.teams[teamValidating] != null && keyPressed == this.teams[teamValidating].key)
                        highlightTeam(this.teams[teamValidating], true);
                    /*
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
                    */
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
            catch (Exception){};
        }
        private void highlightTeam(Team team, bool highlighted)
        {
            try
            {
                if (highlighted)
                {
                    playSound(team.sound);
                    this.lblTeam.BackColor = gameColors.SelectedBoxFill;
                    this.lblTeam.ForeColor = gameColors.SelectedBoxText;
                    team.selected = true;
                    this.stopWatch.Enabled = true;
                }
            }
            catch (Exception){};
        }
        private void TestScreen_Load(object sender, EventArgs e)
        {
            this.BackColor = gameColors.DefaultBackground;
            this.lblTitle.ForeColor = gameColors.ScreenTitleText;
            this.lblTeamData.ForeColor = gameColors.ScreenTitleText;
            this.lblTeamName.ForeColor = gameColors.ScreenTitleText;
            try
            {
                this.BackgroundImage = Image.FromFile("Resources\\TestBuzzer.png");
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            }
            catch (Exception){};
            unselectTeams();
            setLayout();
            setTeam();
        }
        private void unselectTeams()
        {
            this.lblTeam.BackColor = gameColors.NoSelectBoxFill;
            this.lblTeam.ForeColor = gameColors.NoSelectBoxText;
            try
            {
                foreach (Team team in this.teams)
                {
                    if (team != null) team.selected = false;
                }
            }
            catch (Exception){};
        }
        private void StopWatch_Tick(object sender, EventArgs e)
        {
            unselectTeams();
            stopWatch.Enabled = false;
        }
    }
}
