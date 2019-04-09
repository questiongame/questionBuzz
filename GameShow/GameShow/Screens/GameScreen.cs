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
    public partial class GameScreen : Form
    {
        private Team[] teams = null;
        private bool keyboardLocked = false;
        private Question[] questions = null;        
        private int questionIndex = 0;
        private bool questionMarked = false;
        private screen screenShowing = screen.ready;
        private SoundPlayer rightSound = null;
        private SoundPlayer wrongSound = null;
        private SoundPlayer readySound = null;
        private enum screen {ready, question, answer, scores, error};
        private void loadQuestions()
        {
            try
            {
                //this file stores the list of questions
                String[] questionLines = null;
                String questionsFile = File.ReadAllText("Resources\\questions.txt");
                questionLines = questionsFile.Split('\n');
                questions = new Question[questionLines.Length];
                for (int i = 0; i < questionLines.Length; i++)
                {
                    if (questionLines[i].Contains("\r"))
                        questionLines[i] = questionLines[i].Replace("\r", "");
                    String[] qlColumns = questionLines[i].Split('|');
                    questions[i] = new Question(
                        Convert.ToInt32(qlColumns[0]), 
                        Convert.ToInt32(qlColumns[1]), 
                        Convert.ToInt32(qlColumns[2]), 
                        qlColumns[3], 
                        qlColumns[4]
                        );
                }
                drawReadyScreen();
            }
            catch (Exception)
            {
                drawErrorScreen();
            };
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
                teamLines[0] = "John";
                teamLines[1] = "Mary";
                teamLines[2] = "Carol";
                teamLines[3] = "Ken";
            };
            // Here we dinamically create Label for each team on the 
            this.teams = new Team[teamLines.Length];
            for (int i = 0; i < teamLines.Length; i++)
            {
                if (teamLines[i].Contains("\r"))
                    teamLines[i] = teamLines[i].Replace("\r", ""); //Need to remove new line char at end of line. Optionally use System.Environment.NewLine
                Label newLabel = new System.Windows.Forms.Label();
                newLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                newLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                newLabel.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                newLabel.ForeColor = System.Drawing.Color.Black;
                newLabel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
                newLabel.Location = new System.Drawing.Point(586, 12 + (i * 55));
                newLabel.Margin = new System.Windows.Forms.Padding(1);
                newLabel.Name = "lblTeams" + i;
                newLabel.Size = new System.Drawing.Size(186, 46);
                newLabel.TabIndex = 15;
                newLabel.Text = teamLines[i];
                newLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.Controls.Add(newLabel);
                this.teams[i] = new Team(newLabel, i);
            }
        }
        private void loadSounds()
        {
            try
            {
                rightSound = new SoundPlayer("Resources\\right.wav");
                wrongSound = new SoundPlayer("Resources\\wrong.wav");
                readySound = new SoundPlayer("Resources\\ready.wav");
                rightSound.Load();
                wrongSound.Load();
                readySound.Load();
            }
            catch (Exception)
            {
            };
        }
        public GameScreen()
        {
            loadSounds();
            loadTeams();
            InitializeComponent();
            loadQuestions();
        }
        private void ReadyScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            String keyPressed = e.KeyChar.ToString().ToLower();
            if (keyPressed.Equals("w"))
            {
                if (screenShowing == screen.ready)
                {
                    drawQuestionScreen();
                }
                else if (screenShowing == screen.question)
                {
                    if (questionMarked)
                    {
                        drawAnswerScreen();
                    }
                    else
                    {
                        markWrong();
                    }
                }
                else if (screenShowing == screen.answer)
                {
                    drawScoresScreen();
                }
                else if (screenShowing == screen.scores)
                {
                    questionIndex += 1; //This can be removed if another team will be allowed to answer
                    if (questionIndex < questions.Length)
                        drawReadyScreen();
                    else
                        drawEndScreen();
                }
            }
            else if (keyPressed.Equals("r"))
            {
                if (screenShowing == screen.ready)
                {
                    drawQuestionScreen();
                }
                else if (screenShowing == screen.question)
                {
                    if (questionMarked)
                    {
                        drawAnswerScreen();
                    }
                    else
                    {
                        markRight();
                        //add points to team
                    }
                }
                else if (screenShowing == screen.answer)
                {
                    drawScoresScreen();
                }
                else if (screenShowing == screen.scores)
                {
                    questionIndex += 1;
                    if (questionIndex < questions.Length)
                        drawReadyScreen();
                    else
                        drawEndScreen();
                }
            }
            else
            {
                try
                {
                    switch (keyPressed)
                    {
                        case "1": if (!keyboardLocked) { lockKeyboard(); highlightTeam(this.teams[0], true); } break;
                        case "2": if (!keyboardLocked) { lockKeyboard(); highlightTeam(this.teams[1], true); } break;
                        case "3": if (!keyboardLocked) { lockKeyboard(); highlightTeam(this.teams[2], true); } break;
                        case "4": if (!keyboardLocked) { lockKeyboard(); highlightTeam(this.teams[3], true); } break;
                        case "5": if (!keyboardLocked) { lockKeyboard(); highlightTeam(this.teams[4], true); } break;
                        case "6": if (!keyboardLocked) { lockKeyboard(); highlightTeam(this.teams[5], true); } break;
                        case "7": if (!keyboardLocked) { lockKeyboard(); highlightTeam(this.teams[6], true); } break;
                        case "8": if (!keyboardLocked) { lockKeyboard(); highlightTeam(this.teams[7], true); } break;
                        case "9": if (!keyboardLocked) { lockKeyboard(); highlightTeam(this.teams[8], true); } break;
                        case "0": if (!keyboardLocked) { lockKeyboard(); highlightTeam(this.teams[9], true); } break;
                        default: break;
                    }
                }
                catch (Exception)
                {
                    unlockKeyboard();
                }
            }
        }        
        private void drawReadyScreen()
        {
            scoresPanel.Hide();
            playSound(readySound);
            lblTitle.Text = "Question " + questions[questionIndex].questionNumber.ToString();
            lblMainBoxLabel.Text = "Buuuzzers Readyyy!!!";
            lblPoints.Text = questions[questionIndex].points.ToString();
            lblSeconds.Text = questions[questionIndex].time.ToString();
            hideMarks();
            lockKeyboard();
            foreach (Team team in this.teams) highlightTeam(team, false);
            screenShowing = screen.ready;
        }
        private void drawQuestionScreen()
        {
            scoresPanel.Hide();
            lblTitle.Text = "Question " + questions[questionIndex].questionNumber.ToString();
            lblMainBoxLabel.Text = questions[questionIndex].strQuestion;
            hideMarks();
            foreach (Team team in this.teams) highlightTeam(team, false);
            screenShowing = screen.question;
            unlockKeyboard();
        }
        private void drawAnswerScreen()
        {
            scoresPanel.Hide();
            lblTitle.Text = "Answer " + questions[questionIndex].questionNumber.ToString();
            lblMainBoxLabel.Text = questions[questionIndex].strAnswer;
            hideMarks();
            screenShowing = screen.answer;
            lockKeyboard();
        }
        private void drawScoresScreen()
        {
            scoresPanel.Show();
            screenShowing = screen.scores;
            lockKeyboard();
        }
        private void drawErrorScreen()
        {
            scoresPanel.Hide();
            lblTitle.Text = "Error";
            lblMainBoxLabel.Text = "Error Reading Questions File";
            lblPoints.Text = "000";
            lblSeconds.Text = "00";
            screenShowing = screen.error;
            lockKeyboard();
        }
        private void drawEndScreen()
        {
            scoresPanel.Hide();
            lblTitle.Text = "The End";
            lblMainBoxLabel.Text = "Congratulations!!";
            lblPoints.Text = "100";
            lblSeconds.Text = "00";
            hideMarks();
            foreach (Team team in this.teams) highlightTeam(team, false);
            screenShowing = screen.scores;
            lockKeyboard();
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
        private void hideMarks()
        {
            lblRight.Hide();
            lblWrong.Hide();
            questionMarked = false;
        }
        private void markRight()
        {
            playSound(rightSound);
            lblRight.Show();
            lblWrong.Hide();
            questionMarked = true;
            lockKeyboard();
        }
        private void markWrong()
        {
            playSound(wrongSound);
            lblRight.Hide();
            lblWrong.Show();
            questionMarked = true;
            lockKeyboard();
        }
        private void lockKeyboard()
        {
            keyboardLocked = true;
        }
        private void unlockKeyboard()
        {
            keyboardLocked = false;
        }
        private void highlightTeam(Team team, bool highlighted)
        {
            try
            {
                if (highlighted)
                {
                    playSound(team.sound);
                    team.lblTeam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(195)))), ((int)(((byte)(106)))));
                    team.lblTeam.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    team.lblTeam.BackColor = System.Drawing.Color.White;
                    team.lblTeam.ForeColor = System.Drawing.Color.Black;
                }
            }
            catch (Exception)
            {
            };
        }
        private void ReadyScreen_Load(object sender, EventArgs e)
        {
            hideMarks();
            lblRight.Parent = lblMainBoxLabel; //Need this to make the Right Label Background Transparent based on the object that is behind
            lblWrong.Parent = lblMainBoxLabel; //Need this to make the Wrong Label Background Transparent based on the object that is behind
            lblRight.Top -= 50; //For some reason the ✔ mark drops to the bottom so this is to realign
            lblWrong.Top -= 100; //For some reason the X mark drops to the bottom so this is to realign
            scoresPanel.BringToFront();
        }
        private void GameScreen_SizeChanged(object sender, EventArgs e)
        {
            //Dinamically change the Font Size of the Texts when resizing the screen
            lblMainBoxLabel.Font = new System.Drawing.Font("Arial", (this.Size.Width * 48 / 800), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTitle.Font = new System.Drawing.Font("Arial", (this.Size.Width * 28 / 800), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblRight.Font = new System.Drawing.Font("Arial", (this.Size.Width * 200 / 800), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblWrong.Font = new System.Drawing.Font("Arial", (this.Size.Width * 200 / 800), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //lblPoints.Font = new System.Drawing.Font("Arial", (this.Size.Width * 27 / 800), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //lblSecondsLabel.Font = new System.Drawing.Font("Arial", (this.Size.Width * 27 / 800), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblScoresScreen.Font = new System.Drawing.Font("Arial", (this.Size.Width * 28 / 800), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblScores.Font = new System.Drawing.Font("Arial", (this.Size.Width * 20 / 800), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
        private void GameScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            teams = null;
            questions = null;
        }
    }
}
