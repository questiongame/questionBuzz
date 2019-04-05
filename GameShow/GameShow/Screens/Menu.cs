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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            GameScreen rs = new GameScreen();
            rs.ShowDialog();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void BtnTeams_Click(object sender, EventArgs e)
        {
            TeamsScreen ts = new TeamsScreen();
            ts.ShowDialog();
        }
    }
}
