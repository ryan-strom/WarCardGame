using System.Collections.Generic;
namespace WarCardGame.Models
{
    public class Game
    {
        public Player User { get; set; }
        public Player Computer { get; set; }
        public List<Round> RoundHistory { get; set; }
        private readonly int DrawStakesCount = 3;

        //  <summary>
        //  Draws player cards and calls the PlayRound method to determine winner and the results of the win
        //  </summary>
        //  <param>None</param>
        //  <returns>None</returns>
        public void StartRound(){
            Card userCard = User.PlayingDeck.DrawCard();
            Card computerCard = Computer.PlayingDeck.DrawCard();
            PlayRound(userCard, computerCard, new List<Card>());
        }

        //  <summary>
        //  Represents steps in playing round by drawing player cards and comparing them. If they are equal, the method is called recursive and additional drawn cards
        //  are added to the ExistingCardStakes parameter by passing the local cardStakes variable. The local cardStakes variable is a concatenation of
        //  the played cards, existing card stakes, and the new card stakes. If they playing cards are not equal, then the played cards and card stakes 
        //  are added to the winning player's played decks. 
        //  </summary>
        //  <param name="UserCard">The user's drawn card, an instance of the <see cref="Card"/>Card class </param>
        //  <param name="ComputerCard">The computer's drawn card, an instance of the <see cref="Card"/>Card class </param>
        //  <param name="ExistingCardStakes">A List of the <see cref="Card"/>Card class that represents all the exisiting cards to be won by the winning player in the tieing rounds</param>
        //  <returns>None</returns>
        public void PlayRound(Card UserCard, Card ComputerCard, List<Card> ExistingCardStakes){
            List<Card> cardStakes = ExistingCardStakes;
            cardStakes.Add(UserCard);
            cardStakes.Add(ComputerCard);
            if(UserCard == ComputerCard){
                List<Card> userCardStakes = User.PlayingDeck.DrawCard(DrawStakesCount);
                List<Card> computerCardStakes = Computer.PlayingDeck.DrawCard(DrawStakesCount);
                cardStakes.AddRange(userCardStakes);
                cardStakes.AddRange(computerCardStakes);
                DrawRound drawRound = new DrawRound(UserCard, ComputerCard, userCardStakes, computerCardStakes);
                RoundHistory.Add(drawRound);
                PlayRound(User.PlayingDeck.DrawCard(), Computer.PlayingDeck.DrawCard(), cardStakes);
            }
            if(UserCard > ComputerCard){
                User.PlayedDeck.AddCard(cardStakes);
            }
            if(UserCard < ComputerCard){
                Computer.PlayedDeck.AddCard(cardStakes);
            }
            
        }

        
    }
}