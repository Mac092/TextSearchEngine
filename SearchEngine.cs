using System;
using System.Collections.Generic;

namespace TextSearchEngine
{
    public class SearchEngine
    {
        public string SearchWord { get; private set; }
        public FileManagement FileManagement { get; private set; }
        public string EvaluatedDirectory { get; private set; }

        private Tuple<string, int>[] _ocurrencesInFiles;
        private char[][] _fileContents;

        public void InitializeSearchEngine(string searchWord, string searchDirectory)
        {
            FileManagement = new FileManagement();
            SearchWord = searchWord;
            EvaluatedDirectory = searchDirectory;

            FileManagement.ObtainNumFilesAndFileNames(EvaluatedDirectory);
            _ocurrencesInFiles = new Tuple<string, int>[FileManagement.NumFiles];
            _fileContents = new char[FileManagement.NumFiles][];

            FileManagement.StoreContentIntoCharArray(EvaluatedDirectory, ref _fileContents);
        }

        public string GetSpecificFileContent(int fileIndex)
        {
            string fileContent = new string(_fileContents[fileIndex]);

            return fileContent;
        }

        private void RunSearch()
        {

        }

        private void SortOcurrencesResults()
        {

        }
    }

}
