using System.Collections.Generic;
namespace WarCardGame.Models
{
    public class Game
    {
        public Player User { get; set; }
        public Player Computer { get; set; }
        public List<Round> RoundHistory { get; set; }
        public void PlayRound(){
            Card userCard = User.PlayingDeck.DrawCard();
            Card computerCard = Computer.PlayingDeck.DrawCard();
            if(userCard > computerCard){

            }
            if(userCard < computerCard){

            }
            if(userCard == computerCard){

            }
        }
    }
}