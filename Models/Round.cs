using System.Collections.Generic;

namespace WarCardGame.Models
{
    public class Round
    {
        public Card UserCard { get; set; }
        public Card ComputerCard { get; set; }
        
        public Round(Card UserCard, Card ComputerCard){
            this.UserCard = UserCard;
            this.ComputerCard = ComputerCard;
        }
    }
}