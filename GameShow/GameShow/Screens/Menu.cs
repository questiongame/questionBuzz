﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace GameShow
{
    public partial class Menu : Form
    {
        private bool musicPlaying = false;
        private SoundPlayer simpleSound = null;
        private GameColors gameColors = new GameColors();
        public Menu()
        {
            playSound("menu");
            InitializeComponent();
        }
        [STAThread]
        private void playSound(String sound)
        {
            try
            {
                if (simpleSound == null) simpleSound = new SoundPlayer("Resources\\" + sound + ".wav");
                simpleSound.Play();
                musicPlaying = true;
            }
            catch (Exception)
            {
            };
        }
        private void loadColors()
        {
            this.BackColor = gameColors.DefaultBackground;
            this.btnTeams.BackColor = gameColors.MenuBoxFill;
            this.btnTeams.ForeColor = gameColors.MenuBoxText;
            this.btnTest.BackColor = gameColors.MenuBoxFill;
            this.btnTest.ForeColor = gameColors.MenuBoxText;
            this.btnStartGame.BackColor = gameColors.MenuBoxFill;
            this.btnStartGame.ForeColor = gameColors.MenuBoxText;
        }
        private void BtnTeams_Click(object sender, EventArgs e)
        {
            TeamsScreen ts = new TeamsScreen(gameColors);
            ts.ShowDialog();
        }
        private void BtnTest_Click(object sender, EventArgs e)
        {
            musicPlaying = false;
            TestScreen ts = new TestScreen();
            ts.ShowDialog();
        }
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            musicPlaying = false;
            GameScreen rs = new GameScreen();
            rs.ShowDialog();
        }
        private void Menu_Activated(object sender, EventArgs e)
        {
            if (!musicPlaying) playSound("menu");
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            loadColors();
            try
            {
                this.BackgroundImage = Image.FromFile("Resources\\MainMenu.png");
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            }
            catch (Exception)
            {
            };
        }
        private void Menu_SizeChanged(object sender, EventArgs e)
        {
            double fontConstant = Math.Sqrt(Math.Pow(this.Size.Width, 2) + Math.Pow(this.Size.Height, 2)) / 1000;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", ((float)fontConstant * 28), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Size = new System.Drawing.Size(426, 88);
            this.btnTeams.Font = new System.Drawing.Font("Arial", (float)(fontConstant * 22), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeams.Size = new System.Drawing.Size(320, 69);
            this.btnTest.Font = new System.Drawing.Font("Arial", (float)(fontConstant * 22), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.Size = new System.Drawing.Size(320, 69);
            this.btnStartGame.Font = new System.Drawing.Font("Arial", (float)(fontConstant * 22), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartGame.Size = new System.Drawing.Size(320, 69);

        }
    }
}
