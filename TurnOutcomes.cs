using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    class TurnOutcomes
    {

        private static List<Card> playedInTie = new List<Card>();

        public static void Win(Player winner, int winnerIndex, Player loser, int loserIndex)
        {

        
            Console.Write($"{ winner.Name }'s { winner.Hand[winnerIndex].Name } beat { loser.Name }'s { loser.Hand[loserIndex].Name }\n");
            

            
            winner.Hand.Insert(0, winner.Hand[winnerIndex]);
            winner.Hand.Insert(0, loser.Hand[loserIndex]);
           
            winner.Hand.RemoveAt(winnerIndex + 2);
            loser.Hand.RemoveAt(loserIndex);

            Console.WriteLine($"{winner.Name} now has {winner.NumberOfCards} cards");
            Console.WriteLine($"{loser.Name} now has {loser.NumberOfCards} cards\n");

            if (loser.NumberOfCards == 0)
                winner.WonGame = true;

        }


        public static void Tie(Player p1, int p1Index, Player p2, int p2Index)
        {


            Console.WriteLine($"{ p1.Name }'s { p1.Hand[p1Index].Name } ties { p2.Name }'s { p2.Hand[p2Index].Name }\n");

            playedInTie.Add(p1.Hand[p1Index]);
            p1.Hand.RemoveAt(p1Index);

            playedInTie.Add(p2.Hand[p2Index]);
            p2.Hand.RemoveAt(p2Index);


            if (p1.NumberOfCards < 4)
            {
                p2.WonGame = true;

                Console.WriteLine($"{ p1.Name } does not have enough cards to continue\n");

                return;
            }

            if (p2.NumberOfCards < 4)
            {
                p1.WonGame = true;

                Console.WriteLine($"{ p2.Name } does not have enough cards to continue\n");

                return;
            }



            Console.WriteLine($"{ p1.Name } wagers: ");

            for (int i = p1Index - 1; i > p1Index - 4; i--)
            {
                Console.WriteLine($"{ p1.Hand[i].Name } ");

                playedInTie.Add(p1.Hand[i]);

                p1.Hand.RemoveAt(i);
            }

            Console.WriteLine();

            Console.WriteLine($"{p2.Name} wagers: ");

            for (int i = p2Index - 1; i > p2Index - 4; i--)
            {
                Console.WriteLine($"{p2.Hand[i].Name} ");

                playedInTie.Add(p2.Hand[i]);

                p2.Hand.RemoveAt(i);
            }

            Console.WriteLine();

            if (p1.Hand[p1Index - 4].Value > p2.Hand[p2Index - 4].Value)
            {
                Console.WriteLine($"{ p1.Name }'s { p1.Hand[p1Index - 4].Name } beat { p2.Name }'s { p2.Hand[p2Index - 4].Name }\n");

                Console.WriteLine($"{ p1.Name } wins the war and collects all the cards!");

                Console.WriteLine();

                playedInTie.Add(p1.Hand[p1Index - 4]);
                p1.Hand.RemoveAt(p1Index - 4);

                playedInTie.Add(p2.Hand[p2Index - 4]);
                p2.Hand.RemoveAt(p2Index - 4);

                foreach (Card wonCard in playedInTie)
                {
                    p1.Hand.Insert(0, wonCard);
                }

                playedInTie.Clear();


                Console.WriteLine($"{p1.Name} now has {p1.NumberOfCards} cards");
                Console.WriteLine($"{p2.Name} now has {p2.NumberOfCards} cards\n");

            }

            else if (p1.Hand[p1Index - 4].Value < p2.Hand[p2Index - 4].Value)
            {
                Console.WriteLine($"{ p2.Name }'s { p2.Hand[p2Index - 4].Name } beat { p1.Name }'s { p1.Hand[p1Index - 4].Name }\n");

                Console.WriteLine($"{ p2.Name } wins the war and collects all the cards!");

                Console.WriteLine();

                playedInTie.Add(p1.Hand[p1Index - 4]);
                p1.Hand.RemoveAt(p1Index - 4);

                playedInTie.Add(p2.Hand[p2Index - 4]);
                p2.Hand.RemoveAt(p2Index - 4);

                foreach (Card wonCard in playedInTie)
                {
                    p2.Hand.Insert(0, wonCard);                  
                }

                playedInTie.Clear();


                Console.WriteLine($"{p1.Name} now has {p1.NumberOfCards} cards");
                Console.WriteLine($"{p2.Name} now has {p2.NumberOfCards} cards\n");

            }

            else
                Tie(p1, p1Index - 4, p2, p2Index - 4);

        }        
    }
}