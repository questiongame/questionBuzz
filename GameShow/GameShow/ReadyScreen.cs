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
    public partial class ReadyScreen : Form
    {
        public ReadyScreen()
        {
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
        }
    }
}
