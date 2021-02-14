using System;
namespace WarCardGame.Models
{
    public class MainMenu : Menu<MainMenuOption>
    {
        //  <summary>
        //  Presents main menu option selection onto console
        //  </summary>
        //  <param>None/param>
        //  <returns>None</returns>
        public void PresentOptions(){
            Console.WriteLine("");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Main Menu");
            Console.WriteLine("1) Start a new game");
            Console.WriteLine("2) Load a saved game");
            Console.WriteLine("3) Quit");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("");
        }
        //  <summary>
        //  Validates and retrieves user selection from options
        //  </summary>
        //  <param>None/param>
        //  <returns><cref="MainMenuOption">Enum of MainMenuOption</returns>
        public MainMenuOption GetSelectedOption(){
            Console.WriteLine("Select an option: ");
            string input = Console.ReadLine();
            int intInput;
            while(!Int32.TryParse(input, out intInput) || !Enum.IsDefined(typeof(MainMenuOption), intInput-1)){
                Console.WriteLine("Invalid selection.");
                Console.WriteLine("Select an option: ");
                input = Console.ReadLine();
            }
            return (MainMenuOption)intInput-1;
        }

        //  <summary>
        //  Presents options, retrieves user selection, and implements corresponding method based on selection
        //  </summary>
        //  <param>None/param>
        //  <returns>None</returns>
        public void Menu(){
            PresentOptions();
            MainMenuOption selectedOption = GetSelectedOption();
            while(selectedOption != MainMenuOption.Quit){
                if(selectedOption == MainMenuOption.NewGame){
                    Console.Write("Enter your name: ");
                    string playerName = Console.ReadLine();
                    Console.WriteLine("Hello {0}, let's get started!", playerName);
                    Game game = new Game(playerName);
                    game.Play();
                }
                PresentOptions();
                selectedOption = GetSelectedOption();
            }
        }
    }
}