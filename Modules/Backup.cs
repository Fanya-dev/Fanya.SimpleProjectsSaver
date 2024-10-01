using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fanya.SimpleProjectsSaver.Modules
{
    public static class Backup
    {
        public static Dictionary<string, List<string>> Derictories = new();
        public static Dictionary<string, List<string>> Files = new();
        public static int count = new();
        public static void Start()
        {
            DateTime now = DateTime.Now;
            string currentPath = Directory.GetCurrentDirectory();
            string backupPath = currentPath + "/backup_" + now.Day + "_" + now.Month + "_" + now.Year + "_" + now.Hour + "_" + now.Minute;
            count = currentPath.Length;
            Console.WriteLine("Собираю данные...");
            GetFoldersAndFiles(currentPath, 1);
            Directory.CreateDirectory(backupPath);
            Console.WriteLine("Создание бэкапа...");
            foreach (string folder in Program.CopyFolder)
            {
                Directory.CreateDirectory(backupPath + folder);
            }
            foreach (string file in Program.CopyFiles)
            {
                File.Copy(currentPath + file, backupPath + file, false);
            }
            
        }

        public static void GetFoldersAndFiles(string path, int level)
        {
            Derictories[path] = Directory.GetDirectories(path).ToList();
            Files[path] = Directory.GetFiles(path).ToList();

            foreach (string directory in Derictories[path])
            {
                string localPathDirectory = directory.Remove(0, count);
                //for (int i = 0; i < level; i++) DEBUG
                //{
                //    Console.Write(".");
                //}
                //Console.WriteLine(directory);
                Program.CopyFolder.Add(localPathDirectory);
                GetFoldersAndFiles(directory, (level + 1));
                if((directory.Contains("\\.git") || directory.Contains("/.git")) && !(directory.Contains("\\.git\\") || directory.Contains("/.git/"))) break;
            }

            foreach (string file in Files[path])
            {
                string localPathFile = file.Remove(0, count);
                Program.CopyFiles.Add(localPathFile);
            }
        }
    }
}
