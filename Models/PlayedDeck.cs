namespace WarCardGame.Models
{
    public class PlayedDeck : Deck
    {
        //  <summary>
        //  Pops Card Stack to return drawn Card
        //  </summary>
        //  <param>None</param>
        //  <returns>An instance of the <see cref="Card"/> class representing the card that was drawn</returns>
        public Card DrawCard(){ 
            return Cards.Pop();
        }
    }
}