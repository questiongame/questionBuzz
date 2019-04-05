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
    public partial class TeamsScreen : Form
    {
        private System.Windows.Forms.Label[] lblTeams;
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
            }
            // Here we dinamically create Label for each team on the 
            this.lblTeams = new System.Windows.Forms.Label[teams.Length];
            for (int i = 0; i < teams.Length; i++)
            {
                teams[i] = teams[i].Replace("\r", ""); //Need to remove new line char at end of line. Optionally use System.Environment.NewLine
                this.lblTeams[i] = new System.Windows.Forms.Label();
                this.lblTeams[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.lblTeams[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
        public TeamsScreen()
        {
            loadTeams();
            InitializeComponent();
        }

        private void ReadyScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            String keyPressed = e.KeyChar.ToString();
            if (keyPressed.ToLower().Equals("w"))
            {
                
            }
            else if (keyPressed.ToLower().Equals("r"))
            {
                
            }
            else
            {
                
            }
            //MessageBox.Show(keyPressed);
            return;
        }

        private void ReadyScreen_Load(object sender, EventArgs e)
        {
            
        }
    }
}
