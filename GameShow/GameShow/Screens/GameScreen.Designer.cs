namespace GameShow
{
    partial class GameScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameScreen));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMainBoxLabel = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.lblSeconds = new System.Windows.Forms.Label();
            this.lblRight = new System.Windows.Forms.Label();
            this.lblWrong = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblSecondsLabel = new System.Windows.Forms.Label();
            this.lblPointsLabel = new System.Windows.Forms.Label();
            this.stopWatch = new System.Windows.Forms.Timer(this.components);
            this.picScoresLogo = new System.Windows.Forms.PictureBox();
            this.lblScoresScreen = new System.Windows.Forms.Label();
            this.lblScores = new System.Windows.Forms.Label();
            this.scoresPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScoresLogo)).BeginInit();
            this.scoresPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(195)))), ((int)(((byte)(106)))));
            this.lblTitle.Location = new System.Drawing.Point(101, 12);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(291, 88);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Question 99";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMainBoxLabel
            // 
            this.lblMainBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMainBoxLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMainBoxLabel.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainBoxLabel.Location = new System.Drawing.Point(12, 119);
            this.lblMainBoxLabel.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.lblMainBoxLabel.Name = "lblMainBoxLabel";
            this.lblMainBoxLabel.Size = new System.Drawing.Size(568, 433);
            this.lblMainBoxLabel.TabIndex = 8;
            this.lblMainBoxLabel.Text = "The beaver is the national emblem of which country?";
            this.lblMainBoxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPoints
            // 
            this.lblPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPoints.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPoints.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoints.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(195)))), ((int)(((byte)(106)))));
            this.lblPoints.Location = new System.Drawing.Point(394, 12);
            this.lblPoints.Margin = new System.Windows.Forms.Padding(0);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(92, 88);
            this.lblPoints.TabIndex = 11;
            this.lblPoints.Text = "999";
            this.lblPoints.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSeconds
            // 
            this.lblSeconds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSeconds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSeconds.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeconds.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(195)))), ((int)(((byte)(106)))));
            this.lblSeconds.Location = new System.Drawing.Point(488, 12);
            this.lblSeconds.Margin = new System.Windows.Forms.Padding(0);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(92, 88);
            this.lblSeconds.TabIndex = 13;
            this.lblSeconds.Text = "99";
            this.lblSeconds.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblRight
            // 
            this.lblRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRight.BackColor = System.Drawing.Color.Transparent;
            this.lblRight.Font = new System.Drawing.Font("Arial", 200.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(195)))), ((int)(((byte)(106)))));
            this.lblRight.Location = new System.Drawing.Point(12, 119);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(568, 433);
            this.lblRight.TabIndex = 16;
            this.lblRight.Text = "✔";
            this.lblRight.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblWrong
            // 
            this.lblWrong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWrong.BackColor = System.Drawing.Color.Transparent;
            this.lblWrong.Font = new System.Drawing.Font("Arial", 200.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWrong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblWrong.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblWrong.Location = new System.Drawing.Point(12, 119);
            this.lblWrong.Name = "lblWrong";
            this.lblWrong.Size = new System.Drawing.Size(568, 433);
            this.lblWrong.TabIndex = 17;
            this.lblWrong.Text = "X";
            this.lblWrong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(12, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(85, 85);
            this.picLogo.TabIndex = 18;
            this.picLogo.TabStop = false;
            this.picLogo.Visible = false;
            // 
            // lblSecondsLabel
            // 
            this.lblSecondsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSecondsLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecondsLabel.ForeColor = System.Drawing.Color.Black;
            this.lblSecondsLabel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblSecondsLabel.Location = new System.Drawing.Point(497, 79);
            this.lblSecondsLabel.Margin = new System.Windows.Forms.Padding(0);
            this.lblSecondsLabel.Name = "lblSecondsLabel";
            this.lblSecondsLabel.Size = new System.Drawing.Size(74, 18);
            this.lblSecondsLabel.TabIndex = 14;
            this.lblSecondsLabel.Text = "Seconds";
            this.lblSecondsLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblPointsLabel
            // 
            this.lblPointsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPointsLabel.BackColor = System.Drawing.Color.White;
            this.lblPointsLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsLabel.ForeColor = System.Drawing.Color.Black;
            this.lblPointsLabel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblPointsLabel.Location = new System.Drawing.Point(403, 79);
            this.lblPointsLabel.Margin = new System.Windows.Forms.Padding(0);
            this.lblPointsLabel.Name = "lblPointsLabel";
            this.lblPointsLabel.Size = new System.Drawing.Size(74, 18);
            this.lblPointsLabel.TabIndex = 12;
            this.lblPointsLabel.Text = "Points";
            this.lblPointsLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // stopWatch
            // 
            this.stopWatch.Interval = 1000;
            this.stopWatch.Tick += new System.EventHandler(this.StopWatch_Tick);
            // 
            // picScoresLogo
            // 
            this.picScoresLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picScoresLogo.Image = ((System.Drawing.Image)(resources.GetObject("picScoresLogo.Image")));
            this.picScoresLogo.Location = new System.Drawing.Point(440, 12);
            this.picScoresLogo.Name = "picScoresLogo";
            this.picScoresLogo.Size = new System.Drawing.Size(320, 92);
            this.picScoresLogo.TabIndex = 20;
            this.picScoresLogo.TabStop = false;
            // 
            // lblScoresScreen
            // 
            this.lblScoresScreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScoresScreen.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoresScreen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(195)))), ((int)(((byte)(106)))));
            this.lblScoresScreen.Location = new System.Drawing.Point(9, 12);
            this.lblScoresScreen.Margin = new System.Windows.Forms.Padding(0);
            this.lblScoresScreen.Name = "lblScoresScreen";
            this.lblScoresScreen.Size = new System.Drawing.Size(291, 92);
            this.lblScoresScreen.TabIndex = 21;
            this.lblScoresScreen.Text = "Scoreboard";
            this.lblScoresScreen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblScores
            // 
            this.lblScores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScores.Font = new System.Drawing.Font("Lucida Console", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScores.Location = new System.Drawing.Point(57, 118);
            this.lblScores.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.lblScores.Name = "lblScores";
            this.lblScores.Size = new System.Drawing.Size(568, 430);
            this.lblScores.TabIndex = 22;
            this.lblScores.Text = "Team 1  999 points\r\nTeam 2  999 points\r\nTeam 3  999 points\r\nTeam 4  999 points\r\nT" +
    "eam 5  999 points\r\nTeam 6  999 points\r\nTeam 7  999 points\r\nTeam 8  999 points\r\nT" +
    "eam 9  999 points\r\nTeam 10 999 points";
            this.lblScores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // scoresPanel
            // 
            this.scoresPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scoresPanel.Controls.Add(this.lblScores);
            this.scoresPanel.Controls.Add(this.lblScoresScreen);
            this.scoresPanel.Controls.Add(this.picScoresLogo);
            this.scoresPanel.Location = new System.Drawing.Point(0, 1);
            this.scoresPanel.Name = "scoresPanel";
            this.scoresPanel.Size = new System.Drawing.Size(784, 559);
            this.scoresPanel.TabIndex = 19;
            this.scoresPanel.Visible = false;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lblPointsLabel);
            this.Controls.Add(this.lblSecondsLabel);
            this.Controls.Add(this.lblSeconds);
            this.Controls.Add(this.lblPoints);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblWrong);
            this.Controls.Add(this.lblRight);
            this.Controls.Add(this.lblMainBoxLabel);
            this.Controls.Add(this.scoresPanel);
            this.Name = "GameScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameScreen_FormClosed);
            this.Load += new System.EventHandler(this.ReadyScreen_Load);
            this.SizeChanged += new System.EventHandler(this.GameScreen_SizeChanged);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ReadyScreen_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScoresLogo)).EndInit();
            this.scoresPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMainBoxLabel;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Label lblSeconds;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Label lblWrong;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblSecondsLabel;
        private System.Windows.Forms.Label lblPointsLabel;
        private System.Windows.Forms.Timer stopWatch;
        private System.Windows.Forms.PictureBox picScoresLogo;
        private System.Windows.Forms.Label lblScoresScreen;
        private System.Windows.Forms.Label lblScores;
        private System.Windows.Forms.Panel scoresPanel;
    }
}

