using System;
using System.Collections.Generic;
using System.Linq;


namespace WarCardGame.Models
{
    public class Deck
    {
        public List<Card> Cards { get; set; }
        private readonly int CardCountPerSuit = 13;
        public Deck(){
            this.SetCards();
            this.ShuffleCards();
        }

        //  <summary>
        //  -Randomizes the order of the Cards property
        //  </summary>
        //  <param>None</param>
        //  <returns>None</returns>
        public void ShuffleCards() {  
            Random random = new Random();  
            Cards = Cards.OrderBy(card => random.Next()).ToList();
        }

        //  <summary>
        //  -Initializes the Cards property to be a colleciton with a length of the amount of Suits given times the amount of cards per Suit
        //  -Adds each card of each suit to cards property
        //  </summary>
        //  <param>None</param>
        //  <returns>None</returns>
        private void SetCards(){
            int suitCount = Enum.GetNames(typeof(Suit)).Length;
            
            Card[] newCards = new Card[suitCount * CardCountPerSuit];
            for(int i=0; i<suitCount;i++){
                for(int j = 0; j<CardCountPerSuit; j++){
                    int ind = j + CardCountPerSuit*i;

                    newCards[ind] =  new Card((Suit)i, j+1);
                }
            }
            Cards = newCards.ToList();
        }
    }
}