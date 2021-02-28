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
 
    public void StoreContentIntoCharArray(string targetDirectory, ref char[][] fileContents)
    {
        if (Directory.Exists(targetDirectory))
        {
            for (int i = 0; i < FilesNames.Length; i++)
            {
                string filePath = targetDirectory + "\\" + FilesNames[i];
                using (StreamReader sr = new StreamReader(filePath))
                {
                    fileContents[i] = new char[sr.BaseStream.Length];
                    int j = 0;
                    while (sr.Peek() >= 0)
                    {
                        fileContents[i][j] += (char)sr.Read();
                        j++;
                    }
                }
            }
        }
    }
}
