using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace GameShow
{
    class GameColors
    {
        internal Color DefaultBackground;
        internal Color ScreenTitleText;
        internal Color MenuBoxFill;
        internal Color MenuBoxText;
        internal Color NoSelectBoxFill;
        internal Color NoSelectBoxText;
        internal Color SelectedBoxFill;
        internal Color SelectedBoxText;
        internal Color TimerPointBoxFill;
        internal Color TimerPointBoxText;
        internal GameColors()
        {
            String[] colorLines = null;
            try
            {
                //this file stores the list of color
                String colorsFile = File.ReadAllText("Resources\\colors.txt");
                colorLines = colorsFile.Split('\n');
            }
            catch (Exception)
            {
                //in case the colors file is not present
                colorLines = new String[10];
                colorLines[0] = "Default Background|167|219|246";
                colorLines[1] = "Screen Title Text|9|89|145";
                colorLines[2] = "Menu Box Fill|9|89|145";
                colorLines[3] = "Menu Box Text|255|255|255";
                colorLines[4] = "No Select Box Fill|255|255|255";
                colorLines[5] = "No Select Box Text|0|0|0";
                colorLines[6] = "Selected Box Fill|9|89|145";
                colorLines[7] = "Selected Box Text|255|255|255";
                colorLines[8] = "Timer-Point Box Fill|255|255|255";
                colorLines[9] = "Timer-Point Box Text|0|0|0";
            };
            //Here we dinamically create a color for each color vault
            foreach (String colorLine in colorLines)
            {
                if (colorLine != "")
                {
                    try
                    {
                        String[] clColumns = colorLine.Contains("\r") ? colorLine.Replace("\r", "").Split('|') : colorLine.Split('|');
                        if (clColumns.Length == 4)
                        {
                            switch (clColumns[0])
                            {
                                case "Default Background": DefaultBackground = Color.FromArgb(Convert.ToInt16(clColumns[1]), Convert.ToInt16(clColumns[2]), Convert.ToInt16(clColumns[3])); break;
                                case "Screen Title Text": ScreenTitleText = Color.FromArgb(Convert.ToInt16(clColumns[1]), Convert.ToInt16(clColumns[2]), Convert.ToInt16(clColumns[3])); break;
                                case "Menu Box Fill": MenuBoxFill = Color.FromArgb(Convert.ToInt16(clColumns[1]), Convert.ToInt16(clColumns[2]), Convert.ToInt16(clColumns[3])); break;
                                case "Menu Box Text": MenuBoxText = Color.FromArgb(Convert.ToInt16(clColumns[1]), Convert.ToInt16(clColumns[2]), Convert.ToInt16(clColumns[3])); break;
                                case "No Select Box Fill": NoSelectBoxFill = Color.FromArgb(Convert.ToInt16(clColumns[1]), Convert.ToInt16(clColumns[2]), Convert.ToInt16(clColumns[3])); break;
                                case "No Select Box Text": NoSelectBoxText = Color.FromArgb(Convert.ToInt16(clColumns[1]), Convert.ToInt16(clColumns[2]), Convert.ToInt16(clColumns[3])); break;
                                case "Selected Box Fill": SelectedBoxFill = Color.FromArgb(Convert.ToInt16(clColumns[1]), Convert.ToInt16(clColumns[2]), Convert.ToInt16(clColumns[3])); break;
                                case "Selected Box Text": SelectedBoxText = Color.FromArgb(Convert.ToInt16(clColumns[1]), Convert.ToInt16(clColumns[2]), Convert.ToInt16(clColumns[3])); break;
                                case "Timer-Point Box Fill": TimerPointBoxFill = Color.FromArgb(Convert.ToInt16(clColumns[1]), Convert.ToInt16(clColumns[2]), Convert.ToInt16(clColumns[3])); break;
                                case "Timer-Point Box Text": TimerPointBoxText = Color.FromArgb(Convert.ToInt16(clColumns[1]), Convert.ToInt16(clColumns[2]), Convert.ToInt16(clColumns[3])); break;
                            }
                        }
                    }
                    catch (Exception)
                    {
                    };
                }
            }
        }
    }
}
