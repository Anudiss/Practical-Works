using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Practical_Works.PracticalWorks
{
    class Methods
    {   
        public static void Task1()
        {
            string[] input;
            while((input = Menu.CreateInputMenu("Сочетание", 50, "K", "N").ToArray()).All(e => e.Trim() == "") == false)
            {
                if (Regex.IsMatch(input[0], @"\d+") == false ||
                    Regex.IsMatch(input[1], @"\d+") == false)
                {
                    Menu.ShowErrorMenu("Ошибка", "Неверный ввод");
                    continue;
                }

                int k = int.Parse(input[0]);
                int n = int.Parse(input[1]);
                int combination = Factorial(n) / (Factorial(k) * (Factorial(n - k)));
                Menu.CreateConfirmMenu("Задание 1", $"C({k}, {n}) = {combination}");
                break;
            }
        }

        private static int Factorial(int n)
        {
            if (n <= 1)
                return 1;
            return n * Factorial(n - 1);
        }

        public static void Task2()
        {
            string[] input;
            while ((input = Menu.CreateInputMenu("Сочетание", 50, "K", "N").ToArray()).All(e => e.Trim() == "") == false)
            {
                if (Regex.IsMatch(input[0], @"\d+") == false ||
                    Regex.IsMatch(input[1], @"\d+") == false)
                {
                    Menu.ShowErrorMenu("Ошибка", "Неверный ввод");
                    continue;
                }

                int k = int.Parse(input[0]);
                int n = int.Parse(input[1]);
                int combination = Factorial(n) / (Factorial(k) * (Factorial(n - k)));
                Menu.CreateConfirmMenu("Задание 2", $"C({k}, {n}) = {combination}");
                break;
            }
        }

        public static void Factorial(int n, out int f)
        {
            if (n <= 1)
                f = 1;
            else
            {
                Factorial(n - 1, out int f1);
                f = n * f1;
            }
        }

        public static void Task3()
        {
            string input = Menu.CreateInputMenu("Введите строку с верхним и нижнем регистром", 50, "Строка").First();
            Menu.CreateConfirmMenu("Результат", $"{input} => {RegisterSwitching(input)}", 50, "Ок");
        }

        private static string RegisterSwitching(string word)
        {
            StringBuilder switchedRegister = new();
            foreach (var c in word) {
                if (Char.IsUpper(c))
                    switchedRegister.Append(Char.ToLower(c));
                else
                    switchedRegister.Append(Char.ToUpper(c));
            }
            return switchedRegister.ToString();
        }

        public static void Task4()
        {
            int n = (int)Menu.CreateInputMenu("Введите длину массива", 50, ("Длина", InputType.Int)).First();
            Random random = new();
            int[] array = new int[n].Select(e => random.Next(-10, 10)).ToArray();
            int moreThenAverage = MoreThenAverage(array, out double average);
            Menu.CreateConfirmMenu("Количество элементов больше среднего", $"[{string.Join(", ", array)}]\nКоличество элементов больше среднего значения ({average}) = {moreThenAverage}", 50, "Ок");
        }

        private static int MoreThenAverage(int[] array, out double average)
        {
            average = array.Average();
            return array.Count(e => e < array.Average());
        }

        public static void Task5()
        {
            int[] input = Menu.CreateInputMenu("Введите размер матрицы", 50, ("Колонки", InputType.Int), ("Строки", InputType.Int)).Select(e => (int)e).ToArray();
            Random random = new();
            int[,] matrix = new int[input[0], input[1]].Select((e, x, y) => (random.Next(-10, 10), x, y)).ToArray();
            int[,] sorted = matrix.Clone() as int[,];
            for(int x = 0; x < matrix.GetLength(0); x++)
            {
                if (x % 2 == 0)
                    AscendingOrderColumn(ref sorted, x);
                else
                    DescendingOrderColumn(ref sorted, x);
            }
            Menu.CreateConfirmMenu("Матрица", $"Исходная мартица:\n{matrix.ToFormattedString()}\nСортированная матрица:\n{sorted.ToFormattedString()}", 50, "Ок");
        }

        private static void AscendingOrderColumn(ref int[,] matrix, int column)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = i; j < matrix.GetLength(1); j++)
                {
                    if (matrix[column, i] < matrix[column, j])
                    {
                        int buffer = matrix[column, i];
                        matrix[column, i] = matrix[column, j];
                        matrix[column, j] = buffer;
                    }
                }
            }
        }

        private static void DescendingOrderColumn(ref int[,] matrix, int column)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = i; j < matrix.GetLength(1); j++)
                {
                    if (matrix[column, i] > matrix[column, j])
                    {
                        int buffer = matrix[column, i];
                        matrix[column, i] = matrix[column, j];
                        matrix[column, j] = buffer;
                    }
                }
            }
        }

    }
}
