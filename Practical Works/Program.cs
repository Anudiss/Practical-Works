using System;
using System.Collections.Generic;
using System.Linq;
using Practical_Works.PracticalWorks;

namespace Practical_Works
{
    class Program
    {
        public static List<(string Name, PracticalWork MainClass)> practicalWorks = new()
        {
            #region Двумерные массивы
            ("Двумерные массивы", new PracticalWork(("Задание 1", "В прямоугольной матрице случайных чисел (промежуток от 0 до 5) определить количество строк, не содержащих ни одного нулевого элемента. Определить максимальное число из чисел, встречающихся в данной матрице более одного раза.", TwoDimensionalArrays.Task1),
                                                    ("Задание 2", "Составить программу, которая находит сумму элементов квадратной матрицы под главной диагональю", TwoDimensionalArrays.Task2),
                                                    ("Задание 3", "В прямоугольной матрице случайных чисел (промежуток задать самим) определить номера строк и столбцов всех седловых точек матрицы. Матрица А имеет седловую точку Aij, если она является минимальным элементом в i-ой строке и максимальным элементом в j-ом.", TwoDimensionalArrays.Task3),
                                                    ("Задание 4", "Составить программу, которая перемножает две прямоугольные матрицы, полученные случайным образом.", TwoDimensionalArrays.Task4))),
            #endregion
            #region Одномерные массивы
            ("Одномерные массивы", new PracticalWork(("Задание 1", "Составьте программу для вычисления произведения элементов массива с четными номерами.", OneDimensionalArrays.Task1),
                                                     ("Задание 2", "Составьте программу для вычисления суммы элементов массива, расположенных между первым и вторым положительными элементами.", OneDimensionalArrays.Task2),
                                                     ("Задание 3", "Составьте программу, которая меняет отрицательные элементы массива их квадратами и упорядочивает элементы массива по возрастанию.", OneDimensionalArrays.Task3),
                                                     ("Задание 4", "Составить программу, которая сортирует массив размерности n  методом пузырька (в порядке убывания). Последовательно сравниваются пары соседних чисел и упорядочиваются по убыванию. При составлении программы используются вложенные циклы.", OneDimensionalArrays.Task4))),
            #endregion
            #region Символы и строки
            ("Символы и строки", new PracticalWork(("Задание 1", "Составить программу преобразования натуральных чисел, записанных в римской нумерации, в десятичную систему счисления.", CharsAndStrings.Task1),
                                                   ("Задание 2", "В символьном массиве хранятся фамилии и инициалы учеников класса. Требуется напечатать список класса с указанием для каждого ученика количество его однофамильцев.", CharsAndStrings.Task2),
                                                   ("Задание 3", "Дано число в двоичной системе счисления. Проверить правильность ввода этого числа(в его записи должны быть только символы 0 и 1). Если число введено неверно, повторить ввод. При правильном вводе привести число в десятичную систему счисления.", CharsAndStrings.Task3),
                                                   ("Задание 4", "Для заданного текста определить длину содержащийся в нем максимальный серии символов, отличных от букв.", CharsAndStrings.Task4))),
            #endregion
            #region Очереди и стеки
            ("Очереди и стеки", new PracticalWork(("Задание 1", "Создать очередь из целых чисел. Определить количество элементов очереди меньших 10. Организовать просмотр данных очереди.", StacksAndQueues.Task1),
                                                  ("Задание 2", "Создать очередь, информационными полями которого являются: фамилия работника и его оклад. Добавить в очередь сведения о новом работника. Организовать просмотр данных очередь и вычислить средний оклад.", StacksAndQueues.Task2),
                                                  ("Задание 3", "Создать очередь, информационными полями которой являются: наименование процессора и его тактовая частота, и количество ядер. Добавить в очередь сведения о новом процессоре. Организовать просмотр данных очереди и распечатать данные о многоядерных процессорах (количество ядер больше 1).", StacksAndQueues.Task3),
                                                  ("Задание 4", "Создать стек из вещественных чисел (числа -5,2; 72,3; 2,3; 18,4; -16,3. Определить максимальный элемент в стеке. Организовать просмотр данных стека.", StacksAndQueues.Task4),
                                                  ("Задание 5", "Создать стек строковых значений. Добавьте в стек строки «group», «220», «study», «hello, group», «are you ready» и распечатайте содержимое стека. Удалите 2 элемента из стека, и распечатайте содержимое стека еще раз. Найдите строку минимальной длины, принадлежащую стеку.", StacksAndQueues.Task5))),
            #endregion
            #region Работа с файловой системой №1
            ("Работа с файловой системой №1", new PracticalWork(("Задание 1", "Вывести на экран имена всех дисков компьютера их объем доступного свободного места на диске в байтах, общий размер диска в байтах.", FileSystem1.Task1),
                                                                ("Задание 2", "Создать на рабочем столе каталог с названием Группа. В данном каталоге создать еще 2 каталога с названиями Группа 123, Группа 223, Группа 323.", FileSystem1.Task2),
                                                                ("Задание 3", "Вывести на экран все файлы и подкаталоги (каталог Группа). 2) Вывести на экран только файлы Excel.", FileSystem1.Task3),
                                                                ("Задание 4", "Удалить подкаталог с названием Группа 323.", FileSystem1.Task4),
                                                                ("Задание 5", "Переместить из каталога «Группа» файл с названием «База данных 123 группа» в каталог с названием «Группа 123», а файл с названием «Сводный лист 223 группа» в каталог «Группа 223».", FileSystem1.Task5),
                                                                ("Задание 6", "Вывести время создания каталога «Группа 223».  Вывести время последнего изменения каталога, полный путь к каталогу и получить родительский каталог.", FileSystem1.Task6))),
            #endregion
            #region Работа с файловой системой №2
            ("Работа с файловой системой №2", new PracticalWork(("Задание 1", "Записать в файл ФИО и должность 3 работников введенных с клавиатуры. Далее считать и вывести список работников на экран.", FileSystem2.Task1),
                                                                ("Задание 2", "Записать таблицы умножения в файл. Далее считать из файла и вывести на экран.", FileSystem2.Task2),
                                                                ("Задание 3", "Записать в файл «Привет, 223 группа!!!». Дозаписать в файл фразу «Вы очень шумные на парах!!!!», далее дозаписать фразу «Это надо исправлять».", FileSystem2.Task3))),
            #endregion
            #region Методы
            ("Методы", new PracticalWork(("Задание 1", "Напишите программу, которая вычисляет количество сочетаний по формуле. В качестве подпрограммы оформите вычисление факториала.", Methods.Task1),
                                         ("Задание 2", "Измените программу 6.1 так, чтобы кроме параметров- значений был использован выходной параметр для получения результата.", Methods.Task2),
                                         ("Задание 3", "Напишите программу, в которой использовалась бы функция преобразования букв английского алфавита из прописной в строчную и наоборот.", Methods.Task3),
                                         ("Задание 4", "Получить одномерный массив из  элементов случайным образом. Подсчитать количество элементов массива, больше среднего значения. Нахождение среднего значения и подсчет количества элементов оформить в подпрограмме.", Methods.Task4),
                                         ("Задание 5", "Получить квадратную матрицу случайным образом. С помощью подпрограммы преобразовать матрицу так, чтобы нечетные столбцы были упорядочены  по возрастанию, а четные по убыванию.", Methods.Task5))),
            #endregion
            #region Рекурсия
            ("Рекурсия", new PracticalWork(("Задание 1", "Даны два целых числа A и В (каждое в отдельной строке). Выведите все числа от A до B включительно, в порядке возрастания, если A < B, или в порядке убывания в противном случае.", Recursion.Task1),
                                           ("Задание 2", "В теории вычислимости важную роль играет функция Аккермана A(m,n). Даны два целых неотрицательных числа m и n, каждое в отдельной строке.Выведите A(m, n).", Recursion.Task2),
                                           ("Задание 3", "Дано натуральное число N. Вычислите сумму его цифр. При решении этой задачи нельзя использовать строки, списки, массивы(ну и циклы, разумеется).", Recursion.Task3),
                                           ("Задание 4", "ано натуральное число N. Выведите все его цифры по одной, в обратном порядке, разделяя их пробелами или новыми строками. При решении этой задачи нельзя использовать строки, списки, массивы(ну и циклы, разумеется).Разрешена только рекурсия и целочисленная арифметика.", Recursion.Task4),
                                           ("Задание 5", "Дано слово, состоящее только из строчных латинских букв. Проверьте, является ли это слово палиндромом. Выведите YES или NO. При решении этой задачи нельзя пользоваться циклами, в решениях на питоне нельзя использовать срезы с шагом, отличным от 1.", Recursion.Task5))),
            #endregion
            #region Классы
            ("Классы", new PracticalWork(("Задание 1", "Разработать класс Cone – прямой конус, который должен содержать закрытые переменные – r – радиус основания, H – высота конуса. Разработанный класс должен содержать методы, вычисляющие площади основания, боковой площади поверхности, полной поверхности конуса. S(осн) = Пr^2, S(бок) = Пr * sqrt(r^2 + h^2), S(полн) = S(осн) + S(бок), Вычислить значения при различных положительных значениях.", Classes.Task1),
                                         ("Задание 2", "Разработать класс Car, который содержит несколько полей: марка машины, цвет, стоимость. Класс должен содержать метод, выдающий стоимость машины с учетом 5% скидки. Добавьте дополнительно свои поле и метод.", Classes.Task2)))
            #endregion
        };

        static void Main(string[] args)
        {
            Console.Title = "Практические работы";
            int practical;
            while((practical = Menu.CreateMenu("Практические работы", practicalWorks)) != -1)
            {
                int task;
                (string Name, PracticalWork MainClass) = practicalWorks[practical];
                while((task = Menu.CreateMenu(Name, MainClass.Tasks)) != -1)
                {
                    (string name, string description, Action method) = MainClass.Tasks[task];
                    Console.Clear();
                    Console.ResetColor();
                    method();
                    Console.ReadKey();
                }
            }
            Console.WriteLine("Нажмите любую клавишу, чтобы выйти...");
            Console.ReadKey();
        }
    }

    public class PracticalWork 
    {
        public List<(string Name, string Description, Action Method)> Tasks { get; private set; } = new();

        public PracticalWork(params (string name, string Description, Action method)[] tasks)
        {
            foreach (var (name, description, method) in tasks)
                Tasks.Add((name, description, method));
        }
    }

    public static class Extensions
    {
        public static void Print<T>(this T[,] matrix)
        {
            int cols = matrix.GetLength(0);
            int rows = matrix.GetLength(1);
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    Console.Write($"{matrix[x, y],5}");
                }
                Console.WriteLine();
            }
        }

        public static void Print<T>(this T[,] matrix, Func<T, string> presenter)
        {
            int cols = matrix.GetLength(0);
            int rows = matrix.GetLength(1);
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    Console.Write(presenter(matrix[x, y]));
                }
                Console.WriteLine();
            }
        }

        public static void Print<T>(this IEnumerable<T> array)
        {
            Console.WriteLine(string.Join(", ", array));
        }

        public static void Print<T>(this IEnumerable<T> array, Func<string, string, string> present)
        {
            Console.WriteLine(array.Select(e => $"{e}").Aggregate((a, b) => present(a, b)));
        }

        public static string ToFormattedString(this int[,] array)
        {
            // │┌┐└┘
            int cols = array.GetLength(0);
            int rows = array.GetLength(1);
            string invisible = " ";
            string empty = string.Join("", Enumerable.Repeat(invisible, cols * 3));
            string result = $"┌ {empty} ┐\n";
            for (int y = 0; y < rows; y++)
            {
                IEnumerable<string> elements = array.Select((e, x, y) => (e, x, y)).Where(e => e.y == y).Select(e => $"{($"{e.e, 2}"), -3}");
                string line = string.Join("", elements);
                result += $"│ {line} │\n";
            }
            return result + $"└ {empty} ┘";
        }

        public static IEnumerable<R> Select<T, R>(this T[,] matrix, Func<T, int, int, R> selector)
        {
            return from x in Enumerable.Range(0, matrix.GetLength(0))
                   from y in Enumerable.Range(0, matrix.GetLength(1))
                   select selector(matrix[x, y], x, y);
        }

        public static IEnumerable<(T, int, int)> Where<T>(this T[,] matrix, Func<T, int, int, bool> preducate) {
            return from x in Enumerable.Range(0, matrix.GetLength(0))
                   from y in Enumerable.Range(0, matrix.GetLength(1))
                   where preducate(matrix[x, y], x, y)
                   select (matrix[x, y], x, y);
        }

        public static T[,] ToArray<T>(this IEnumerable<(T element, int x, int y)> array)
        {
            int cols = array.Max(e => e.x) + 1;
            int rows = array.Max(e => e.y) + 1;
            T[,] matrix = new T[cols, rows];
            foreach ((T element, int x, int y) in array)
                matrix[x, y] = element;
            return matrix;
        }

        public static void Push<T>(this Stack<T> stack, params T[] elements)
        {
            foreach (var e in elements)
                stack.Push(e);
        }
    }
}
