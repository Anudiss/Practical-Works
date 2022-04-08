using System;
using System.Collections.Generic;
using System.Linq;

namespace Practical_Works.PracticalWorks
{
    class TwoDimensionalArrays
    {
        public static void Task1()
        {
            int[,] matrix = GenerateRandomMatrix(11, 5, -5, 5);
            int linesCount = 0;
            var lines = matrix.Select((e, x, y) => (e, x, y)).GroupBy(e => e.y);
            foreach(var line in lines)
            {
                linesCount += line.Where(e => e.e != 0).Count() != line.Count() ? 0 : 1; 
            }
            Menu.CreateConfirmMenu("Задание 1", $"{matrix.ToFormattedString()}\nКоличество строк без нулей: {linesCount}");
        }

        public static void Task2()
        {
            int[,] matrix = GenerateRandomMatrix(5, 5, 0, 5);
            int sum = 0;
            for (int x = 0; x < matrix.GetLength(0); x++)
                for (int y = x; y < matrix.GetLength(1); y++)
                    sum += matrix[x, y];
            Menu.CreateConfirmMenu("Задание 1", $"{matrix.ToFormattedString()}\nСумма чисел под главной диагональю: {sum}", 50, "Ок");
        }
        
        public static void Task3()
        {
            int[,] matrix = GenerateRandomMatrix(5, 5, -5, 5);
            List<(int x, int y)> points = new();
            foreach (var point in matrix.Select((e, x, y) => (e, x, y)))
            {
                IEnumerable<(int e, int x, int y)> select = matrix.Select((e, x, y) => (e, x, y));
                IEnumerable<(int e, int x, int y)> row = select.Where(e => e.y == point.y);
                IEnumerable<(int e, int x, int y)> col = select.Where(e => e.x == point.x);

                if (row.Max(e => e.e) == point.e &&
                    col.Min(e => e.e) == point.e)
                    points.Add((point.x, point.y));
            }

            Menu.CreateConfirmMenu("Задание 3", $"{matrix.ToFormattedString()}\nСедловые точки:\n{string.Join("\n", points)}", 50, "Ок");
        }
        
        public static void Task4()
        {
            int[,] matrix1 = GenerateRandomMatrix(3, 3, -3, 3);
            int[,] matrix2 = GenerateRandomMatrix(3, 3, -3, 3);
            int[,] multiplied = Multiply(matrix1, matrix2);
            Menu.CreateConfirmMenu("Задание 4", $"Матрица 1:\n{matrix1.ToFormattedString()}\nМатрица 2:\n{matrix2.ToFormattedString()}\nМатрица 1 * Матрицу 2:\n{multiplied.ToFormattedString()}", 50, "Ок");
        }

        private static int[,] Multiply(int[,] m1, int[,] m2)
        {
            if (m1.GetLength(1) != m2.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
            int[,] r = new int[m1.GetLength(0), m2.GetLength(1)];
            for (int i = 0; i < m1.GetLength(0); i++)
            {
                for (int j = 0; j < m2.GetLength(1); j++)
                {
                    for (int k = 0; k < m2.GetLength(0); k++)
                    {
                        r[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }
            return r;
        }

        private static int[,] GenerateRandomMatrix(int cols, int rows, int min, int max)
        {
            int[,] matrix = new int[cols, rows];
            Random random = new();
            for (int x = 0; x < cols; x++)
                for (int y = 0; y < rows; y++)
                    matrix[x, y] = random.Next(min, max);
            return matrix;
        }
    }
}
