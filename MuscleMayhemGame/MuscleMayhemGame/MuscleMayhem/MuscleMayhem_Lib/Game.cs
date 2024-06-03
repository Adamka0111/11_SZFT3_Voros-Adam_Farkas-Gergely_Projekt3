using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMayhem_Lib
{
    public class Game
    {
        public Game()
        {
            Stage = 0;
            Room = 0;
            Boss = false;
            HasItem = false;
            CurrentItem = 0;
        }

        public int Stage { get; set; }
        public int Room { get; set; }
        public bool Boss { get; set; }
        public bool HasItem { get; set; }
        public int CurrentItem { get; set; }
    }
}
