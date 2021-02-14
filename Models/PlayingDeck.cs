using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace WarCardGame.Models
{
    public class PlayingDeck : Deck
    {
        [JsonConstructor]
        private PlayingDeck(){

        }
        public PlayingDeck(bool InitializeCards = true){
            if(InitializeCards){
                this.SetCards();
                this.ShuffleCards();
            }
        }

        private PlayingDeck(Stack<Card> Cards){
            this.Cards = Cards;
        }
        
        //  <summary>
        //  Splits current deck into provided integer given by paramater
        //  </summary>
        // <param name="NumberOfDecks"> <see cref="UInt32"/> Number of decks to split into</param>
        //  <exception>Exception if NumberOfDecks parameter is less than 0</exception>
        //  <returns>A List of the <see cref="PlayingCard"/> class..</returns>
        public List<PlayingDeck> SplitDeck(uint NumberOfDecks){
            if(NumberOfDecks == 0){
                throw new Exception("NumberOfDecks cannot be zero");
            }

            List<PlayingDeck> playingDecks = new List<PlayingDeck>();
            for(int i = 0; i<Cards.Count; i+=(int)(Cards.Count/NumberOfDecks)){
                Stack<Card> cards = new Stack<Card>(Cards.Skip(i).Take((int)(Cards.Count/NumberOfDecks)));
                PlayingDeck playingDeck = new PlayingDeck(cards);
                playingDecks.Add(playingDeck);
            }
            return playingDecks;
        }
        //  <summary>
        //  Pops Card Stack to return drawn Card
        //  </summary>
        //  <param>None</param>
        //  <returns>An instance of the <see cref="Card"/> class representing the card that was drawn. Returns null if the stack is empty.</returns>
        public Card DrawCard(){ 
            Card card = null;
            if(Cards.TryPop(out card)){
                return card;
            }
            return null;
        }
        //  <summary>
        //  Pops Card Stack to return drawn Card
        //  </summary>
        // <param name="count"> <see cref="Int32"/> Number of cards to draw</param>
        //  <returns>A list of the <see cref="Card"/> cards representing the cards that are drawn</returns>
        public List<Card> DrawCard(int count){ 
            List<Card> drawnCards = new List<Card>();
            for(int i = 0; i<count && i < Cards.Count; i++){
                drawnCards.Add(Cards.Pop());
            }
            return drawnCards;
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
            Cards = new Stack<Card>(newCards);
        }


        //  <summary>
        //  -Sets Cards property to the value of the Cards property of the PlayedDeck parameter
        //  </summary>
        // <param name="PlayedDeck"> <see cref="PlayedDeck"/>Instance of the PlayedDeck class of cards already played and won through play</param>
        //  <returns>None</returns>
        public void SetCards(PlayedDeck PlayedDeck) {
            base.SetCards(PlayedDeck.Cards);
        }
    }
}