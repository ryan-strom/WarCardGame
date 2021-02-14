using System;
using WarCardGame.Models;
using System.Diagnostics;
using System.Linq;
namespace WarCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Play();
        }
    }
}
