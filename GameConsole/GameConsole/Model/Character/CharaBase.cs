using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsole.Model.Character
{
    public class CharaBase
    {
        public int HP { get; set; }
        public int Max_HP { get; set; }
        public long FightingPower { get; set; }

        public void Fight(string name)
        {
            System.Console.WriteLine();
        }
    }
}
