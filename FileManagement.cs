using System;
using System.IO;

public class FileManagement
{
    public int NumFiles { get; private set; }
    public string[] FilesNames { get; private set; }

    public void ObtainNumFilesAndFileNames(string targetDiretory)
    {
        if (Directory.Exists(targetDiretory))
        {
            string[] fileEntries = Directory.GetFiles(targetDiretory);

            NumFiles = fileEntries.Length;
            FilesNames = new string[NumFiles];

            for (int i = 0; i < fileEntries.Length; i++)
            {
                FilesNames[i] = fileEntries[i].Substring(fileEntries[i].LastIndexOf('\\') + 1);
            }
        }
        else
        {
            NumFiles = 0;
            FilesNames = null;
        }
    }
 
    public char[] StoreContentIntoCharArray(string fileName)
    {
        char[] fileContent = null;

        return fileContent;
    }

}
