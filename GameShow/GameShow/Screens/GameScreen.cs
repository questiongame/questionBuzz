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
        private int timeRemaining = 0;
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
                teamLines[0] = "1|John|sound1|avatar1";
                teamLines[1] = "1|Mary|sound2|avatar2";
                teamLines[2] = "1|Carol|sound3|avatar3";
                teamLines[3] = "1|Ken|sound4|avatar4";
            };
            try
            {
                // Here we dinamically create Label for each team on the 
                this.teams = new Team[teamLines.Length];
                int cTeam = 0;
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
                            newLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                            newLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                            newLabel.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            newLabel.ForeColor = System.Drawing.Color.Black;
                            newLabel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
                            newLabel.Location = new System.Drawing.Point(586, 12 + (cTeam * 55));
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
                        case "1": if (!keyboardLocked && this.teams[0] != null) { highlightTeam(this.teams[0], true); lockKeyboard(); } break;
                        case "2": if (!keyboardLocked && this.teams[1] != null) { highlightTeam(this.teams[1], true); lockKeyboard(); } break;
                        case "3": if (!keyboardLocked && this.teams[2] != null) { highlightTeam(this.teams[2], true); lockKeyboard(); } break;
                        case "4": if (!keyboardLocked && this.teams[3] != null) { highlightTeam(this.teams[3], true); lockKeyboard(); } break;
                        case "5": if (!keyboardLocked && this.teams[4] != null) { highlightTeam(this.teams[4], true); lockKeyboard(); } break;
                        case "6": if (!keyboardLocked && this.teams[5] != null) { highlightTeam(this.teams[5], true); lockKeyboard(); } break;
                        case "7": if (!keyboardLocked && this.teams[6] != null) { highlightTeam(this.teams[6], true); lockKeyboard(); } break;
                        case "8": if (!keyboardLocked && this.teams[7] != null) { highlightTeam(this.teams[7], true); lockKeyboard(); } break;
                        case "9": if (!keyboardLocked && this.teams[8] != null) { highlightTeam(this.teams[8], true); lockKeyboard(); } break;
                        case "0": if (!keyboardLocked && this.teams[9] != null) { highlightTeam(this.teams[9], true); lockKeyboard(); } break;
                        default: break;
                    }
                }
                catch (Exception)
                {
                    //unlockKeyboard();
                };
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
            timeRemaining = 0;
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
            lblScores.Text = "";
            string strScores = "";
            foreach (Team team in teams)
            {
                if (team != null)
                {
                    string spaces = " ";
                    for (int i = 1; i < (15 - team.teamName.Length - team.points.ToString().Length); i++)
                        spaces += " ";
                    strScores += team.teamName + spaces + team.points + " points" + '\n';
                }
            }
            lblScores.Text = strScores;
            scoresPanel.Show();
            screenShowing = screen.scores;
            lockKeyboard();
        }
        private void drawErrorScreen()
        {
            scoresPanel.Hide();
            lblTitle.Text = "Error";
            lblMainBoxLabel.Text = "Error Reading Questions File";
            lblPoints.Text = "---";
            lblSeconds.Text = "--";
            screenShowing = screen.error;
            lockKeyboard();
        }
        private void drawEndScreen()
        {
            scoresPanel.Hide();
            lblTitle.Text = "The End";
            lblSeconds.Text = "--";
            hideMarks();
            Team maxPoints = null;
            foreach (Team team in this.teams)
            {
                highlightTeam(team, false);
                if (team != null && (maxPoints == null || maxPoints.points < team.points))
                    maxPoints = team;
            }
            if (maxPoints != null)
            {
                lblMainBoxLabel.Text = "Congratulations!!" + '\n' + maxPoints.teamName;
                lblPoints.Text = maxPoints.points.ToString();
                highlightTeam(maxPoints, true);
                lockKeyboard();
            }
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
            stopWatch.Enabled = false;
            foreach (Team team in teams)
            {
                if (team !=null && team.selected)
                    team.points += questions[questionIndex].points;
            }
        }
        private void markWrong()
        {
            playSound(wrongSound);
            lblRight.Hide();
            lblWrong.Show();
            questionMarked = true;
            lockKeyboard();
            stopWatch.Enabled = false;
            foreach (Team team in teams)
            {
                if (team != null && team.selected)
                    team.points -= questions[questionIndex].points;
            }
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
                    team.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(195)))), ((int)(((byte)(106)))));
                    team.ForeColor = System.Drawing.Color.White;
                    team.selected = true;
                    timeRemaining = questions[questionIndex].time;
                    stopWatch.Enabled = true;
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
                if (screenShowing == screen.question && team == null)
                    unlockKeyboard();
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
            lblScores.Font = new System.Drawing.Font("Lucida Console", (this.Size.Width * 25 / 800), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            int i = 0;
            foreach (Team team in teams)
                if (team != null)
                {
                    team.Location = new System.Drawing.Point(team.Location.X, (12 + (i * this.Size.Height * 55 / 600)));
                    team.Size = new System.Drawing.Size(team.Size.Width, (this.Size.Height * 46 / 600));
                    i++;
                }
        }
        private void GameScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            teams = null;
            questions = null;
        }
        private void StopWatch_Tick(object sender, EventArgs e)
        {
            if (screenShowing == screen.question)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining--;
                    lblSeconds.Text = timeRemaining.ToString();
                }
                else
                {
                    stopWatch.Enabled = false;
                }
            }
        }
    }
}
