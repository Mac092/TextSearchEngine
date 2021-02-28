using NUnit.Framework;

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
            string searchDirectory = "C:\\Users\\Usuario\\Desktop\\FilesTextSearchEngine\\DirectoryWithContent";
            string[] filesNames = new string[2] { "File1.txt", "File2.txt" };

            SearchEngine searchEngine = new SearchEngine();
            searchEngine.InitializeSearchEngine(searchWord, searchDirectory);

            Assert.AreNotEqual(0, searchEngine.FileManagement.NumFiles);
            Assert.AreEqual(filesNames, searchEngine.FileManagement.FilesNames);
        }

        [Test]
        public void GetTextFromFirstFile()
        {
            string searchWord = "dog";
            string searchDirectory = "C:\\Users\\Usuario\\Desktop\\FilesTextSearchEngine\\DirectoryWithContent";

            SearchEngine searchEngine = new SearchEngine();
            searchEngine.InitializeSearchEngine(searchWord, searchDirectory);

            Assert.AreEqual("dog", searchEngine.GetSpecificFileContent(0));
        }
    }
}