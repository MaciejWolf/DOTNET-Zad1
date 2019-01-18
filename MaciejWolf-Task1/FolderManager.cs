using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi
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
            if (0 != folders.Count)
            {
                DeleteFolders();
            }

            if (depth >= 1)
            {
                CreateNestedFolders(PARENT_DIRECTORY, depth);
            }
        }

        public string GetPath(int depth)
        {
            string path = PARENT_DIRECTORY;

            for (int i = 0; i < depth; i++)
            {
                path = System.IO.Path.Combine(path, folders[i]);
            }

            return path;
        }

        private void CreateNestedFolders(String path, int depth)
        {
            string guid = CreateFolder(path);

            folders.Add(guid);

            path = System.IO.Path.Combine(path, guid);

            if (depth > 1)
            {
                CreateNestedFolders(path, depth - 1);
            }
        }

        private string CreateFolder(String path)
        {
            string foderName = Guid.NewGuid().ToString();

            path = System.IO.Path.Combine(path, foderName);

            System.IO.Directory.CreateDirectory(path);

            return foderName;
        }

        private void DeleteFolders()
        {
            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(GetPath(1));

            GC.Collect();
            GC.WaitForPendingFinalizers();

            directoryInfo.Delete(true);
            folders.RemoveRange(0, folders.Count);
        }
    }
}
