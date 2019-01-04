using System;
using System.Collections.Generic;
using System.Text;

namespace MaciejWolf_Task1
{
    class FolderManager
    {
        private readonly string PARENT_DIRECTORY;

        private List<string> folders = new List<string>();

        public FolderManager(string parentDirectory)
        {
            PARENT_DIRECTORY = parentDirectory;
        }

        public int GetDepth()
        {
            return folders.Count;
        }

        public void CreateNestedFolders(int depth)
        {
            if(0 != folders.Count)
                DeleteFolders();

            if(depth >= 1)
                createNestedFolders(PARENT_DIRECTORY, depth);

            foreach (string folder in folders)
            {
                Console.WriteLine(folder);
            }
        }

        public string getPath(int depth)
        {
            string path = PARENT_DIRECTORY;

            for (int i = 0; i < depth; i++)
            {
                path = System.IO.Path.Combine(path, folders[i]);
            }

            return path;
        }

        private void createNestedFolders(String path, int depth)
        {
            string guid = createFolder(path);

            folders.Add(guid);

            path = System.IO.Path.Combine(path, guid);

            if(depth > 1)
                createNestedFolders(path, depth - 1);
        }

        private string createFolder(String path)
        {
            string foderName = Guid.NewGuid().ToString();

            path = System.IO.Path.Combine(path, foderName);

            System.IO.Directory.CreateDirectory(path);

            return foderName;
        }

        private void DeleteFolders()
        {
            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(getPath(1));

            GC.Collect();
            GC.WaitForPendingFinalizers();

            directoryInfo.Delete(true);
            folders.RemoveRange(0, folders.Count);
        }
    }
}
