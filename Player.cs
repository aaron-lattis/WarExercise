using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    class Player
    {

        public string Name { get; set; }

        public List<Card> Hand { get; set; }

        public bool WonGame { get; set; }

        public int NumberOfCards
        {
            get { return Hand.Count; }
        }


        public Player(string name)
        {
            Name = name;

            Hand = new List<Card>();

            WonGame = false;
        }

        public void SetName()
        {

            Console.Write($"Enter the name of {Name}: ");

            string newName = Console.ReadLine();

            newName = newName.Trim();

            Console.WriteLine();

            if (String.IsNullOrEmpty(newName))
                return;

            try
            {
                Name = newName;
            }
            catch
            {
                SetName();
            }
        }
    }
}
