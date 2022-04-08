using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_Works.PracticalWorks
{
    class Recursion
    {

        public static void Task1()
        {
            int[] input = Menu.CreateInputMenu("Введите два целых числа", ("A", InputType.Int), ("B", InputType.Int)).Select(e => (int)e).ToArray();
            int a = input[0], b = input[1];
            Menu.CreateConfirmMenu("Задание 1", $"Числа от {Math.Min(a, b)} до {Math.Max(a, b)}\n{OutputInOrder(a, b)}");
        }

        private static string OutputInOrder(int a, int b)
        {
            if (a == b)
                return $"{a}";
            if (a < b)
                return $"{a} " + OutputInOrder(a + 1, b);
            else
                return $"{a} " + OutputInOrder(a - 1, b);
        }
        
        public static void Task2()
        {
            int[] input = Menu.CreateInputMenu("Введите m, n", ("M", InputType.Int), ("N", InputType.Int)).Select(e => (int)e).ToArray();
            int m = input[0], n = input[1];
            Menu.CreateConfirmMenu("Задание 2", $"A({m}, {n}) = {Akkerman(m, n)}");
        }

        private static int Akkerman(int m, int n)
        {
            if (m > 0 && n == 0)
                return Akkerman(m - 1, 1);
            if (m > 0 && n > 0)
                return Akkerman(m - 1, Akkerman(m, n - 1));
            return n + 1;
        }
        
        public static void Task3()
        {
            int n = (int)Menu.CreateInputMenu("Введите целое число N", ("N", InputType.Int)).First();
            Menu.CreateConfirmMenu("Задание 3", $"Сумма цифр числа {n} = {Sum(n)}");
        }

        private static int Sum(int n)
        {
            if (n <= 0)
                return 0;
            return n % 10 + Sum(n / 10);
        }
        
        public static void Task4()
        {
            int n = (int)Menu.CreateInputMenu("Введите целое число N", ("N", InputType.Int)).First();
            Menu.CreateConfirmMenu("Задание 3", $"Цифры числа {n}: {{ {Digits(n)} }}");
        }

        private static string Digits(int n)
        {
            if (n <= 0)
                return "";
            return $"{n % 10} " + Digits(n / 10);
        }
        
        public static void Task5()
        {
            string word = Menu.CreateInputMenu("Введите слово", "Слово").First();
            Menu.CreateConfirmMenu("Задание 5", $"Слово {word} {(IsPalindrome(word) ? "" : "не ")}является палиндромом");
        }

        private static bool IsPalindrome(string word)
        {
            word = word.ToLower();
            if (word.Length <= 1)
                return true;
            if (word[0] != word[^1])
                return false;
            return IsPalindrome(word[1..^1]);
        }

    }
}
