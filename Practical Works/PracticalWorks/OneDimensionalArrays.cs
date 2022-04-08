using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_Works.PracticalWorks
{
    class OneDimensionalArrays
    {

        public static void Task1()
        {
            int[] array = GenerateRandomArray(10, -5, 5);
            string present = $"[ {string.Join(", ", array)} ]";
            int width = Math.Min(80, present.Length);
            int sum = array.Where((e, i) => i % 2 == 0).Sum();
            Menu.CreateConfirmMenu("Задание 1", $"{present}\nСумма элементов под чётным индексом: {sum}", width, "Ок");
        }
        
        public static void Task2()
        {
            int[] array, positiveElements;
            do
            {
                array = GenerateRandomArray(20, -5, 3);
                positiveElements = array.Select((e, i) => (e, i)).Where(e => e.e > 0).Select(e => e.i).ToArray();
            } while (positiveElements.Length < 2);

            int sum = array[(positiveElements[0] + 1)..positiveElements[1]].Sum();

            string present = $"[ {string.Join(", ", array)} ]";
            int width = Math.Min(80, present.Length);
            Menu.CreateConfirmMenu("Задание 2", $"{present}\nСумма чисел с [{positiveElements[0]}] по [{positiveElements[1]}]: {sum}", width, "Ок");
        }
        
        public static void Task3()
        {
            int[] array = GenerateRandomArray(10, -5, 5);

            string presentBase = $"[ {string.Join(", ", array)} ]";

            array = array.Select(e => e < 0 ? e * e : e).ToArray();

            string presentResult = $"[ {string.Join(", ", array)} ]";

            int width = Math.Min(80, Math.Max(presentResult.Length, presentBase.Length));
            Menu.CreateConfirmMenu("Задание 3", $"Исходный массив:\n{presentBase}\nКвадраты отрицательных чисел:\n{presentResult}", width, "Ок");
        }
        
        public static void Task4()
        {
            int[] array = GenerateRandomArray(10, -5, 5);

            string presentBase = $"[ {string.Join(", ", array)} ]";

            Sort(ref array);

            string presentResult = $"[ {string.Join(", ", array)} ]";

            int width = Math.Min(80, Math.Max(presentBase.Length, presentResult.Length));
            Menu.CreateConfirmMenu("Задание 4", $"Исходный массив:\n{presentBase}\nОтсортированный массив:\n{presentResult}", width, "Ок");
        }

        private static void Sort(ref int[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                for(int j = i; j < array.Length; j++)
                {
                    if (array[i] < array[j])
                    {
                        int buffer = array[i];
                        array[i] = array[j];
                        array[j] = buffer;
                    }
                }
            }
        }

        private static int[] GenerateRandomArray(int length, int min, int max)
        {
            Random random = new Random();
            return new int[length].Select(e => random.Next(min, max)).ToArray();
        }

    }
}
