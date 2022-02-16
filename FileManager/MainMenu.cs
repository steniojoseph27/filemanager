using System;
using System.IO;

namespace FileManager
{
    public static class MainMenu
    {
        static uint GetUserChoice(Action printMenu, int choiceMax)
        {
            uint choice = 0;
            Action getInput = () =>
            {
                uint.TryParse(Console.ReadLine(), out choice);
            };
            getInput();
            while (choice < 1 || choice > choiceMax)
            {
                Console.WriteLine();
                Console.WriteLine("Please try again");
                Console.Clear();
                printMenu();
                getInput();
            }
            return choice;
        }

        public static void Menu()
        {
            try
            {
                Action printMenu = () =>
                {
                    Console.WriteLine("1) Folder Options");
                    Console.WriteLine("2) Text File Options");
                    Console.WriteLine("3) Exit");
                };
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Welcome to the File Manager application");
                Console.WriteLine();

                printMenu();
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
                uint choice = GetUserChoice(printMenu, 7);

                Console.WriteLine("Please type an option to navigate");

                switch (choice)
                {
                    case 1:
                        FolderOptions();
                        break;
                    case 2:
                        TextFileOptions();
                        break;
                    case 3:
                        Exit();
                        break;
                    default:
                        break;
                }

                Console.ReadLine();

                Menu();
            }
            catch (Exception ex)
            {
                Console.WriteLine("The error is: " + ex.Message);
            }
            
        }

        static void TextFileOptions()
        {
            Action printMenu = () =>
            {
                Console.WriteLine("Press 1 to create a text file.");
                Console.WriteLine("Press 2 to read a text file.");
                Console.WriteLine("Press 3 to update a text file.");
                Console.WriteLine("Press 4 to delete a text.");
                Console.WriteLine("Press 5 to copy and paste a text file.");
                Console.WriteLine("Press 6 to move a text file to another directory.");
                Console.WriteLine("Press 7 to return to the main menu.");
            };
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------"); // introducing the user with the menu 
            Console.WriteLine("Below is a list of actions that can be performed by the user!");
            Console.WriteLine();
            printMenu();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            uint choice = GetUserChoice(printMenu, 5);
            switch (choice)
            {
                case 1:
                    TextFileManager.TextFileManager.CreateTextFile();
                    break;
                case 2:
                    TextFileManager.TextFileManager.ReadTextFile();
                    break;
                case 3:
                    _ = TextFileManager.TextFileManager.UpdateTextFile();
                    break;
                case 4:
                    TextFileManager.TextFileManager.DeleteTextFile();
                    break;
                case 5:
                    TextFileManager.TextFileManager.CopyFile();
                    break;
                case 6:
                    TextFileManager.TextFileManager.MoveFiles();
                    break;
                case 7:
                    Menu();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        static void FolderOptions()
        {
            Action printMenu = () =>
            {
                Console.WriteLine("Press 1 to create a folder.");
                Console.WriteLine("Press 2 to go to a folder.");
                Console.WriteLine("Press 3 to update a folder name.");
                Console.WriteLine("Press 4 to delete a folder.");
                Console.WriteLine("Press 5 to copy and paste a folder.");
                Console.WriteLine("Press 6 to move a folder to another directory.");
                Console.WriteLine("Press 7 to return to the main menu.");
            };
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------"); // introducing the user with the menu 
            Console.WriteLine("Below is a list of actions that can be performed by user!");
            Console.WriteLine();
            printMenu();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            uint choice = GetUserChoice(printMenu, 5);
            switch (choice)
            {
                case 1:
                    FolderManager.FolderManager.CreateFolder();
                    break;
                case 2:
                    FolderManager.FolderManager.ReadFolder();
                    break;
                case 3:
                    FolderManager.FolderManager.UpdateFolder();
                    break;
                case 4:
                    FolderManager.FolderManager.DeleteFolder();
                    break;
                case 5:
                    FolderManager.FolderManager.CopyFolder();
                    break;
                case 6:
                    FolderManager.FolderManager.MoveFolder();
                    break;
                case 7:
                    Menu();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        static void Exit()
        {
            Environment.Exit(1);
        }

    }
}
