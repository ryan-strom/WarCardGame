using System.Collections.Generic;
namespace WarCardGame.Interfaces
{
    public interface IDeck<T>
    {

        public Stack<T> Cards { get; set; }
    }
}