using System;
using System.Linq;
using System.Collections.Generic;
using WarCardGame.Interfaces;
using WarCardGame.Enums;
using WarCardGame.Utilities;

namespace WarCardGame.Classes
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
                if(selectedOption == MainMenuOption.LoadGame){
                    SerializationUtility<Game> serializer = new SerializationUtility<Game>("Game");
                    List<string> files = serializer.GetFiles();
                    if(files.Any()){
                        
                        Console.WriteLine("");
                        for(int i = 0; i<files.Count; i++){
                            Console.WriteLine(string.Format("{0}) {1}", i+1, files[i]));
                        }
                        Console.WriteLine("");
                        Console.Write("Select labeled number of file to load or type 'q' to go back: ");
                        string input = Console.ReadLine();
                        if(input == "q"){
                            break;
                        }
                        int selectedIndex;
                        while(Int32.TryParse(input, out selectedIndex) == false || selectedIndex > files.Count || selectedIndex <= 0){
                            Console.WriteLine("Invalid selection");
                            Console.WriteLine("Select labeled number of file to load or type 'q' to go back. ");
                            input = Console.ReadLine();
                            if(input == "q"){
                                break;
                            }
                        }
                        if(input != "q"){
                            Game Game = serializer.Deserialize(files[selectedIndex-1]);
                            Console.WriteLine("Let's refresh your memory..");
                            foreach(Round round in Game.RoundHistory){
                                Console.Write(string.Format("{0} drew {1}. {2} drew {3}. ", Game.User.Name, round.UserCard.Name, Game.Computer.Name, round.ComputerCard.Name));
                                if(round.UserCard < round.ComputerCard){
                                    Console.WriteLine("{0} won.", Game.Computer.Name);
                                }
                                if(round.UserCard > round.ComputerCard){
                                    Console.WriteLine("{0} won.", Game.User.Name);
                                }
                                if(round.UserCard == round.ComputerCard){
                                    Console.WriteLine("Tie.");
                                }
                            }
                            Game.Play();
                        }
                    }
                    else{
                        Console.WriteLine("No saved files");
                    }
                }
                PresentOptions();
                selectedOption = GetSelectedOption();
            }
        }
    }
}