using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{

    class Card
    {

        public int Value { get; set; }

        public string Name { get; set; }


        public Card(int v, string n)
        {
            Value = v;

            Name = n;
        }
    }
}
