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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMainBoxLabel = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.lblSeconds = new System.Windows.Forms.Label();
            this.lblRight = new System.Windows.Forms.Label();
            this.lblWrong = new System.Windows.Forms.Label();
            this.lblSecondsLabel = new System.Windows.Forms.Label();
            this.lblPointsLabel = new System.Windows.Forms.Label();
            this.stopWatch = new System.Windows.Forms.Timer(this.components);
            this.lblTeams = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(195)))), ((int)(((byte)(106)))));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(503, 57);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Question 99";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMainBoxLabel
            // 
            this.lblMainBoxLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMainBoxLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblMainBoxLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMainBoxLabel.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainBoxLabel.Location = new System.Drawing.Point(12, 66);
            this.lblMainBoxLabel.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.lblMainBoxLabel.Name = "lblMainBoxLabel";
            this.lblMainBoxLabel.Size = new System.Drawing.Size(484, 382);
            this.lblMainBoxLabel.TabIndex = 8;
            this.lblMainBoxLabel.Text = "The beaver is the national emblem of which country?";
            this.lblMainBoxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPoints
            // 
            this.lblPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPoints.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPoints.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoints.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(195)))), ((int)(((byte)(106)))));
            this.lblPoints.Location = new System.Drawing.Point(173, 464);
            this.lblPoints.Margin = new System.Windows.Forms.Padding(0);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(92, 61);
            this.lblPoints.TabIndex = 11;
            this.lblPoints.Text = "999";
            this.lblPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSeconds
            // 
            this.lblSeconds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSeconds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSeconds.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeconds.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(195)))), ((int)(((byte)(106)))));
            this.lblSeconds.Location = new System.Drawing.Point(404, 464);
            this.lblSeconds.Margin = new System.Windows.Forms.Padding(0);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(92, 61);
            this.lblSeconds.TabIndex = 13;
            this.lblSeconds.Text = "99";
            this.lblSeconds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRight
            // 
            this.lblRight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRight.BackColor = System.Drawing.Color.Transparent;
            this.lblRight.Font = new System.Drawing.Font("Arial", 200.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(195)))), ((int)(((byte)(106)))));
            this.lblRight.Location = new System.Drawing.Point(12, 66);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(484, 382);
            this.lblRight.TabIndex = 16;
            this.lblRight.Text = "✔";
            this.lblRight.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblWrong
            // 
            this.lblWrong.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblWrong.BackColor = System.Drawing.Color.Transparent;
            this.lblWrong.Font = new System.Drawing.Font("Arial", 200.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWrong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblWrong.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblWrong.Location = new System.Drawing.Point(12, 66);
            this.lblWrong.Name = "lblWrong";
            this.lblWrong.Size = new System.Drawing.Size(484, 382);
            this.lblWrong.TabIndex = 17;
            this.lblWrong.Text = "X";
            this.lblWrong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSecondsLabel
            // 
            this.lblSecondsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSecondsLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblSecondsLabel.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblSecondsLabel.ForeColor = System.Drawing.Color.Black;
            this.lblSecondsLabel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblSecondsLabel.Location = new System.Drawing.Point(288, 464);
            this.lblSecondsLabel.Margin = new System.Windows.Forms.Padding(0);
            this.lblSecondsLabel.Name = "lblSecondsLabel";
            this.lblSecondsLabel.Size = new System.Drawing.Size(105, 61);
            this.lblSecondsLabel.TabIndex = 14;
            this.lblSecondsLabel.Text = "Seconds";
            this.lblSecondsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPointsLabel
            // 
            this.lblPointsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPointsLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblPointsLabel.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblPointsLabel.ForeColor = System.Drawing.Color.Black;
            this.lblPointsLabel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblPointsLabel.Location = new System.Drawing.Point(12, 464);
            this.lblPointsLabel.Margin = new System.Windows.Forms.Padding(0);
            this.lblPointsLabel.Name = "lblPointsLabel";
            this.lblPointsLabel.Size = new System.Drawing.Size(146, 61);
            this.lblPointsLabel.TabIndex = 12;
            this.lblPointsLabel.Text = "Point Value";
            this.lblPointsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stopWatch
            // 
            this.stopWatch.Interval = 1000;
            this.stopWatch.Tick += new System.EventHandler(this.StopWatch_Tick);
            // 
            // lblTeams
            // 
            this.lblTeams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTeams.BackColor = System.Drawing.Color.Transparent;
            this.lblTeams.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeams.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(195)))), ((int)(((byte)(106)))));
            this.lblTeams.Location = new System.Drawing.Point(515, 9);
            this.lblTeams.Margin = new System.Windows.Forms.Padding(0);
            this.lblTeams.Name = "lblTeams";
            this.lblTeams.Size = new System.Drawing.Size(260, 57);
            this.lblTeams.TabIndex = 18;
            this.lblTeams.Text = "Team Scores";
            this.lblTeams.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lblTeams);
            this.Controls.Add(this.lblPointsLabel);
            this.Controls.Add(this.lblSecondsLabel);
            this.Controls.Add(this.lblSeconds);
            this.Controls.Add(this.lblPoints);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblWrong);
            this.Controls.Add(this.lblRight);
            this.Controls.Add(this.lblMainBoxLabel);
            this.Name = "GameScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameScreen_FormClosed);
            this.Load += new System.EventHandler(this.ReadyScreen_Load);
            this.SizeChanged += new System.EventHandler(this.GameScreen_SizeChanged);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ReadyScreen_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMainBoxLabel;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Label lblSeconds;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Label lblWrong;
        private System.Windows.Forms.Label lblSecondsLabel;
        private System.Windows.Forms.Label lblPointsLabel;
        private System.Windows.Forms.Timer stopWatch;
        private System.Windows.Forms.Label lblTeams;
    }
}

