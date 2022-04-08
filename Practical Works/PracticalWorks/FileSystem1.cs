using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_Works.PracticalWorks
{
    class FileSystem1
    {
        public static void Task1() 
        {
            foreach (var drive in DriveInfo.GetDrives())
                PrintDriveInfo(drive);
        }

        private static void PrintDriveInfo(DriveInfo drive)
        {
            int maxSize = 100;
            string name = drive.Name;
            long totalSize = drive.TotalSize;
            long freeSpace = drive.TotalFreeSpace;

            double ratio = ((double)freeSpace) / totalSize;

            int freeLength = (int)(ratio * maxSize);
            int totalLength = maxSize - freeLength;

            Console.WriteLine("Диски:");
            Console.WriteLine(name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Green;

            Console.Write($"{string.Join("", Enumerable.Repeat(" ", freeLength))}");
            Console.CursorLeft = 0;
            Console.Write($"{ratio * 100:0.00}");

            Console.BackgroundColor = ConsoleColor.Red;
            Console.CursorLeft = freeLength;
            Console.Write($"{string.Join("", Enumerable.Repeat(" ", totalLength))}");
            Console.CursorLeft = freeLength;
            Console.Write($"{(1 - ratio) * 100:0.00}\n");
            Console.ResetColor();

            Console.WriteLine($"{("Свободно: "), -10}{freeSpace}\n{("Всего: "), -10}{totalSize}");
        }

        public static void Task2() 
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string group = $"{desktop}/Группа";
            if (Directory.Exists(group) == false)
                Directory.CreateDirectory(group);
            
            if (Directory.Exists($"{group}/Группа 123") == false)
                Directory.CreateDirectory($"{group}/Группа 123");
            
            if (Directory.Exists($"{group}/Группа 223") == false)
                Directory.CreateDirectory($"{group}/Группа 223");
            
            if (Directory.Exists($"{group}/Группа 323") == false)
                Directory.CreateDirectory($"{group}/Группа 323");

            Menu.CreateFolderView($"{desktop}");
        }

        public static void Task3() 
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Menu.CreateFolderView($"{desktop}/Группа");
        }

        public static void Task4() 
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (Directory.Exists($"{desktop}/Группа/Группа 323"))
                Directory.Delete($"{desktop}/Группа/Группа 323");
            Menu.CreateFolderView($"{desktop}/Группа");
        }

        public static void Task5() 
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (File.Exists($"{desktop}/Группа/База данных 123 группа.xlsx"))
                File.Move($"{desktop}/Группа/База данных 123 группа.xlsx", $"{desktop}/Группа/Группа 123/База данных 123 группа");
            
            if (File.Exists($"{desktop}/Группа/Сводный лист 223 группа.xlsx"))
                File.Move($"{desktop}/Группа/Сводный лист 223 группа.xlsx", $"{desktop}/Группа/Группа 223/Сводный лист 223 группа.xlsx");

            Menu.CreateFolderView($"{desktop}/Группа");
        }

        public static void Task6() 
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Console.WriteLine("Группа 223:");
            DirectoryInfo directory = new($"{desktop}/Группа/Группа 223");
            Console.WriteLine($"Последнее изменение: {directory.LastWriteTime}\nПолный путь: {directory.FullName}\nРодительский каталог: {directory.Parent}");
        }
    }
}
