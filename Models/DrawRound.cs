using System.Collections.Generic; 

namespace WarCardGame.Models
{
    public class DrawRound : Round
    {
        public List<Card> ComputerCardStakes { get; set; }
        public List<Card> PlayerCardStakes { get; set; }
    }
}