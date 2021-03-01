using System;

namespace TextSearchEngine
{
    public class Application
    {
        private static SearchEngine _searchEngine;
        private static UserInteraction _userInteraction;

        public static void Main(string[] args)
        {
            _userInteraction = new UserInteraction();
            _searchEngine = new SearchEngine();

            string searchWord = _userInteraction.AskForSearch();
            string directoryPath = _userInteraction.AskForDirectoryPath();

            _searchEngine.InitializeSearchEngine(searchWord, directoryPath);
            _userInteraction.ShowMessage(_searchEngine.FileManagement.NumFiles + " files read in directory: " + directoryPath);

            _searchEngine.RunSearch();

            _userInteraction.ShowSearchResults(_searchEngine.GetOcurrencesInFiles());
        }
    }
}
