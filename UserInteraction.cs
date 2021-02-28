using System;

namespace TextSearchEngine
{
    public class UserInteraction
    {
        public void ShowMessage(string message)
        {

        }

        public string AskForSearch()
        {
            string searchWord = Console.ReadLine();

            return searchWord;
        }

        public void ShowSearchResults()
        {

        }
    }
}
