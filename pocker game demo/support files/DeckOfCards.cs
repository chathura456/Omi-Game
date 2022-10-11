using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pocker_game_demo.support_files
{
    public class DeckOfCards : Cards
    {
        //number of all cards
        const int NUM_OF_CARDS = 32;

        //array of playing cards
        private Cards[] deck;

        public DeckOfCards()
        {
            deck = new Cards[NUM_OF_CARDS];
        }

        //get current deck
        public Cards[] getDeck { get { return deck; } }
       
        public void serUpDeck()
        {
            int i = 0;
            foreach(SUIT s in Enum.GetValues(typeof(SUIT)))
            {
                foreach (VALUE v in Enum.GetValues(typeof(VALUE)))
                {
                    deck[i]=new Cards { myValue=v,mySuit=s};
                    i++;
                }
            }
        }
    }
}
