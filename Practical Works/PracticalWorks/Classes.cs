using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_Works.PracticalWorks
{
    class Classes
    {

        public static void Task1()
        {
            List<Cone> cones = new();
            double[] input;
            int coneCount = (int)Menu.CreateInputMenu("Введите количество конусов", ("Количество", InputType.Int)).First();
            for (int i = 0; i < coneCount; i++)
            {
                if (cones.Count > 0)
                    Menu.CreateTextMenu("Конусы", $"{string.Join("\n", cones)}", 0, 0, 30);
                input = Menu.CreateInputMenu("Введите радиус и высоту конуса", ("Радиус", InputType.Double), ("Высота", InputType.Double)).Select(e => (double)e).ToArray();
                cones.Add(new(input[0], input[1]));
                Menu.CreateTextMenu("Конусы", $"{string.Join("\n", cones)}", 0, 0, 30);
            }

            string[] conesPresent = cones.Select(e => ConeSquare(e)).ToArray();
            int width = Math.Min(80, conesPresent.Max(e => e.Length));

            Menu.CreateConfirmMenu("Задание 1", $"{string.Join("\n", conesPresent)}", width);

        }

        private static string ConeSquare(Cone cone)
        {
            return $"{cone}:\n  S(осн) = {cone.SquareBase():0.00}  S(бок) = {cone.SquareSurface():0.00}  S(полн) = {cone.SquareFull():0.00}";
        }

        public static void Task2()
        {

        }
    }

    class Cone
    {
        private readonly double r, h;
        private readonly int ID;

        private static int ID_counter = 1;

        public Cone(double r, double h)
        {
            this.r = r;
            this.h = h;
            ID = ID_counter++;
        }

        public double SquareBase()
        {
            return Math.PI * r * r;
        }

        public double SquareSurface()
        {
            return Math.PI * r * Math.Sqrt(r * r + h * h);
        }

        public double SquareFull()
        {
            return SquareBase() + SquareSurface();
        }

        public override string ToString()
        {
            return $"Cone{ID}({r}, {h})";
        }
    }

    class Car 
    {
        private readonly string brand, color;
        private readonly double price;

        private readonly int ID;
        private static int ID_counter = 1;

        public Car(string brand, string color, double price)
        {
            this.brand = brand;
            this.color = color;
            this.price = price;
            ID = ID_counter++;
        }

        public double Discount()
        {
            return price * 0.05;
        }

        public override string ToString()
        {
            return $"Car{ID}({brand}, {color}, {price})";
        }
    }
}
