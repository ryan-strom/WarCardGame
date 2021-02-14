using System.Collections.Generic;
namespace WarCardGame.Models
{
    public interface IDeck<T>
    {

        public Stack<T> Cards { get; set; }
    }
}