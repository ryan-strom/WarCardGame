using System;
namespace WarCardGame.Models
{
    public class Card
    {
        public Suit Suit { get; private set; }
        public string Name { get; private set; }
        public int Value { get; private set; } 

        public Card(Suit Suit, int Value){
            this.Suit = Suit;
            this.Value = Value;
            if(Value == 1){
                this.Value = 14;
            }
            this.Name = this.GetCardName();
        }
        private string GetCardName(){
            if(Value == 11){
                return "Jack";
            }
            if(Value == 12){
                return "Queen";
            }
            if(Value == 13){
                return "King";
            }
            if(Value == 14){
                return "Ace";
            }
            if(Value == 15){
                return "Joker";
            }
            return Value.ToString();
        }
        public static Boolean operator <(Card lhs, Card rhs) {
            if(lhs.Value < rhs.Value){
                return true;
            }
            return false;
        }
        public static Boolean operator >(Card lhs, Card rhs) {
            if(lhs.Value > rhs.Value){
                return true;
            }
            return false;
        }
         public static Boolean operator ==(Card lhs, Card rhs) {
            if(lhs.Value == rhs.Value){
                return true;
            }
            return false;
        }
        public static Boolean operator !=(Card lhs, Card rhs) {
            if(lhs.Value != rhs.Value){
                return true;
            }
            return false;
        }
    }
}