using System;
using Newtonsoft.Json;
using WarCardGame.Enums;

namespace WarCardGame.Classes
{
    public class Card
    {
        public Suit Suit { get; set; }
        public string Face { get; set; }
        public int Value { get; set; } 
        public string Name { get; set; }
        [JsonConstructor]
        private Card(){

        }
        public Card(Suit Suit, int Value){
            this.Suit = Suit;
            this.Value = Value;
            if(Value == 1){
                this.Value = 14;
            }
            this.Face = this.GetCardFace();
            this.Name = this.GetCardName();
        }
        protected string GetCardFace(){
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
        protected string GetCardName(){
            return string.Format("{0} of {1}", Face, Suit);
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