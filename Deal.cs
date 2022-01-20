using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    class DealCards
    {

        public static void Deal(Player p1, Player p2, Deck deck)
        {

            int cntr = 0;

            foreach (var card in deck.Card)
            {

                if (cntr % 2 == 0)
                    p1.Hand.Add(card);

                else
                    p2.Hand.Add(card);

                cntr++;
            }
        }
    }
}
