using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace GameShow
{
    class Team:Label
    {
        internal SoundPlayer sound = null;
        internal bool selected = false;
        internal int points = 0;
        internal string teamName = "";
        public Team(int teamNumber, bool selected)
        {
            try
            {
                sound = new SoundPlayer("Resources\\team" + (teamNumber + 1).ToString() + ".wav");
                sound.Load();
            }
            catch (Exception)
            {
            };
            this.selected = selected;
        }
    }
}
