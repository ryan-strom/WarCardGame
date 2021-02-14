using System;
using System.Linq;
using Newtonsoft.Json;
namespace WarCardGame.Models
{
    public class Player
    {
        public string Name { get; set; }
        public PlayingDeck PlayingDeck { get; set; }
        public PlayedDeck PlayedDeck { get; set; }
        [JsonConstructor]
        private Player(){

        }
        public Player(string Name, PlayingDeck PlayingDeck){
            this.Name = Name;
            this.PlayingDeck = PlayingDeck;
            this.PlayedDeck = new PlayedDeck(true);
        }

        public Player(string Name, PlayingDeck PlayingDeck, PlayedDeck PlayedDeck){
            this.Name = Name;
            this.PlayingDeck = this.PlayingDeck;
            this.PlayedDeck = this.PlayedDeck;
        }

        //  <summary>
        //  Checks if Cards property in PlayingDeck is empty, if it is then the PlayingDeck property is set to the PlayedDeck property's value
        //  </summary>
        //  <param>None</param>
        //  <returns>None</returns>
        public void CheckAndResetDecks(){
            if(!PlayingDeck.Cards.Any()){
                Console.WriteLine("{0}'s deck is empty. Moving played cards to playing deck...", Name);
                PlayingDeck.SetCards(PlayedDeck);
            }
        }

        //  <summary>
        //  Checks if Cards property in PlayingDeck and PlayedDeck are empty
        //  </summary>
        //  <param>None</param>
        //  <returns>bool if both decks are empty</returns>
        public bool BothDecksEmpty(){
            return !PlayingDeck.Cards.Any() && !PlayedDeck.Cards.Any();
        }
    }
}