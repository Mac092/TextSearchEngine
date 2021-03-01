using System;

namespace TextSearchEngine
{
    public class SearchEngine
    {
        public string SearchWord { get; private set; }
        public FileManagement FileManagement { get; private set; }
        public string EvaluatedDirectory { get; private set; }

        private Tuple<string, int>[] _occurrencesInFiles;
        private char[][] _fileContents;

        private const int _maxResults = 10;

        public Tuple<string, int>[] GetOcurrencesInFiles()
        {
            return _occurrencesInFiles;
        }

        public void InitializeSearchEngine(string searchWord, string searchDirectory)
        {
            FileManagement = new FileManagement();
            SearchWord = searchWord;
            EvaluatedDirectory = searchDirectory;

            PrepareSearchDataSource();
        }

        public string GetSpecificFileContent(int fileIndex)
        {
            string fileContent = new string(_fileContents[fileIndex]);

            return fileContent;
        }

        public void RunSearch()
        {
            string fileContent = string.Empty;
            int resultsWithAnyOccurrences = 0;

            for (int i = 0; i < _fileContents.Length; i++)
            {
                int fileOcurrences = 0;
                int stringStartIndex = 0;

                fileContent = new string(_fileContents[i]);

                while ((stringStartIndex = fileContent.IndexOf(SearchWord, stringStartIndex)) != -1)
                {
                    stringStartIndex += SearchWord.Length;
                    fileOcurrences++;
                }

                if (fileOcurrences > 0)
                {
                    _occurrencesInFiles[resultsWithAnyOccurrences] = new Tuple<string, int>(FileManagement.FilesNames[i], fileOcurrences);
                    resultsWithAnyOccurrences += 1;
                }
            }

            Array.Resize<Tuple<string, int>>(ref _occurrencesInFiles, resultsWithAnyOccurrences);
            SortResults();
        }
       
        private void PrepareSearchDataSource()
        {
            FileManagement.ObtainNumFilesAndFileNames(EvaluatedDirectory);
            _occurrencesInFiles = new Tuple<string, int>[FileManagement.NumFiles];
            _fileContents = new char[FileManagement.NumFiles][];

            FileManagement.StoreContentIntoCharArray(EvaluatedDirectory, ref _fileContents);
        }

        private void SortResults()
        {
            int[] sortedNumOccurrences = SortNumOcurrences();
            int alreadySortedCount = 1;

            Tuple<string, int>[] auxOcurrencesInFiles = new Tuple<string, int>[sortedNumOccurrences.Length];

            for (int i = 0; i < sortedNumOccurrences.Length; i++)
            {
                int j = 0;
                while (j < _occurrencesInFiles.Length)
                {
                    if (sortedNumOccurrences[i] == _occurrencesInFiles[j].Item2)
                    {
                        for (int l = 0; l < alreadySortedCount; l++)
                        {
                            if (auxOcurrencesInFiles[l] != null && auxOcurrencesInFiles[l].Item1 == _occurrencesInFiles[j].Item1)
                                break;
                            if (l == alreadySortedCount - 1)
                            {
                                alreadySortedCount += 1;
                                auxOcurrencesInFiles[i] = _occurrencesInFiles[j];
                                j = _occurrencesInFiles.Length;
                                break;
                            }
                        }
                    }
                    j++;
                }
            }
            _occurrencesInFiles = auxOcurrencesInFiles;
            LimitResults(alreadySortedCount);
        }

        private int[] SortNumOcurrences()
        {
            int[] numOcurrences = new int[_occurrencesInFiles.Length];

            for (int i = 0; i < numOcurrences.Length; i++)
            {
                numOcurrences[i] = _occurrencesInFiles[i].Item2;
            }

            HeapSort(ref numOcurrences, numOcurrences.Length);

            return numOcurrences;
        }

        private void LimitResults(int sortedOccurences)
        {
            int limitResults = _maxResults;

            if (sortedOccurences < _maxResults)
                limitResults = sortedOccurences - 1;

            Array.Resize<Tuple<string, int>>(ref _occurrencesInFiles, limitResults);
        }

        private void HeapSort(ref int[] arr, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
                HeapifySort(ref arr, n, i);
            for (int i = n - 1; i >= 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                HeapifySort(ref arr, i, 0);
            }
        }

        private void HeapifySort(ref int[] arr, int n, int i)
        {
            int shortest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (right < n && arr[right] < arr[shortest])
                shortest = right;
            if (left < n && arr[left] < arr[shortest])
                shortest = left;
            if (shortest != i)
            {
                int swap = arr[i];
                arr[i] = arr[shortest];
                arr[shortest] = swap;
                HeapifySort(ref arr, n, shortest);
            }
        }
    }
}
