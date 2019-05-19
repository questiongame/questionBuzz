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
        internal string key = "";
        internal string characteristics = "";
        public Team(int teamNumber, bool selected, string key, string[] teamColumns)
        {
            this.teamName = teamColumns[1];
            this.strSound = teamColumns[2];
            this.avatar = teamColumns[3];
            this.teamNumber = teamNumber;
            this.selected = selected;
            this.key = key;
            for (int i = 4; i < teamColumns.Length; i++) this.characteristics += "|" + teamColumns[i];//used to load all the characteristics into a single field
            try
            {
                this.sound = new SoundPlayer("Resources\\" + this.strSound + ".wav");
                this.sound.Load();
            }
            catch (Exception){};
        }
        static internal string getKey(int cTeam)
        {
            if (cTeam >= 0 && cTeam < 9)
                return (cTeam + 1).ToString();
            else if (cTeam == 9)
                return "0";
            else
                return "error";
        }
    }
}
