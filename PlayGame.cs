using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    class PlayGame
    {

        public static bool PauseBetweenTurns { get; set; }

        public static void Play(Player p1, Player p2)
        {

            if (p1.NumberOfCards == 0)
            {
                p1.WonGame = true;

                return;
            }

            if (p2.NumberOfCards == 0)
            {
                p2.WonGame = true;

                return;
            }


            if (PauseBetweenTurns)
            {
                _ = Console.ReadLine();
            }


            int p1TopCardIndex = p1.NumberOfCards - 1;
            int p2TopCardIndex = p2.NumberOfCards - 1;

            if (p1.Hand[p1TopCardIndex].Value > p2.Hand[p2TopCardIndex].Value)
            {
                TurnOutcomes.Win(p1, p1TopCardIndex, p2, p2TopCardIndex);
            }
            else if (p1.Hand[p1TopCardIndex].Value < p2.Hand[p2TopCardIndex].Value)
            {
                TurnOutcomes.Win(p2, p2TopCardIndex, p1, p1TopCardIndex);
            }
            else if (p1.Hand[p1TopCardIndex].Value == p2.Hand[p2TopCardIndex].Value)
            {
                TurnOutcomes.Tie(p1, p1TopCardIndex, p2, p2TopCardIndex);
            }
        }

        public static void EndGame(Player p1, Player p2)
        {

            if (p1.WonGame)
                Console.WriteLine($"{p1.Name} wins!");

            if (p2.WonGame)
                Console.WriteLine($"{p2.Name} wins!");
        }

        public static void SetDisplayMethod()
        {
            Console.Write("Press '1' to display turns one at a time or press '2' to display all turns: ");

            string answer = Console.ReadLine();

            answer = answer.Trim();

            if (answer == "1")
                PauseBetweenTurns = true;

            else if (answer == "2")
                PauseBetweenTurns = false;

            else
                SetDisplayMethod();


            Console.WriteLine();

        }
    }
}
