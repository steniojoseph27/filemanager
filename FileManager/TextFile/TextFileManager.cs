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
            Console.WriteLine("Please enter a directory to add the file.");
            string fileDir = @"" + Console.ReadLine();

            Console.WriteLine("Please give the file a name.");
            string fileName = Console.ReadLine();

            if (!File.Exists(fileDir))
            {
                using (FileStream fs = File.Create(fileDir))
                {
                    Console.WriteLine("Text file created!");
                }
            }
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", fileName);
            }
        }

        public static void ReadTextFile()
        {
            Console.WriteLine("Please enter the directory to locate the file.");
            string fileDir = @"" + Console.ReadLine();

            if (File.Exists(fileDir))
            {
                try
                {
                    string text = File.ReadAllText(fileDir);

                    Console.WriteLine($"Contents of {fileDir} = {text}");
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static async Task UpdateTextFile() 
        {
            Console.WriteLine("Please enter the file directory to be updated.");
            string fileDir = @"" + Console.ReadLine();

            if (File.Exists(fileDir))
            {
                try
                {
                    Console.WriteLine("Please enter the text to be added.");
                    string text = Console.ReadLine();

                    await File.WriteAllTextAsync(fileDir, text);
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
        }

        public static void DeleteTextFile() 
        {
            Console.WriteLine("Please enter the file directory to be deleted.");
            string fileDir = @"" + Console.ReadLine();

            if (File.Exists(fileDir))
            {
                try
                {
                    File.Delete(fileDir);
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void CopyFile()
        {
            Console.WriteLine("Please enter the file directory to be copied.");
            string fileName = Console.ReadLine();
            if (!File.Exists(fileName))
            {
                Console.WriteLine("The file cannot be located.");
                return;
            }

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
            try
            {
                string sourceFile = Path.Combine(sourcePath, fileName);
                string destFile = Path.Combine(targetPath, fileName);

                Directory.CreateDirectory(targetPath);

                File.Copy(sourceFile, destFile, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void MoveFiles()
        {
            Console.WriteLine("Please enter the file source directory.");
            string sourceFile = @"" + Console.ReadLine();
            if (!File.Exists(sourceFile))
            {
                Console.WriteLine("The file cannot be located.");
                return;
            }

            Console.WriteLine("Please enter the file destination directory.");
            string destinationFile = @"" + Console.ReadLine();
            if (!File.Exists(destinationFile))
            {
                Console.WriteLine("The file cannot be located.");
                return;
            }

            try
            {
                File.Move(sourceFile, destinationFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
