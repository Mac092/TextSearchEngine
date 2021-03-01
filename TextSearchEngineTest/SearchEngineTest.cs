using NUnit.Framework;
using System;

namespace TextSearchEngine.Tests
{
    public class SearchEngineTest
    {
        [Test]
        public void TestSearchWordAndSearchDirectory()
        {
            string searchWord = "dog";
            string searchDirectory = "C:\\Users\\Usuario\\Desktop\\FilesTextSearchEngine\\EmptyDirectory";

            SearchEngine searchEngine = new SearchEngine();
            searchEngine.InitializeSearchEngine(searchWord, searchDirectory);

            Assert.AreEqual("dog", searchEngine.SearchWord);
            Assert.AreEqual("C:\\Users\\Usuario\\Desktop\\FilesTextSearchEngine\\EmptyDirectory", searchEngine.EvaluatedDirectory);
        }

        [Test]
        public void TestEmptyTargetDirectory()
        {
            string searchWord = "dog";
            string searchDirectory = "C:\\Users\\Usuario\\Desktop\\FilesTextSearchEngine\\EmptyDirectory";

            SearchEngine searchEngine = new SearchEngine();
            searchEngine.InitializeSearchEngine(searchWord, searchDirectory);

            Assert.AreEqual(0, searchEngine.FileManagement.NumFiles);
            Assert.IsNotNull(searchEngine.FileManagement.FilesNames);
        }

        [Test]
        public void TestDirectoryContainingFiles()
        {
            string searchWord = "dog";
            string searchDirectory = "C:\\Users\\Usuario\\Desktop\\FilesTextSearchEngine\\DirectoryWithCoupleFiles";
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
            string searchDirectory = "C:\\Users\\Usuario\\Desktop\\FilesTextSearchEngine\\DirectoryWithContent";

            SearchEngine searchEngine = new SearchEngine();
            searchEngine.InitializeSearchEngine(searchWord, searchDirectory);

            Assert.AreEqual("dog bear dog dolphin", searchEngine.GetSpecificFileContent(0));
        }

        [Test]
        public void TestNumOccurrencesInFirstFile()
        {
            string searchWord = "dog";
            string searchDirectory = "C:\\Users\\Usuario\\Desktop\\FilesTextSearchEngine\\DirectoryWithContent";

            SearchEngine searchEngine = new SearchEngine();
            searchEngine.InitializeSearchEngine(searchWord, searchDirectory);
            searchEngine.RunSearch();

            Assert.AreEqual(8, searchEngine.GetOcurrencesInFiles()[0].Item2);
        }

        [Test]
        public void TestSortedOccurrences()
        {
            string searchWord = "dog";
            string searchDirectory = "C:\\Users\\Usuario\\Desktop\\FilesTextSearchEngine\\DirectoryWithContent";
            Tuple<string, int>[] testOccurrences = new Tuple<string, int>[3];
            testOccurrences[0] = new Tuple<string, int>("File4.txt", 8);
            testOccurrences[1] = new Tuple<string, int>("File3.txt", 5);
            testOccurrences[2] = new Tuple<string, int>("File1.txt", 2);

            SearchEngine searchEngine = new SearchEngine();
            searchEngine.InitializeSearchEngine(searchWord, searchDirectory);
            searchEngine.RunSearch();

            Assert.AreEqual(testOccurrences, searchEngine.GetOcurrencesInFiles());
        }
    }
}