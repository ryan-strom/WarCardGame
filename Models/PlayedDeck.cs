using System.Collections.Generic;
using Newtonsoft.Json;
namespace WarCardGame.Models
{
    public class PlayedDeck : Deck
    {
        [JsonConstructor]
        private PlayedDeck(){

        }
        public PlayedDeck(bool InitializeCards=true){
            this.Cards = new Stack<Card>();
        }

        //  <summary>
        //  -Adds card to Cards property
        //  </summary>
        // <param name="Card">Instance of Card class to add to Cards</param>
        // <returns>None</returns>
        public void AddCard(Card Card) {  
           Cards.Push(Card);
        }

        //  <summary>
        //  -Add list of Cards to Cards property
        //  </summary>
        // <param name="CardsToAdd">List of Card class to add to Cards</param>
        // <returns>None</returns>
        public void AddCard(List<Card> CardsToAdd) {  
            foreach(var card in CardsToAdd){
                Cards.Push(card);
            }
        }
    }
}