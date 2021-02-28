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
            _searchEngine.InitializeSearchEngine(searchWord, "C:\\Users\\Usuario\\Desktop\\FilesTextSearchEngine\\DirectoryWithContent");
        }
    }
}
