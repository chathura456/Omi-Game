using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pocker_game_demo.support_files
{
    public class Cards
    {
        public enum SUIT
        {
            C,
            S,
            D,
            H
        }

        public enum VALUE
        {
            Seven = 7, Eight = 8, Nine = 9, Ten = 10, J, Q, K, A
        }

        

        public SUIT mySuit { get; set; }
        public VALUE myValue { get; set; }

 

        
    }
}
