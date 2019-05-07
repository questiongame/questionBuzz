namespace GameShow
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.btnTeams = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTeams
            // 
            this.btnTeams.FlatAppearance.BorderSize = 0;
            this.btnTeams.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeams.Location = new System.Drawing.Point(223, 194);
            this.btnTeams.Name = "btnTeams";
            this.btnTeams.Size = new System.Drawing.Size(320, 69);
            this.btnTeams.TabIndex = 0;
            this.btnTeams.Text = "Enter Team Names";
            this.btnTeams.UseVisualStyleBackColor = false;
            this.btnTeams.Click += new System.EventHandler(this.BtnTeams_Click);
            // 
            // btnTest
            // 
            this.btnTest.FlatAppearance.BorderSize = 0;
            this.btnTest.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.Location = new System.Drawing.Point(223, 304);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(320, 69);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "Test Buzzers";
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // btnStartGame
            // 
            this.btnStartGame.FlatAppearance.BorderSize = 0;
            this.btnStartGame.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartGame.Location = new System.Drawing.Point(223, 415);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(320, 69);
            this.btnStartGame.TabIndex = 2;
            this.btnStartGame.Text = "Begin Game";
            this.btnStartGame.UseVisualStyleBackColor = false;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(223, 59);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(320, 92);
            this.picLogo.TabIndex = 4;
            this.picLogo.TabStop = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnTeams);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Activated += new System.EventHandler(this.Menu_Activated);
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTeams;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.PictureBox picLogo;
    }
}