using System;
using System.Collections.Generic;
using System.Linq;


namespace WarCardGame.Models
{
    public abstract class Deck
    {
        public Stack<Card> Cards { get; set; }
        protected readonly int CardCountPerSuit = 13;
    
        //  <summary>
        //  -Randomizes the order of the Cards property
        //  </summary>
        //  <param>None</param>
        //  <returns>None</returns>
        public void ShuffleCards() {  
            Random random = new Random();  
            Cards = new Stack<Card>(Cards.OrderBy(card => random.Next()));
        }

    }
}