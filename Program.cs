using System;

namespace War
{
    class Program
    {
        static void Main(string[] args)
        {

            Deck deck = new();

            Player player1 = new("player 1");
            Player player2 = new("player 2");

            player1.SetName();
            player2.SetName();

            PlayGame.SetDisplayMethod();


            deck.Shuffle();

            deck.Shuffle();

            DealCards.Deal(player1, player2, deck);

            bool gameFinished = false;

            while (!gameFinished)
            {

                PlayGame.Play(player1, player2);

                if (player1.WonGame || player2.WonGame)
                    gameFinished = true;

            }

            PlayGame.EndGame(player1, player2);

        }
    }
}

