using System.Collections.Generic; 

namespace WarCardGame.Models
{
    public class DrawRound : Round
    {
        public List<Card> ComputerCardStakes { get; set; }
        public List<Card> UserCardStakes { get; set; }
        public DrawRound(Card UserCard, Card ComputerCard, List<Card> ComputerCardStakes, List<Card> UserCardStakes) : base(UserCard, ComputerCard){
            
        }
    }
}