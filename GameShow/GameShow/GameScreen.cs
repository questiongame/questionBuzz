using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameShow
{
    public partial class GameScreen : Form
    {
        private System.Windows.Forms.Label[] lblTeams;
        private void loadTeams()
        {
            // 
            // lblTeams
            //
            this.lblTeams = new System.Windows.Forms.Label[10];
            for (int i=0;i<10;i++)
            {
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
                this.lblTeams[i].Text = "John";
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
                lblRight.Hide();
                lblWrong.Show();
            }
            else if (keyPressed.ToLower().Equals("r"))
            {
                lblRight.Show();
                lblWrong.Hide();
            }
            else
            {
                lblRight.Hide();
                lblWrong.Hide();
            }
            //MessageBox.Show(keyPressed);
            return;
        }

        private void ReadyScreen_Load(object sender, EventArgs e)
        {
            lblRight.Hide();
            lblWrong.Hide();
            lblRight.Parent = lblMainBoxLabel;
            lblWrong.Parent = lblMainBoxLabel;
        }
    }
}
