using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using WarCardGame.Interfaces;

namespace WarCardGame.Classes
{
    public abstract class Deck : IDeck<Card>
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

        //  <summary>
        //  -Sets Cards property to the value of the Cards parameter 
        //  -Empties Cards parameter
        //  </summary>
        // <param name="Cards">Stack of Card <see cref="Card"/> instance to set Cards property to</param>
        //  <returns>None</returns>
        protected void SetCards(Stack<Card> Cards){
            this.Cards = Cards;
            Cards = new Stack<Card>();
        }

    }
}