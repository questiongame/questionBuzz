using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace GameShow
{
    class Team : Label
    {
        internal SoundPlayer sound = null;
        internal string strSound = "";
        internal bool selected = false;
        internal int points = 0;
        internal string teamName = "";
        internal int teamNumber = 0;
        internal string avatar = "";
        public Team(int teamNumber, bool selected, string strSound, string avatar)
        {
            try
            {
                this.sound = new SoundPlayer("Resources\\" + strSound + ".wav");
                this.sound.Load();
            }
            catch (Exception)
            {
            };
            this.strSound = strSound;
            this.selected = selected;
            this.teamNumber = teamNumber;
            this.avatar = avatar;
        }
    }
}
