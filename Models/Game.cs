using System.Collections.Generic;
namespace WarCardGame.Models
{
    public class Game
    {
        public Player User { get; set; }
        public Player Computer { get; set; }
        public List<Round> Rounds { get; set; }
    }
}