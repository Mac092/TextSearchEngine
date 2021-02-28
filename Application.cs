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
            //Build
            //_searchEngine.InitializeSearchEngine(searchWord, args[0]);
            //Debugging
            _searchEngine.InitializeSearchEngine(searchWord, "C:\\Users\\Usuario\\Desktop\\FilesTextSearchEngine\\DirectoryWithContent");
            _searchEngine.RunSearch();
        }
    }
}
