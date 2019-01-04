using System;
using System.Collections.Generic;

namespace MaciejWolf_Task1
{
    class Program
    {
        // Nested folders will be created in this directory
        private const string PARENT_DIRECTORY = @"C:";

        private static UserInterface ui = new UserInterface();
        private static Buzzer buzzer = new Buzzer();
        private static FileManager fileManager = new FileManager();
        private static FolderManager folderManager = new FolderManager(PARENT_DIRECTORY);

        static void Main(string[] args)
        {
            while(true)
            {
                ui.WriteLine("1. FizzBuzz\n" +
                    "2. DeepDive\n" +
                    "3. DrownItDown\n" +
                    "4. Exit\n");

                int opt = ui.GetUserInput(
                    "Choose option: ", 1, 4);

                if (4 == opt)
                    break;

                switch (opt)
                {
                    case 1:
                        Buzz();
                        break;
                    case 2:
                        CreateNestedFolders();
                        break;
                    case 3:
                        CreateFile();
                        break;
                }
            }
        }

        private static void Buzz()
        {
            int buzzerOption = ui.GetUserInput("Buzzer input: ", 0, 1000);
            ui.WriteLine(buzzer.getSignal(buzzerOption));
        }

        private static void CreateNestedFolders()
        {
            int depth = ui.GetUserInput("Depth: ", 1, 5);
            folderManager.CreateNestedFolders(depth);
        }

        private static void CreateFile()
        {
            if(folderManager.GetDepth() != 0)
            {
                int depth = ui.GetUserInput("Depth: ", 1, folderManager.GetDepth());
                string path = folderManager.getPath(depth);

                if (fileManager.ContainsFile(path))
                {
                    string option = ui.GetUserInput(
                        "Folder contains file. Do you want to overwrite it? Y/N",
                        new List<string>() { "Y", "N" });

                    if (option.Equals("Y"))
                    {
                        fileManager.DeleteFiles(path);
                        fileManager.CreateFile(path);
                    }
                }
                else
                {
                    fileManager.CreateFile(path);
                }
            }
            else
            {
                ui.WriteLine("Folder structure with depth doesn't exist. Use DeepDive to create it");
            }
        }
    }
}
