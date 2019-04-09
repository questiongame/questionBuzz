using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace GameShow
{
    class Team
    {
        internal Label lblTeam = null;
        internal SoundPlayer sound = null;
        internal int points = 0;
        public Team(Label lblTeam, int teamNumber)
        {
            this.lblTeam = lblTeam;
            try
            {
                sound = new SoundPlayer("Resources\\team" + (teamNumber + 1).ToString() + ".wav");
                sound.Load();
            }
            catch (Exception)
            {
            };
        }
    }
}
