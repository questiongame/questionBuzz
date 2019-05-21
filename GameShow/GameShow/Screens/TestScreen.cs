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
                cTeam = 0;
                foreach (String teamLine in teamLines)
                {
                    if (teamLine != "")
                    {
                        String[] tlColumns = teamLine.Contains("\r") ? teamLine.Replace("\r", "").Split('|') : teamLine.Split('|');
                        if (tlColumns[0] == "1")
                        {
                            Team newLabel = new Team(cTeam, false, Team.getKey(cTeam), tlColumns);
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
            setTeam();
        }
        private void setLayout()
        {
            double fontConstant = Math.Sqrt(Math.Pow(this.Size.Width, 2) + Math.Pow(this.Size.Height, 2)) / 1000;
            this.lblTitle.Font = new System.Drawing.Font("Arial", ((float)fontConstant * 32), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Size = new System.Drawing.Size((426 * this.Size.Width / 800), (88 * this.Size.Height / 600));
            this.lblTitle.Location = new System.Drawing.Point(9, 12);
            this.lblTeamName.Font = new System.Drawing.Font("Arial", ((float)fontConstant * 24), System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamName.Size = new System.Drawing.Size((426 * this.Size.Width / 800), (61 * this.Size.Height / 600));
            this.lblTeamName.Location = new System.Drawing.Point(9, this.Size.Height / 50 * 9);
            this.lblTeamData.Font = new System.Drawing.Font("Arial", ((float)fontConstant * 22), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamData.Location = new System.Drawing.Point(9, this.Size.Height / 50 * 14);
            this.lblTeamData.Size = new System.Drawing.Size((426 * this.Size.Width / 800), (this.Size.Height - this.lblTeamData.Location.Y - 20));
            this.picAvatar.Location = new System.Drawing.Point(this.lblTitle.Location.X + this.lblTitle.Size.Width + 15, 30);
            this.picAvatar.Size = new System.Drawing.Size((this.Size.Width - this.picAvatar.Location.X - 30), (360 * this.Size.Height / 600));
            this.lblTeam.Font = new System.Drawing.Font("Arial", ((float)fontConstant * 26), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam.Size = new System.Drawing.Size((194 * this.Size.Width / 800), (63 * this.Size.Height / 600));
            this.lblTeam.Location = new System.Drawing.Point(this.picAvatar.Location.X + this.picAvatar.Width / 2 - this.lblTeam.Width / 2, this.picAvatar.Height + 60);
        }
        private void setTeam()
        {
            unselectTeams();
            if (this.teams[this.teamValidating] != null)
            {
                this.lblTeamName.Text = this.lblTeam.Text = this.teams[this.teamValidating].teamName;
                string characteristics = this.teams[this.teamValidating].characteristics;
                string[] characteristicsColumns = characteristics.Contains("\r") ? characteristics.Replace("\r", "").Split('|') : characteristics.Split('|');
                characteristics = "";
                for (int i = 0; i < characteristicsColumns.Length; i++)
                {
                    if (characteristicsColumns[i] != null && characteristicsColumns[i] != "")
                    {
                        if ((i % 2) == 0)
                            characteristics += characteristicsColumns[i] + "\r\n";
                        else
                            characteristics += characteristicsColumns[i] + ": ";
                    }
                }
                this.lblTeamData.Text = characteristics;
                try
                {
                    this.picAvatar.Image = Image.FromFile("Resources\\" + this.teams[this.teamValidating].avatar + ".png");
                    this.picAvatar.Show();
                }
                catch (Exception)
                {
                    try
                    {
                        this.picAvatar.Image = Image.FromFile("Resources\\avatar_no.png");
                        this.picAvatar.Show();
                    }
                    catch (Exception)
                    {
                        this.picAvatar.Hide();
                    };
                };
            }
        }
        private void ReadyScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            String keyPressed = e.KeyChar.ToString().ToLower();
            if (keyPressed.Equals("v"))
            {
                if (teamValidating > 0)
                {
                    teamValidating--;
                    setTeam();
                }
            }//-------------------------------------------------
            else if (keyPressed.Equals("u"))
            {
                if (teamValidating < cTeam - 1)
                {
                    teamValidating++;
                    setTeam();
                }
            }//-------------------------------------------------
            else
            {
                try
                {
                    if (this.teams[teamValidating] != null && keyPressed == this.teams[teamValidating].key)
                        highlightTeam(this.teams[teamValidating]);
                }
                catch (Exception){};
            }
        }
        private void highlightTeam(Team team)
        {
            try
            {
                team.sound.Play();
                this.lblTeam.BackColor = gameColors.SelectedBoxFill;
                this.lblTeam.ForeColor = gameColors.SelectedBoxText;
                this.stopWatch.Enabled = true;
            }
            catch (Exception){};
        }
        private void TestScreen_Load(object sender, EventArgs e)
        {
            this.BackColor = gameColors.DefaultBackground;
            this.lblTitle.ForeColor = gameColors.ScreenTitleText;
            this.lblTeamData.ForeColor = gameColors.ScreenTitleText;
            this.lblTeamName.ForeColor = gameColors.ScreenTitleText;
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            try
            {
                this.BackgroundImage = Image.FromFile("Resources\\TestBuzzer.png");
            }
            catch (Exception){};
            setLayout();
            setTeam();
        }
        private void unselectTeams()
        {
            this.lblTeam.BackColor = gameColors.NoSelectBoxFill;
            this.lblTeam.ForeColor = gameColors.NoSelectBoxText;
        }
        private void StopWatch_Tick(object sender, EventArgs e)
        {
            unselectTeams();
            stopWatch.Enabled = false;
        }
        private void GameScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            teams = null;
        }
    }
}
