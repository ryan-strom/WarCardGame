using System;
using System.Linq;
namespace WarCardGame.Models
{
    public class InGameMenu : Menu<InGameMenuOption>
    {

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
                if(selectedOption == InGameMenuOption.QuitProgram){
                    Console.WriteLine("Are you sure you want to exit? Type yes if you do. ");
                    string input = Console.ReadLine();
                    if(input.ToLower() == "yes"){
                        Environment.Exit(0);
                    }
                }
                PresentOptions();
                selectedOption = GetSelectedOption();
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
            Console.WriteLine("4) Close this menu and go back to game");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("");
        }
    }
}