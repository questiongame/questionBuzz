using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShow
{
    class Question
    {
        internal int questionNumber = 0;
        internal int points = 0;
        internal int time = 0;
        internal String strQuestion = "";
        internal String strAnswer = "";

        public Question(int questionNumber, int points, int time, String strQuestion, String strAnswer)
        {
            this.questionNumber = questionNumber;
            this.points = points;
            this.time = time;
            this.strQuestion = strQuestion;
            this.strAnswer = strAnswer;
        }
    }
}
