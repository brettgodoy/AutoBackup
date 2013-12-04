using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace AutoBackup
{
    public class Class1
    {
        List<FileInfo> fileList = new List<FileInfo>();

        static void Main() 
        {
            string backupSource = "Enter source folder here";
            string backupDest = "Enter destination folder here";

            Class1 class1 = new Class1();
            DirectoryInfo sourceDirInfo = class1.DirInfo(backupSource);
            List<FileInfo> fileList = class1.FindFiles(sourceDirInfo);
            class1.CopyFiles(fileList, backupDest);

            Console.WriteLine("Done!");
            Console.ReadLine();
        }

        public DirectoryInfo DirInfo(string backupSource)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(backupSource);
            return dirInfo;
        }


        public List<FileInfo> FindFiles(DirectoryInfo dirInfo)
        {
            
            foreach (FileInfo f in dirInfo.GetFiles())
            {
                fileList.Add(f);
            }
            foreach (DirectoryInfo d in dirInfo.GetDirectories())
            {
                FindFiles(d);
            }
            return fileList;

        }

        public void CopyFiles(List<FileInfo> fileList, string backupDest) 
        {
            foreach (FileInfo info in fileList)
            {
                string filePath = info.FullName;
                string fileName = System.IO.Path.GetFileName(filePath);
                string destFile = System.IO.Path.Combine(backupDest, fileName);
                System.IO.File.Copy(filePath, destFile, true);
            }
        }
    }
}
