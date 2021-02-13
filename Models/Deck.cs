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
        }
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