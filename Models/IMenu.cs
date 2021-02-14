namespace WarCardGame.Models
{
    public interface Menu<T>
    {
        //  <summary>
        //  Presents option selection onto console
        //  </summary>
        //  <param>None/param>
        //  <returns>None</returns>
        void PresentOptions();

        //  <summary>
        //  Validates and retrieves user selection from options
        //  </summary>
        //  <param>None/param>
        //  <returns><cref="T">Passed interface type</returns>
        T GetSelectedOption();
        //  <summary>
        //  Presents options, retrieves user selection, and implements corresponding method based on selection
        //  </summary>
        //  <param>None/param>
        //  <returns>None</returns>
        void Menu();
    }
}