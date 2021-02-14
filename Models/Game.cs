using System.Collections.Generic;
using System;
using System.Linq;
namespace WarCardGame.Models
{
    public class Game
    {
        public Player User { get; set; }
        public Player Computer { get; set; }
        public List<Round> RoundHistory { get; set; }
        private readonly int DrawStakesCount = 3;
        public Game(){
            this.User = new Player("User");
            this.Computer = new Player("Computer");
            this.RoundHistory = new List<Round>();
        }
        public Game(Player User, Player Computer, List<Round> RoundHistory){
            this.User = User;
            this.Computer = Computer;
            this.RoundHistory = RoundHistory;
        }


        //  <summary>
        //  Initiates the game and calls StartRound function in while loop while user input is 'y' and while the playing decks have cards
        //  </summary>
        //  <param>None</param>
        //  <returns>None</returns>
        public void Play(){
            Console.WriteLine("Draw card (y/n)? ");
            string input = Console.ReadLine();
            while(User.PlayingDeck.Cards.Any() && Computer.PlayingDeck.Cards.Any() &&  input == "y"){
                StartRound();
                Console.WriteLine("Draw card (y/n)? ");
                input = Console.ReadLine();
            }
            if(User.BothDecksEmpty()){
                Console.WriteLine("{0} has no more cards. {1} wins!", User.Name, Computer.Name);
            }
            if(Computer.BothDecksEmpty()){
                Console.WriteLine("{0} has no more cards. {1} wins!", Computer.Name, User.Name);
            }
        }


        //  <summary>
        //  Draws player cards and calls the PlayRound method to determine winner and the results of the win
        //  </summary>
        //  <param>None</param>
        //  <returns>None</returns>
        public void StartRound(){
            Card userCard = User.PlayingDeck.DrawCard();
            Card computerCard = Computer.PlayingDeck.DrawCard();
            Console.WriteLine("Player draws {0}", userCard.Name);
            Console.WriteLine("Computer draws {0}", computerCard.Name);
            PlayRound(userCard, computerCard);

            User.CheckAndResetDecks();
            Computer.CheckAndResetDecks();
        }

        //  <summary>
        //  Represents steps in playing round by drawing player cards and comparing them. If they are equal, additional drawn cards
        //  are added to card stakes while the newly drawn cards are equal. The local cardStakes variable is a concatenation of
        //  the played cards, existing card stakes, and the new card stakes. If they playing cards are not equal, then the played cards and card stakes 
        //  are added to the winning player's played decks. 
        //  </summary>
        //  <param name="UserCard">The user's drawn card, an instance of the <see cref="Card"/>Card class </param>
        //  <param name="ComputerCard">The computer's drawn card, an instance of the <see cref="Card"/>Card class </param>
        //  <returns>None</returns>
        public void PlayRound(Card UserCard, Card ComputerCard){
            List<Card> cardStakes = new List<Card>();
            cardStakes.Add(UserCard);
            cardStakes.Add(ComputerCard);
            while(UserCard == ComputerCard){
                Console.WriteLine("It is a tie! Drawing {0} cards from each players' deck.", DrawStakesCount);
                List<Card> userCardStakes = new List<Card>();
                for(int i=0; i<DrawStakesCount; i++){
                    User.CheckAndResetDecks();
                    Card drawnCard = User.PlayingDeck.DrawCard();
                    if(drawnCard is null){
                        break;
                    }
                    userCardStakes.Add(drawnCard);
                }
                List<Card> computerCardStakes = new List<Card>();
                for(int i=0; i<DrawStakesCount; i++){
                    Computer.CheckAndResetDecks();
                    Card drawnCard = Computer.PlayingDeck.DrawCard();
                    if(drawnCard is null){
                        break;
                    }
                    computerCardStakes.Add(drawnCard);
                }
                Console.WriteLine("These cards are at stake: ");
                Console.WriteLine("\tDrawn from user deck: ");
                userCardStakes.ForEach(card => Console.WriteLine("\t\t{0}", card.Name));
                Console.WriteLine("\tDrawn from computer deck: ");
                computerCardStakes.ForEach(card => Console.WriteLine("\t\t{0}", card.Name));
                cardStakes.AddRange(userCardStakes);
                cardStakes.AddRange(computerCardStakes);
                DrawRound drawRound = new DrawRound(UserCard, ComputerCard, userCardStakes, computerCardStakes);
                RoundHistory.Add(drawRound);

                User.CheckAndResetDecks();
                Computer.CheckAndResetDecks();
                if(User.BothDecksEmpty() || Computer.BothDecksEmpty()){
                    return;
                }
                UserCard = User.PlayingDeck.DrawCard();
                ComputerCard = Computer.PlayingDeck.DrawCard();
                Console.WriteLine("Computer draws {0}", ComputerCard.Name);
                Console.WriteLine("Player draws {0}", UserCard.Name);

            }

            RoundHistory.Add(new Round(UserCard, ComputerCard));
            if(UserCard > ComputerCard){
                User.PlayedDeck.AddCard(cardStakes);
                Console.WriteLine("User wins! These cards were added to user's played deck: ");
            }
            if(UserCard < ComputerCard){
                Computer.PlayedDeck.AddCard(cardStakes);
                Console.WriteLine("Computer wins! These cards were added to computer's played deck: ");
            }
            cardStakes.ForEach(card => Console.WriteLine("\t{0}", card.Name));
            
        }

        
    }
}