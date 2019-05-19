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
        private GameColors gameColors = null;
        private void loadTeams()
        {
            String[] teamLines = null;
            try
            {
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
                this.teams = new Team[teamLines.Length];
                int cTeam = 0;
                foreach (String teamLine in teamLines)
                {
                    if (teamLine != "")
                    {
                        String[] tlColumns = teamLine.Contains("\r") ? teamLine.Replace("\r", "").Split('|') : teamLine.Split('|');
                        if (tlColumns.Length >= 4)
                        {
                            Team newLabel = new Team(cTeam, tlColumns[0] == "1", Team.getKey(cTeam), tlColumns);
                            newLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                            newLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            newLabel.Click += new System.EventHandler(this.Label_Click);
                            this.Controls.Add(newLabel);
                            highlightTeam(newLabel);
                            this.teams[cTeam++] = newLabel;
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
                    team.BackColor = gameColors.SelectedBoxFill;
                    team.ForeColor = gameColors.SelectedBoxText;
                }
                else
                {
                    team.BackColor = gameColors.NoSelectBoxFill;
                    team.ForeColor = gameColors.NoSelectBoxText;
                }
            }
            catch (Exception){};
        }
        internal TeamsScreen(GameColors gameColors)
        {
            this.gameColors = gameColors;
            InitializeComponent();
            loadTeams();
            setLayout();
        }
        private void Label_Click(object sender, EventArgs e)
        {
            Team team = sender as Team;
            team.selected = !team.selected;
            highlightTeam(team);
        }
        private void ReadyScreen_Load(object sender, EventArgs e)
        {
            this.BackColor = gameColors.DefaultBackground;
            this.lblTitle.ForeColor = gameColors.ScreenTitleText;
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
                File.Delete("Resources\\teams.txt");
                using (StreamWriter teamsFile = new StreamWriter("Resources\\teams.txt"))
                {
                    foreach (Team team in this.teams)
                    {
                        if (team != null)
                            teamsFile.WriteLine((team.selected?"1":"0") + "|" + team.teamName + "|" + team.strSound + "|" + team.avatar + team.characteristics);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error writing changes to teams.txt");
            };
        }
        private void TeamsScreen_SizeChanged(object sender, EventArgs e)
        {
            setLayout();
        }
        private void setLayout()
        {
            double fontConstant = Math.Sqrt(Math.Pow(this.Size.Width, 2) + Math.Pow(this.Size.Height, 2)) / 1000;
            this.lblTitle.Font = new System.Drawing.Font("Arial", ((float)fontConstant * 30), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Size = new System.Drawing.Size((426 * this.Size.Width / 800), (88 * this.Size.Height / 600));
            this.lblTitle.Location = new System.Drawing.Point(this.Size.Width / 2 - this.lblTitle.Size.Width / 2, 12);
            int x = 0, y = 0;
            foreach (Team team in this.teams)
                if (team != null)
                {
                    team.Font = new System.Drawing.Font("Arial", ((float)fontConstant * 20), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    team.Size = new System.Drawing.Size((this.Size.Width * 140 / 800), (this.Size.Height * 40 / 600));
                    team.Location = new System.Drawing.Point(50 + (x * this.Size.Width * 170 / 800), (120 + (y++ * this.Size.Height * 55 / 600)));
                    if (y > 6) { x++; y = 0; }
                }
        }
    }
}
