namespace GameShow
{
    partial class TestScreen
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
            this.stopWatch = new System.Windows.Forms.Timer(this.components);
            this.lblTeamData = new System.Windows.Forms.Label();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lblTeam = new System.Windows.Forms.Label();
            this.lblTeamName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(89)))), ((int)(((byte)(145)))));
            this.lblTitle.Location = new System.Drawing.Point(9, 9);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(439, 68);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Test Buzzers";
            // 
            // stopWatch
            // 
            this.stopWatch.Enabled = true;
            this.stopWatch.Tick += new System.EventHandler(this.StopWatch_Tick);
            // 
            // lblTeamData
            // 
            this.lblTeamData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTeamData.BackColor = System.Drawing.Color.Transparent;
            this.lblTeamData.Font = new System.Drawing.Font("Arial", 22F, System.Drawing.FontStyle.Bold);
            this.lblTeamData.Location = new System.Drawing.Point(9, 169);
            this.lblTeamData.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.lblTeamData.Name = "lblTeamData";
            this.lblTeamData.Size = new System.Drawing.Size(443, 369);
            this.lblTeamData.TabIndex = 23;
            this.lblTeamData.Text = "Age: 34\r\nWeight: 120lb\r\nHeight: 5\'6\"";
            // 
            // picAvatar
            // 
            this.picAvatar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picAvatar.BackColor = System.Drawing.Color.Transparent;
            this.picAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.Location = new System.Drawing.Point(458, 30);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(320, 360);
            this.picAvatar.TabIndex = 24;
            this.picAvatar.TabStop = false;
            // 
            // lblTeam
            // 
            this.lblTeam.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTeam.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Bold);
            this.lblTeam.Location = new System.Drawing.Point(517, 421);
            this.lblTeam.Name = "lblTeam";
            this.lblTeam.Size = new System.Drawing.Size(194, 63);
            this.lblTeam.TabIndex = 25;
            this.lblTeam.Text = "John";
            this.lblTeam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTeamName
            // 
            this.lblTeamName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTeamName.BackColor = System.Drawing.Color.Transparent;
            this.lblTeamName.Font = new System.Drawing.Font("Arial", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(89)))), ((int)(((byte)(145)))));
            this.lblTeamName.Location = new System.Drawing.Point(9, 88);
            this.lblTeamName.Margin = new System.Windows.Forms.Padding(0);
            this.lblTeamName.Name = "lblTeamName";
            this.lblTeamName.Size = new System.Drawing.Size(439, 68);
            this.lblTeamName.TabIndex = 26;
            this.lblTeamName.Text = "John";
            // 
            // TestScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lblTeamName);
            this.Controls.Add(this.lblTeam);
            this.Controls.Add(this.picAvatar);
            this.Controls.Add(this.lblTeamData);
            this.Controls.Add(this.lblTitle);
            this.Name = "TestScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameScreen_FormClosed);
            this.Load += new System.EventHandler(this.TestScreen_Load);
            this.SizeChanged += new System.EventHandler(this.GameScreen_SizeChanged);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ReadyScreen_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Timer stopWatch;
        private System.Windows.Forms.Label lblTeamData;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Label lblTeam;
        private System.Windows.Forms.Label lblTeamName;
    }
}

