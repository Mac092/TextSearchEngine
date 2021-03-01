using NUnit.Framework;
using System;

namespace TextSearchEngine.Tests
{
    public class SearchEngineTest
    {
        private const string _dataEmptyDirectory = "C:\\Users\\Usuario\\Desktop\\TextSearchEngine\\TextSearchEngine\\ExampleDataFiles\\EmptyDirectory";
        private const string _dataDiretoryWithCoupleFiles = "C:\\Users\\Usuario\\Desktop\\TextSearchEngine\\TextSearchEngine\\ExampleDataFiles\\DirectoryWithCoupleFiles";
        private const string _dataDirectoryWithContent = "C:\\Users\\Usuario\\Desktop\\TextSearchEngine\\TextSearchEngine\\ExampleDataFiles\\DirectoryWithContent";

        [Test]
        public void TestSearchWordAndSearchDirectory()
        {
            string searchWord = "dog";
            string searchDirectory = _dataEmptyDirectory;

            SearchEngine searchEngine = new SearchEngine();
            searchEngine.InitializeSearchEngine(searchWord, searchDirectory);

            Assert.AreEqual("dog", searchEngine.SearchWord);
            Assert.AreEqual(_dataEmptyDirectory, searchEngine.EvaluatedDirectory);
        }

        [Test]
        public void TestEmptyTargetDirectory()
        {
            string searchWord = "dog";
            string searchDirectory = _dataEmptyDirectory;

            SearchEngine searchEngine = new SearchEngine();
            searchEngine.InitializeSearchEngine(searchWord, searchDirectory);

            Assert.AreEqual(0, searchEngine.FileManagement.NumFiles);
            Assert.IsNotNull(searchEngine.FileManagement.FilesNames);
        }

        [Test]
        public void TestDirectoryContainingFiles()
        {
            string searchWord = "dog";
            string searchDirectory = _dataDiretoryWithCoupleFiles;
            string[] filesNames = new string[2] { "File1.txt", "File2.txt" };

            SearchEngine searchEngine = new SearchEngine();
            searchEngine.InitializeSearchEngine(searchWord, searchDirectory);

            Assert.AreNotEqual(0, searchEngine.FileManagement.NumFiles);
            Assert.AreEqual(filesNames, searchEngine.FileManagement.FilesNames);
        }

        [Test]
        public void TestTextFromFirstFile()
        {
            string searchWord = "dog";
            string searchDirectory = _dataDirectoryWithContent;

            SearchEngine searchEngine = new SearchEngine();
            searchEngine.InitializeSearchEngine(searchWord, searchDirectory);

            Assert.AreEqual("dog bear dog dolphin", searchEngine.GetSpecificFileContent(0));
        }

        [Test]
        public void TestNumOccurrencesInFirstFile()
        {
            string searchWord = "dog";
            string searchDirectory = _dataDirectoryWithContent;

            SearchEngine searchEngine = new SearchEngine();
            searchEngine.InitializeSearchEngine(searchWord, searchDirectory);
            searchEngine.RunSearch();

            Assert.AreEqual(8, searchEngine.GetOcurrencesInFiles()[0].Item2);
        }

        [Test]
        public void TestSortedOccurrences()
        {
            string searchWord = "dog";
            string searchDirectory = _dataDirectoryWithContent;
            Tuple<string, int>[] testOccurrences = new Tuple<string, int>[6];
            testOccurrences[0] = new Tuple<string, int>("File4.txt", 8);
            testOccurrences[1] = new Tuple<string, int>("File10.txt", 6);
            testOccurrences[2] = new Tuple<string, int>("File0.txt", 2);
            testOccurrences[3] = new Tuple<string, int>("File1.txt", 2);
            testOccurrences[4] = new Tuple<string, int>("File3.txt", 2);
            testOccurrences[5] = new Tuple<string, int>("File8.txt", 1);


            SearchEngine searchEngine = new SearchEngine();
            searchEngine.InitializeSearchEngine(searchWord, searchDirectory);
            searchEngine.RunSearch();

            Assert.AreEqual(testOccurrences, searchEngine.GetOcurrencesInFiles());
        }
    }
}