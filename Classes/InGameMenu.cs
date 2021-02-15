using System;
using System.Linq;
using WarCardGame.Enums;
using WarCardGame.Interfaces;
using WarCardGame.Utilities;

namespace WarCardGame.Classes
{
    public class InGameMenu : Menu<InGameMenuOption>
    {
        private Game Game { get; set; }
        public InGameMenu(Game Game){
            this.Game = Game;
        }
        //  <summary>
        //  Validates and retrieves user selection from options
        //  </summary>
        //  <param>None/param>
        //  <returns><cref="InGameMenuOption">Enum of InGameMenuOption</returns>
        public InGameMenuOption GetSelectedOption()
        {
            Console.WriteLine("Select an option: ");
            string input = Console.ReadLine();
            int intInput;
            while(!Int32.TryParse(input, out intInput) || !Enum.IsDefined(typeof(InGameMenuOption), intInput-1)){
                Console.WriteLine("Invalid selection.");
                Console.WriteLine("Select an option: ");
                input = Console.ReadLine();
            }
            return (InGameMenuOption)intInput-1;
        }

        //  <summary>
        //  Presents options, retrieves user selection, and implements corresponding method based on selection
        //  </summary>
        //  <param>None/param>
        //  <returns>None</returns>
        public void Menu()
        {
            PresentOptions();
            InGameMenuOption selectedOption = GetSelectedOption();
            while(new InGameMenuOption[]{ InGameMenuOption.CloseMenu }.Contains(selectedOption) == false){
                if(selectedOption == InGameMenuOption.Save){
                    Save();
                }
                if(selectedOption == InGameMenuOption.SaveAndQuit){
                    Save();
                    Quit();
                }
                if(selectedOption == InGameMenuOption.QuitProgram){
                    Quit();
                }
                if(selectedOption == InGameMenuOption.BackToMainMenu){
                    Game.ShouldQuit = true;
                    break;
                }
                PresentOptions();
                selectedOption = GetSelectedOption();
            }
        }
         //  <summary>
        //  Serializes instance of Game property
        //  </summary>
        //  <param>None/param>
        //  <returns>None</returns>
        public void Save(){
            SerializationUtility<Game> serializer = new SerializationUtility<Game>("Game");
            serializer.Serialize(this.Game, string.Format("{0}_{1}", this.Game.User.Name, DateTime.Now.ToString("f")));

        } 
        //  <summary>
        //  Exits entire application
        //  </summary>
        //  <param>None/param>
        //  <returns>None</returns>
        public void Quit(){
            Console.WriteLine("Are you sure you want to exit? Type yes if you do. ");
            string input = Console.ReadLine();
            if(input.ToLower() == "yes"){
                Environment.Exit(0);
            }
        }
       //  <summary>
        //  Presents in game option selection onto console
        //  </summary>
        //  <param>None/param>
        //  <returns>None</returns>
        public void PresentOptions()
        {
            Console.WriteLine("");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("In-game Menu");
            Console.WriteLine("1) Save current game");
            Console.WriteLine("2) Save current game and quit");
            Console.WriteLine("3) Exit program");
            Console.WriteLine("4) Go back to main menu");
            Console.WriteLine("5) Close this menu and go back to game");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("");
        }
    }
}