using System;
using System.IO;

namespace FileSystem
{
    internal class Program
    {
        public static void driveInfo()
        {
           DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine(drive.Name);
                Console.WriteLine(drive.DriveType);
                if(drive.IsReady)
                {
                    Console.WriteLine($"размер диска {drive.TotalSize}");
                    Console.WriteLine($"размер свободного пространства {drive.TotalFreeSpace}");
                    Console.WriteLine($"метка диска {drive.VolumeLabel}");
                }
            }
        }

        #region Directories
        public static void dirInfo(string dirName)
        {
            

            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Подкаталоги:");
                string[] dirs = Directory.GetDirectories(dirName);
                foreach (string dir in dirs) Console.WriteLine(dir);

                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);
                foreach (string file in files)
                {
                    Console.WriteLine(file);
                }
            }
        }

        public static void FindExe(string dirName)
        {
            string[] files = Directory.GetFiles(dirName, "*.exe");
            foreach(string file in files) Console.WriteLine(file);
            if (files.Length == 0) Console.WriteLine("Not Found");
        }
        public static void CreateCatalog(string dirName)
        {
            string subpath = @"program/avalon";
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(subpath);
            }
            Directory.CreateDirectory($"{dirName}/{subpath}");
        }

        public static void RemoveDirectory(string dirName)
        {
            string someString = "D:\\program";
            if (Directory.Exists(someString)) 
            {
                Directory.Delete(someString, true);
                Console.WriteLine("Каталог удален!");
            }
            else Console.WriteLine("Каталог не существует!");
        }
        #endregion

        #region Files

        public static void fileInfo(string path)
        {
            
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                Console.WriteLine($"Имя файла: {fileInfo.Name}");
                Console.WriteLine($"Время создания: {fileInfo.CreationTime}");
                Console.WriteLine($"Размер: {fileInfo.Length}");
            }
        }
        public static void fileRemove(string path)
        {

            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                Console.WriteLine($"Файл {fileInfo.Name} удален");
                fileInfo.Delete();
            }
        }
        public static void fileCopy(string path, string newPath)
        {

            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                fileInfo.CopyTo(newPath, true);
                Console.WriteLine($"Файл: {fileInfo.Name} Скопирован в директорию {newPath}");
                
            }
        }

        #endregion

        static void ReadingAndWritingFile(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            /*if (!fileInfo.Exists)
            {
                fileInfo.Create();
            }*/
            Console.WriteLine("Введите строку для записи:");
            var text = Console.ReadLine();

            using (FileStream fs = new FileStream($"{path}\\note.txt", FileMode.OpenOrCreate))
            {
                byte[] arr = System.Text.Encoding.Default.GetBytes(text); //преобразование стринга в массив байт
                //запись массива в файл
                fs.Write(arr, 0, arr.Length);
                Console.WriteLine("Текст записан в файл");
            }

            //чтение из файла:
            using(FileStream fs = File.OpenRead($"{path}\\note.txt"))
            {
                byte[] arr = new byte[fs.Length];
                fs.Read(arr, 0,arr.Length);
                //декодируем байты в строку:
                string textFromFile = System.Text.Encoding.Default.GetString(arr);
                Console.WriteLine($"Текст из файла: {textFromFile}");
            }
        }
        static void Main(string[] args)
        {
            /*string dirName = "D:\\";
            driveInfo(); //информация о носителях
            dirInfo(dirName);//информация о папках и файлах в C:\\
            FindExe(dirName); //находит файлы *.exe
            CreateCatalog(dirName); //создает подкаталог program/avalon
             RemoveDirectory(dirName);*/

            //===============================//
            /*string fileName = @"D:\apache\hello.txt";
            string fileNewName = @"D:\hello.txt";
            fileInfo(fileName);
            //fileRemove(fileName);
            fileCopy(fileName, fileNewName);*/

            //===============================//
            string path2 = @"D:\apache";
            ReadingAndWritingFile(path2);


        }
    }
}
