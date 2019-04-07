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
using System.Media;

namespace GameShow
{
    public partial class GameScreen : Form
    {
        private System.Windows.Forms.Label[] lblTeams = null;
        private bool keyboardLocked = false;
        private Question[] questions = null;        
        private int questionIndex = 0;
        private bool questionMarked = false;
        private screen screenShowing = screen.ready;
        private enum screen {ready, question, answer, scores, error};
        private void loadQuestions()
        {
            try
            {
                //this file stores the list of questions
                String[] questionLines = null;
                String questionsFile = File.ReadAllText("questions.txt");
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
        private void drawReadyScreen()
        {
            playSound("ready");
            lblTitle.Text = "Question " + questions[questionIndex].questionNumber.ToString();
            lblMainBoxLabel.Text = "Buuuzzers Readyyy!!!";
            lblPoints.Text = questions[questionIndex].points.ToString();
            lblSeconds.Text = questions[questionIndex].time.ToString();
            hideMarks();
            lockKeyboard();
            foreach (Label team in lblTeams) highlightTeam(team, false);
            screenShowing = screen.ready;
        }
        private void drawQuestionScreen()
        {
            lblTitle.Text = "Question " + questions[questionIndex].questionNumber.ToString();
            lblMainBoxLabel.Text = questions[questionIndex].strQuestion;
            hideMarks();
            foreach (Label team in lblTeams) highlightTeam(team, false);
            screenShowing = screen.question;
            unlockKeyboard();
        }
        private void drawAnswerScreen()
        {
            lblTitle.Text = "Answer " + questions[questionIndex].questionNumber.ToString();
            lblMainBoxLabel.Text = questions[questionIndex].strAnswer;
            hideMarks();
            screenShowing = screen.answer;
            lockKeyboard();
        }
        private void drawErrorScreen()
        {
            lblTitle.Text = "Error";
            lblMainBoxLabel.Text = "Error Reading Questions File";
            lblPoints.Text = "000";
            lblSeconds.Text = "00";
            screenShowing = screen.error;
            lockKeyboard();
        }
        private void drawEndScreen()
        {
            lblTitle.Text = "The End";
            lblMainBoxLabel.Text = "Congratulations!!";
            lblPoints.Text = "100";
            lblSeconds.Text = "00";
            hideMarks();
            foreach (Label team in lblTeams) highlightTeam(team, false);
            screenShowing = screen.scores;
            lockKeyboard();
        }
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
                if (teams[i].Contains("\r"))
                    teams[i] = teams[i].Replace("\r", ""); //Need to remove new line char at end of line. Optionally use System.Environment.NewLine
                this.lblTeams[i] = new System.Windows.Forms.Label();
                this.lblTeams[i].Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                this.lblTeams[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.lblTeams[i].Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
                    questionIndex += 1;
                    if (questionIndex < questions.Length)
                        drawReadyScreen();
                    else
                        drawEndScreen();
                }
            }
            else
            {
                switch (keyPressed)
                {
                    case "1": if (!keyboardLocked) { lockKeyboard(); highlightTeam(this.lblTeams[0], true); } break;
                    case "2": if (!keyboardLocked) { lockKeyboard(); highlightTeam(this.lblTeams[1], true); } break;
                    case "3": if (!keyboardLocked) { lockKeyboard(); highlightTeam(this.lblTeams[2], true); } break;
                    case "4": if (!keyboardLocked) { lockKeyboard(); highlightTeam(this.lblTeams[3], true); } break;
                    case "5": if (!keyboardLocked) { lockKeyboard(); highlightTeam(this.lblTeams[4], true); } break;
                    case "6": if (!keyboardLocked) { lockKeyboard(); highlightTeam(this.lblTeams[5], true); } break;
                    case "7": if (!keyboardLocked) { lockKeyboard(); highlightTeam(this.lblTeams[6], true); } break;
                    case "8": if (!keyboardLocked) { lockKeyboard(); highlightTeam(this.lblTeams[7], true); } break;
                    case "9": if (!keyboardLocked) { lockKeyboard(); highlightTeam(this.lblTeams[8], true); } break;
                    case "0": if (!keyboardLocked) { lockKeyboard(); highlightTeam(this.lblTeams[9], true); } break;
                    default: break;
                }
            }
        }
        [STAThread]
        private void playSound(String sound)
        {
            try
            {
                SoundPlayer simpleSound = new SoundPlayer("Resources\\" + sound + ".wav");
                simpleSound.Play();
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
            playSound("right");
            lblRight.Show();
            lblWrong.Hide();
            questionMarked = true;
            lockKeyboard();
        }
        private void markWrong()
        {
            playSound("wrong");
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
        private void highlightTeam(Label team, bool highlighted)
        {
            try
            {
                if (highlighted)
                {
                    playSound("team1");
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
            lblRight.Parent = lblMainBoxLabel; //Need this to make the Right Label Background Transparent based on the object that is behind
            lblWrong.Parent = lblMainBoxLabel; //Need this to make the Wrong Label Background Transparent based on the object that is behind
            lblRight.Top -= 100; //For some reason the ✔ mark drops to the bottom so this is to realign
            lblWrong.Top -= 100; //For some reason the X mark drops to the bottom so this is to realign
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
        }
        private void GameScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            lblTeams = null;
            questions = null;
        }
    }
}
