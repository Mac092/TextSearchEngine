using System;

namespace TextSearchEngine
{
    public class UserInteraction
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message + "\n");
        }

        public string AskForDirectoryPath()
        {
            Console.WriteLine("Please introduce the target directory: \n");
            string directoryPath = Console.ReadLine();

            return directoryPath;
        }

        public string AskForSearch()
        {
            Console.WriteLine("Please introduce your search: \n");
            string searchWord = Console.ReadLine();

            return searchWord;
        }

        public void ShowSearchResults(in Tuple<string, int>[] sortedResults)
        {
            for (int i = 0; i < sortedResults.Length ; i++)
            {
                Console.WriteLine(sortedResults[i].Item1 + " : " + sortedResults[i].Item2 + "\n");
            }
            Console.ReadKey();
        }
    }
}
