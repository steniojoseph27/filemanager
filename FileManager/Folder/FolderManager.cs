using System;
using System.Collections.Specialized;
using System.IO;

namespace FileManager.FolderManager
{
    public static class FolderManager
    {
        public static void CreateFolder() 
        {
            string folderDirName = @"" + Console.ReadLine();
            string subFolderName = Console.ReadLine();

            if (!Directory.Exists(folderDirName))
            {
                Console.WriteLine("Top-Level Folder is  not exist.");
                return;
            }
            string pathString = Path.Combine(folderDirName, subFolderName);

            Directory.CreateDirectory(pathString);
        }

        public static void ReadFolder() 
        {
            DirectoryInfo  root = new DirectoryInfo(Console.ReadLine());
            StringCollection log = new StringCollection();

            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;

            try
            {
                files = root.GetFiles("*.*");
            }
            
            catch (UnauthorizedAccessException e)
            {
                log.Add(e.Message);
            }

            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                foreach (FileInfo fi in files)
                {
                    Console.WriteLine(fi.FullName);
                }

                subDirs = root.GetDirectories();

                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    ReadFolder();
                }
            }
        }

        public static void UpdateFolder() 
        {
            string path = @"" + Console.ReadLine();
            string from = @"" + Console.ReadLine();
            string to = @"" + Console.ReadLine();

            string prefix = path;
            string[] folders = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);
            foreach (string folder in folders)
            {
                UpdateFolder();

                string newFolderName = prefix + folder.Substring(prefix.Length).Replace(from, to);

                if (newFolderName != folder)
                    Directory.Move(folder, newFolderName);
            }
        }

        public static void DeleteFolder() 
        {
            string topPath = @"" + Console.ReadLine();
            //string subPath = @"C:\NewDirectory\NewSubDirectory";

            try
            {
                //Directory.CreateDirectory(subPath);

                //using (StreamWriter writer = File.CreateText(subPath + @"\example.txt"))
                //{
                //    writer.WriteLine("content added");
                //}

                Directory.Delete(topPath, true);

                bool directoryExists = Directory.Exists(topPath);

                Console.WriteLine("top-level directory exists: " + directoryExists);
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.Message);
            }
        }

        public static void CopyFolder()
        {
            string fileName = "test.txt";
            string sourcePath = @"C:\Users\Public\TestFolder";
            string targetPath = @"C:\Users\Public\TestFolder\SubDir";

            string sourceFile = Path.Combine(sourcePath, fileName);
            string destFile = Path.Combine(targetPath, fileName);

            Directory.CreateDirectory(targetPath);

            File.Copy(sourceFile, destFile, true);

            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);

                foreach (string s in files)
                {
                    fileName = Path.GetFileName(s);
                    destFile = Path.Combine(targetPath, fileName);
                    File.Copy(s, destFile, true);
                }
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        public static void MoveFolder()
        {
            string sourceDirectory = @"" + Console.ReadLine();
            string destinationDirectory = @"" + Console.ReadLine();

            try
            {
                Directory.Move(sourceDirectory, destinationDirectory);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
