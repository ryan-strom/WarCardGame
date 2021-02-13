using System;
using System.Collections.Generic;
using System.Linq;

namespace WarCardGame.Models
{
    public class Deck
    {
        public List<Card> Cards { get; set; }
        private readonly int CardCountPerSuit = 13;
    }
}