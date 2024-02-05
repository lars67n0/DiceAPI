using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceLib
{
    public class Dice
    {
        public int Id { get; set; }
        public int SideAmount { get; set; }
        public string Color { get; set; }

        public void SideVal()
        {
            if(SideAmount < 4 || SideAmount > 20)
            {
                throw new ArgumentOutOfRangeException("Side Amount Need to be between 4 and 20");
            }
        }

        public void ColorVal()
        {
            if (Color.Length < 2)
            {
                throw new ArgumentOutOfRangeException("Color Needs to be a min of 2 chars");
            }
        }

        

    }
}
