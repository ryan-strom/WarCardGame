namespace WarCardGame.Models
{
    public class Player
    {
        public PlayingDeck PlayingDeck { get; set; }
        public PlayedDeck PlayedDeck { get; set; }
        public Player(){
            this.PlayingDeck = new PlayingDeck();
            this.PlayedDeck = new PlayedDeck();
        }
    }
}