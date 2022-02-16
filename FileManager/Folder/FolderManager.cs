using System;
using System.Collections.Specialized;
using System.IO;

namespace FileManager.FolderManager
{
    public static class FolderManager
    {
        public static void CreateFolder() 
        {
            Console.WriteLine(@"Please enter the top level folder directory or a drive(C:\).");
            string DirName = @"" + Console.ReadLine();
            if (!Directory.Exists(DirName))
            {
                Console.WriteLine("Top level Folder is  not exist.");
                return;
            }

            Console.WriteLine("Please enter the sub folder name.");
            string subFolderName = Console.ReadLine();

            try
            {
                string pathString = Path.Combine(DirName, subFolderName);

                Directory.CreateDirectory(pathString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ReadFolder() 
        {
            Console.WriteLine("Please enter the folder location.");
            DirectoryInfo folderLocation = new DirectoryInfo(Console.ReadLine());
            if (!folderLocation.Exists)
            {
                Console.WriteLine("Folder is not exist.");
                return;
            }

            StringCollection log = new StringCollection();

            DirectoryInfo[] directoryInfos = null;
            FileInfo[] files = null;

            try
            {
                directoryInfos = folderLocation.GetDirectories();
                files = folderLocation.GetFiles("*.*");
            }
            
            catch (UnauthorizedAccessException ex)
            {
                log.Add(ex.Message);
            }

            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (directoryInfos != null)
            {
                foreach (DirectoryInfo di in directoryInfos)
                {
                    Console.WriteLine(di.FullName);

                }
                if (files != null)
                {
                    foreach (FileInfo fi in files)
                    {
                        Console.WriteLine(fi.FullName);
                    }
                }
            } 
        }

        public static void UpdateFolder() 
        {
            Console.WriteLine("Please enter a path.");
            string path = @"" + Console.ReadLine();

            Console.WriteLine("Please enter a source path.");
            string from = @"" + Console.ReadLine();

            Console.WriteLine("Please enter a destination path.");
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
            Console.WriteLine("Please the folder location.");
            string topPath = @"" + Console.ReadLine();

            try
            {
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
            Console.WriteLine("Please enter the text file name.");
            string fileName = Console.ReadLine();

            Console.WriteLine("Please enter the folder source path.");
            string sourcePath = @"" + Console.ReadLine();

            Console.WriteLine("Please enter the folder target path.");
            string targetPath = @"" + Console.ReadLine();

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
        }

        public static void MoveFolder()
        {
            Console.WriteLine("Please enter the folder source directory.");
            string sourceDirectory = @"" + Console.ReadLine();

            Console.WriteLine("Please enter the folder destination directory.");
            string destinationDirectory = @"" + Console.ReadLine();

            try
            {
                if (Directory.Exists(sourceDirectory) && Directory.Exists(destinationDirectory))
                {
                    Directory.Move(sourceDirectory, destinationDirectory);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
