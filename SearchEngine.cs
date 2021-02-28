using System;

namespace TextSearchEngine
{
    public class SearchEngine
    {
        public string SearchWord { get; private set; }
        public FileManagement FileManagement { get; private set; }
        public string EvaluatedDirectory { get; private set; }

        private Tuple<string, int>[] _ocurrencesInFiles;
        private char[][] _fileContents;

        public Tuple<string, int>[] GetOcurrencesInFiles()
        {
            return _ocurrencesInFiles;
        }

        public void InitializeSearchEngine(string searchWord, string searchDirectory)
        {
            FileManagement = new FileManagement();
            SearchWord = searchWord;
            EvaluatedDirectory = searchDirectory;

            PrepareSearchDataSource();
        }

        public void RunSearch()
        {
            string fileContent = string.Empty;
            for (int i = 0; i < _fileContents.Length; i++)
            {
                int fileOcurrences = 0;
                int a = 0;

                fileContent = new string(_fileContents[i]);

                while ((a = fileContent.IndexOf(SearchWord, a)) != -1)
                {
                    a += SearchWord.Length;
                    fileOcurrences++;
                }
                _ocurrencesInFiles[i] = new Tuple<string, int>(FileManagement.FilesNames[i], fileOcurrences);
            }
        }

        public string GetSpecificFileContent(int fileIndex)
        {
            string fileContent = new string(_fileContents[fileIndex]);

            return fileContent;
        }

        private void PrepareSearchDataSource()
        {
            FileManagement.ObtainNumFilesAndFileNames(EvaluatedDirectory);
            _ocurrencesInFiles = new Tuple<string, int>[FileManagement.NumFiles];
            _fileContents = new char[FileManagement.NumFiles][];

            FileManagement.StoreContentIntoCharArray(EvaluatedDirectory, ref _fileContents);
        }

        private void SortOcurrencesResults()
        {

        }
    }

}
