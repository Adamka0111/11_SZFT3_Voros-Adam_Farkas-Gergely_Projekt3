using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMayhem_Lib
{
    public class Enemy
    {
        public Enemy()
        {
            Health = 100;
            Energy = 20;
            PunchLVL = 0;
            BlockLVL = 0;
            DodgeLVL = 0;
            FlexLVL = 0;
            FlexBonus = 0;
            DodgeResult = false;
        }

        public int Health { get; set; }
        public int Energy { get; set; }
        public int PunchLVL { get; set; }
        public int BlockLVL { get; set; }
        public int DodgeLVL { get; set; }
        public int FlexLVL { get; set; }
        public int FlexBonus { get; set; }
        public bool DodgeResult { get; set; }
    }
}
