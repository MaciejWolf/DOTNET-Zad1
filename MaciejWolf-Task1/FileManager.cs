using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MaciejWolf_Task1
{
    class FileManager
    {
        public bool ContainsFile(string path)
        {
            return Directory.GetFiles(path).Length != 0;
        }

        public void CreateFile(string path)
        {
            string fileName = Guid.NewGuid().ToString();

            path = Path.Combine(path, fileName);
            File.Create(path);

        }

        public void DeleteFiles(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            foreach (FileInfo fi in directoryInfo.GetFiles())
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                if (fi.Exists)
                {
                    fi.Delete();
                }
            }
        }
    }
}
