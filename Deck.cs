using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    class Deck
    {

        public List<Card> Card { get; set; }

        public Deck()
        {

            Card = new List<Card>();

            string[] suit = new string[4] { " of spades", " of hearts", " of clubs", " of diamonds" };

            int suitCount = 0;

            int cardValue = 2;

            for (int i = 0; i < 52; i++)
            {

                if (cardValue <= 10)
                    Card.Add(new Card(cardValue, cardValue.ToString() + suit[suitCount]));

                else if (cardValue == 11)
                    Card.Add(new Card(cardValue, "jack" + suit[suitCount]));

                else if (cardValue == 12)
                    Card.Add(new Card(cardValue, "queen" + suit[suitCount]));

                else if (cardValue == 13)
                    Card.Add(new Card(cardValue, "king" + suit[suitCount]));

                else if (cardValue == 14)
                    Card.Add(new Card(cardValue, "ace" + suit[suitCount]));


                cardValue++;

                if (cardValue == 15)
                {
                    cardValue = 2;
                    suitCount++;
                }
            }
        }


        public void Shuffle()
        {

            Dictionary<int, bool> placed = new Dictionary<int, bool>();

            for (int i = 0; i < 52; i++)
            {
                placed.Add(i, false);
            }

            int randomValue = RandomNum();

            List<Card> shuffledCards = new List<Card>();

            for (int i = 0; i < 52; i++)
            {
                if (!placed[randomValue])
                {
                    shuffledCards.Add(Card[randomValue]);

                    placed[randomValue] = true;

                    randomValue = RandomNum();
                }
                else
                {
                    randomValue = RandomNum();

                    i--;
                }
            }

            Card = shuffledCards;
        }


        private int RandomNum()
        {
            Random random = new Random();

            int randomValue = random.Next(0, 52);

            return randomValue;
        }
    }   
}

    
    

