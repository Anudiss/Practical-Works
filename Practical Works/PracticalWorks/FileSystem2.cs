using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_Works.PracticalWorks
{
    class FileSystem2
    {
        public static void Task1()
        {
            string root = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/Файловая система2";
            if (Directory.Exists(root) == false)
                Directory.CreateDirectory(root);
            if (File.Exists($"{root}/Работники.txt") == false)
                File.Create($"{root}/Работники.txt").Close();

            Menu.CreateFolderView(root);

            List<string> workers = new();
            using (var reader = new StreamReader($"{root}/Работники.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                    workers.Add(line);
            }
            Menu.CreateConfirmMenu("Работники", string.Join("\n", workers), 50, "Ок");
        }

        public static void Task2()
        {
            string table = "";
            for(int i = 1; i <= 5; i++)
            {
                for(int j = 1; j <= 10; j++)
                {
                    table += $"{($"{i} * {j} = {i * j}"), 15}{($"{i + 5} * {j} = {(i + 5) * j}"), 15}\n";
                }
            }

            string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/Файловая система2/Таблица умножение.txt";
            if (File.Exists(path) == false)
                File.Create(path).Close();

            using (var writer = new StreamWriter(path))
            {
                writer.Write(table);
                writer.Close();
            }

            using var reader = new StreamReader(path);
            string line;
            while ((line = reader.ReadLine()) != null)
                Console.WriteLine(line);
            reader.Close();
        }

        public static void Task3()
        {
            string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/Файловая система2/223 Группа.txt";

            using var writer = new StreamWriter(path, true);
            writer.Write("Привет, 223 группа!!!");
            writer.Write("Вы очень шумные на парах!!!");
            writer.Write("Это надо исправлять");
            writer.Close();

            Menu.CreateFileEditor($"{path}");
        }
    }
}
