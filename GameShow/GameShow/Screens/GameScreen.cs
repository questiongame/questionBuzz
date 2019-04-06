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
        private bool keyboardLocked = false;
        private bool goNextScreen = false;

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
            };
            // Here we dinamically create Label for each team on the 
            this.lblTeams = new System.Windows.Forms.Label[teams.Length];
            for (int i = 0; i < teams.Length; i++)
            {
                teams[i] = teams[i].Replace("\r", ""); //Need to remove new line char at end of line. Optionally use System.Environment.NewLine
                this.lblTeams[i] = new System.Windows.Forms.Label();
                this.lblTeams[i].Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                this.lblTeams[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.lblTeams[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
                if (goNextScreen)
                {
                    nextScreen();
                }
                else
                {
                    markWrong();
                    unlockKeyboard();
                    goNextScreen = true;
                }
            }
            else if (keyPressed.ToLower().Equals("r"))
            {
                if (goNextScreen)
                {
                    nextScreen();
                }
                else
                {
                    markRight();
                    unlockKeyboard();
                    goNextScreen = true;
                }
            }
            else
            {
                if (!keyboardLocked)
                {
                    switch (keyPressed.ToLower())
                    {
                        case "1": highlightTeam(this.lblTeams[0], true); lockKeyboard(); break;
                        case "2": highlightTeam(this.lblTeams[1], true); lockKeyboard(); break;
                        case "3": highlightTeam(this.lblTeams[2], true); lockKeyboard(); break;
                        case "4": highlightTeam(this.lblTeams[3], true); lockKeyboard(); break;
                        case "5": highlightTeam(this.lblTeams[4], true); lockKeyboard(); break;
                        case "6": highlightTeam(this.lblTeams[5], true); lockKeyboard(); break;
                        case "7": highlightTeam(this.lblTeams[6], true); lockKeyboard(); break;
                        case "8": highlightTeam(this.lblTeams[7], true); lockKeyboard(); break;
                        case "9": highlightTeam(this.lblTeams[8], true); lockKeyboard(); break;
                        case "0": highlightTeam(this.lblTeams[9], true); lockKeyboard(); break;
                    }
                }
                hideMarks();
            }
            return;
        }

        private void nextScreen()
        {
            hideMarks();
            unlockKeyboard();
            foreach (Label team in lblTeams)
            {
                highlightTeam(team, false);
            }
        }

        private void hideMarks()
        {
            lblRight.Hide();
            lblWrong.Hide();
        }

        private void markRight()
        {
            lblRight.Show();
            lblWrong.Hide();
        }

        private void markWrong()
        {
            lblRight.Hide();
            lblWrong.Show();
        }

        private void lockKeyboard()
        {
            keyboardLocked = true;
        }

        private void unlockKeyboard()
        {
            keyboardLocked = false;
        }

        private void highlightTeam(Label team, bool highlighted)
        {
            try
            {
                if (highlighted)
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

        private void ReadyScreen_Load(object sender, EventArgs e)
        {
            hideMarks();
            lblRight.Parent = lblMainBoxLabel;
            lblWrong.Parent = lblMainBoxLabel;
            lblRight.Top -= 125;
            lblWrong.Top -= 125;
        }

        private void GameScreen_SizeChanged(object sender, EventArgs e)
        {
            //Dinamically change the Font Size of the Texts when resizing the screen
            lblMainBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", (this.Size.Width * 48 / 800), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", (this.Size.Width * 28 / 800), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblRight.Font = new System.Drawing.Font("Comic Sans MS", (this.Size.Width * 200 / 800), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblWrong.Font = new System.Drawing.Font("Comic Sans MS", (this.Size.Width * 200 / 800), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //lblPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", (this.Size.Width * 27 / 800), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //lblSecondsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", (this.Size.Width * 27 / 800), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
    }
}
