using System.Collections.Generic;

namespace WarCardGame.Models
{
    public abstract class Round
    {
        public Card PlayerCard { get; set; }
        public Card ComputerCard { get; set; }
    }
}