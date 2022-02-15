using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.TextFileManager
{
    public static class TextFileManager
    {
        public static void CreateTextFile() 
        {
            string folderName = @"c:\Top-Level Folder";

            string pathString = Path.Combine(folderName, "SubFolder");

            Directory.CreateDirectory(pathString);

            string fileName = Path.GetRandomFileName();

            pathString = Path.Combine(pathString, fileName);

            Console.WriteLine("Path to my file: {0}\n", pathString);

            if (!File.Exists(pathString))
            {
                using (FileStream fs = File.Create(pathString))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }
            }
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", fileName);
                return;
            }

            try
            {
                byte[] readBuffer = File.ReadAllBytes(pathString);
                foreach (byte b in readBuffer)
                {
                    Console.Write(b + " ");
                }
                Console.WriteLine();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        public static void ReadTextFile() 
        {
            string text = File.ReadAllText(@"C:\Users\Public\TestFolder\WriteText.txt");

            Console.WriteLine("Contents of WriteText.txt = {0}", text);

            string[] lines = File.ReadAllLines(@"C:\Users\Public\TestFolder\WriteLines2.txt");

            Console.WriteLine("Contents of WriteLines2.txt = ");
            foreach (string line in lines)
            {
                Console.WriteLine("\t" + line);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        public static async Task UpdateTextFile() 
        {
            string text =
            "A class is the most powerful data type in C#. Like a structure, " +
            "a class defines the data and behavior of the data type. ";

            await File.WriteAllTextAsync("WriteLines.txt", text);
        }

        public static void DeleteTextFile() 
        {
            if (File.Exists(@"C:\Users\Public\DeleteTest\test.txt"))
            {
                try
                {
                    File.Delete(@"C:\Users\Public\DeleteTest\test.txt");
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
        }

        public static void CopyFile()
        {
            Console.WriteLine("Please enter the file name: ");
            string fileName = Console.ReadLine();

            Console.WriteLine("Please enter the source path: ");
            string sourcePath = @"" + Console.ReadLine();
            if (!Directory.Exists(sourcePath))
            {
                Console.WriteLine("Invalid source path.");
                return;
            }

            Console.WriteLine("Please enter the target path: ");
            string targetPath = @"" + Console.ReadLine();
            if (!Directory.Exists(targetPath))
            {
                Console.WriteLine("Invalid target path.");
                return;
            }

            string sourceFile = Path.Combine(sourcePath, fileName);
            string destFile = Path.Combine(targetPath, fileName);

            Directory.CreateDirectory(targetPath);

            File.Copy(sourceFile, destFile, true);

            //Console.WriteLine("Press any key to exit.");
            //Console.ReadKey();
        }

        public static void MoveFiles()
        {
            /*
             * 
             * string sourceFile = @"C:\Users\Public\public\test.txt";
                string destinationFile = @"C:\Users\Public\private\test.txt";

                // To move a file or folder to a new location:
                System.IO.File.Move(sourceFile, destinationFile);

                // To move an entire directory. To programmatically modify or combine
                // path strings, use the System.IO.Path class.
                System.IO.Directory.Move(@"C:\Users\Public\public\test\", @"C:\Users\Public\private");
             * 
             */

            string sourceDirectory = @"" + Console.ReadLine();
            string archiveDirectory = @"" + Console.ReadLine();

            try
            {
                var txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.txt");

                foreach (string currentFile in txtFiles)
                {
                    string fileName = currentFile.Substring(sourceDirectory.Length + 1);
                    Directory.Move(currentFile, Path.Combine(archiveDirectory, fileName));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
