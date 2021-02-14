namespace WarCardGame.Models
{
    public class PlayedDeck : Deck
    {
        
        //  <summary>
        //  -Adds card to Cards property
        //  </summary>
        // <param name="Card">Instance of Card class to add to Cards</param>
        // <returns>None</returns>
        public void AddCard(Card Card) {  
           Cards.Push(Card);
        }
    }
}