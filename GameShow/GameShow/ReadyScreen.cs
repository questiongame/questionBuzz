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
                return;
            }
            MessageBox.Show(keyPressed);
            return;
        }
    }
}
