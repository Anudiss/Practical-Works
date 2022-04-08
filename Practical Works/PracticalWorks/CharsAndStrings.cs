using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Practical_Works.PracticalWorks
{
    class CharsAndStrings
    {
        private static Dictionary<char, int> Roman = new Dictionary<char, int>()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        public static void Task1() 
        {
            string input = (string)Menu.CreateInputMenu("Введите римскую цифру", 50, ("Число", InputType.Roman)).First();

            int Decimal = RomanToDecimal(input);

            Menu.CreateConfirmMenu("Задание 1", $"{input} = {Decimal}", "Ок");

        }

        public static int RomanToDecimal(string roman)
        {
            int number = 0;
            for (int i = 0; i < roman.Length; i++)
            {
                if (i + 1 < roman.Length && Roman[roman[i]] < Roman[roman[i + 1]])
                    number -= Roman[roman[i]];
                else
                    number += Roman[roman[i]];
            }
            return number;
        }

        public static void Task2() 
        {
            string[] surnames = new[] 
            {
                "Ханипов", 
                "Ханипов", 
                "Хайрудтинов",
                "Хайрудтинов",
                "Хайрудтинов",
                "Ханипов",
                "Мещеряков",
                "Хайрудтинов",
                "Ханипов",
                "Мещеряков"
            };

            Menu.CreateConfirmMenu("Задание 2", $"{string.Join("\n", surnames)}\nПовторяющиеся фамилии:\n{string.Join("\n", surnames.GroupBy(e => e).Select(e => $"{e.Key} - {e.Count()}"))}", "Ок");

        }
        public static void Task3() 
        {
            string binary = (string)Menu.CreateInputMenu("Введите число в двоичной системе счисления", ("Двоичное число", InputType.Binary)).First();

            int Decimal = Convert.ToInt32(binary, 2);
            Menu.CreateConfirmMenu("Задание 3", $"{binary} = {Decimal}", "Ок");
        }

        public static void Task4() 
        {
            string input = (string)Menu.CreateInputMenu("Введите строку содержащую серию не буквенных символов", 60, ("Строка", InputType.String)).First();
            MatchCollection matches = Regex.Matches(input, @"([\W]+)");

            int maxLength;
            if (matches.Count > 0)
                maxLength = matches.Max(e => e.Length);
            else
                maxLength = 0;
            Menu.CreateConfirmMenu("Задание 4", $"Длина максимальной серии символов, отличных от букв: {maxLength}", "Ок");
        }
    }
}
