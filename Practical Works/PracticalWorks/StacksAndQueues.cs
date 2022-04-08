using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Practical_Works.PracticalWorks
{
    class StacksAndQueues
    {
        public static void Task1() 
        {
            Queue<int> queue = new();
            Random random = new();
            for (int i = 0; i < 10; i++)
                queue.Enqueue(random.Next(0, 20));

            Menu.CreateConfirmMenu("Задание 1", $"[ {string.Join(", ", queue)} ]\nКоличество элементов очереди меньших 10: {queue.Where(e => e < 10).Count()}", "Ок");

        }

        public static void Task2() 
        {
            Queue<(string surname, int salary)> workers = new();
            string[] input;
            while ((input = Menu.CreateInputMenu("Введите данные о рабочем",
                                                 "Фамилия", "Оклад").ToArray()).Any(e => e.Trim() != ""))
            {
                if (workers.Count > 0)
                    Menu.CreateTextMenu("Рабочие:", $"{string.Join("\n", workers)}", 0, 0, workers.Select(e => $"{e}").Max(e => e.Length));
                if (Regex.IsMatch(input[1], @"\d+") == false)
                {
                    Menu.ShowErrorMenu("Ошибка", "Неверный ввод");
                    continue;
                }

                workers.Enqueue((input[0], int.Parse(input[1])));
                Menu.CreateTextMenu("Рабочие:", $"{string.Join("\n", workers)}", 0, 0, workers.Select(e => $"{e}").Max(e => e.Length));
            }

            Menu.CreateConfirmMenu("Задание 2", $"Рабочие:\n\t{string.Join("\n\t", workers)}\nСредний оклад рабочих: {workers.Average(e => (float)e.salary)}", "Ок");
        }

        public static void Task3() 
        {
            Queue<(string name, double frequency, int coreCount)> processors = new();
            string[] input;
            while ((input = Menu.CreateInputMenu("Введите данные о процессоре",
                                                 50, "Название", "Тактовая частота", "Количество ядер").ToArray()).Any(e => e.Trim() != ""))
            {
                if (processors.Count > 0)
                    Menu.CreateTextMenu("Процессоры:", $"{string.Join("\n", processors)}", 0, 0, processors.Select(e => $"{e}").Max(e => e.Length));

                input[1] = Regex.Replace(input[1], @"[\.]", ",");
                if (Regex.IsMatch(input[1], @"\d+(,\d+)?") == false ||
                    Regex.IsMatch(input[2], @"\d+") == false) 
                {
                    Menu.ShowErrorMenu("Ошибка", "Неверный ввод");
                    continue;
                }

                processors.Enqueue((input[0], double.Parse(input[1]), int.Parse(input[2])));
                Menu.CreateTextMenu("Процессоры:", $"{string.Join("\n", processors)}", 0, 0, processors.Select(e => $"{e}").Max(e => e.Length));
            }

            Menu.CreateConfirmMenu("Задание 3", $"Процессоры:\n\t{string.Join("\n\t", processors)}\nМногоядерные процессоры:\n{string.Join("\n", processors.Where(e => e.coreCount > 1))}", "Ок");
        }

        public static void Task4() 
        {
            Stack<double> stack = new();
            stack.Push(-5, 2, 72.3, 2.3, 18,4, -16.3);

            Menu.CreateConfirmMenu("Задание 4", $"Стек:\n[ {string.Join(", ", stack)} ]\nМаксимальный элемент стэка: {stack.Max()}", "Ок");
        }

        public static void Task5()
        {
            Stack<string> stack = new();
            stack.Push("group", "220", "study", "hello, group", "are you ready");
            Menu.CreateConfirmMenu("Задание 5", $"[ {string.Join(", ", stack)} ]", "Ок");
            
            stack.Pop();
            stack.Pop();

            Menu.CreateConfirmMenu("Задание 5", $"[ {string.Join(", ", stack)} ]\nСтрока минимальной длины: {stack.OrderBy(e => e.Length).First()}", "Ок");
        }
    }
}
