using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pocker_game_demo.support_files2
{
    public class Card
    {
        public string ID { get; set; }
        public string Suit { get; set; }
        public int Value { get; set; }
        public Card(string id, string suit, int vlaue)
        {
            ID = id;
            Suit = suit;
            Value = vlaue;

        }
    }

    public static class CardValues
    {
        public static string[] ids = { "7", "8", "9", "10", "J", "Q", "K", "A" };
        public static string[] suits = { "C", "D", "H", "s" };

        
        public static string[] CardName()
        {
             string[] name;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                   

                }
            }
            return null;
        }


    }

   
}
