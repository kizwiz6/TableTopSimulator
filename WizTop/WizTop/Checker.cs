using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizTop
{
    public class Checker
    {
        public string symbol;
        public int[] position;
        public string color;

        public Checker(string colour, int[] position)
        {
            int circleId;
            string name;

            if (colour == "white")
            {
                circleId = int.Parse(" 3", System.Globalization.NumberStyles.HexNumber); //25CE
                Colour = "white";
            }
            else
            {
                circleId = int.Parse("23", System.Globalization.NumberStyles.HexNumber); // 25C9
                Colour = "black";
            }
            Symbol = char.ConvertFromUtf32(circleId);
            Position = position;
        }



        public string Symbol { get; set; }

        public int[] Position { get; set; }

        public string Colour { get; set; }

    }
}
