using System;
using System.Drawing;

namespace Lab3
{
    class Program
    {
        public abstract class Figure
        {
            public string Name { get; set; }

            public Color Color { get; set; }
            public Point Position { get; set; }

            public abstract Point GetCentre();
            public abstract double GetArea();

        }

        public class Rectangle : Figure
        {
            public double Width { get; set; }
            public double Height { get; set; }
            public override double GetArea()
            {
                return Height * Width;
            }

            public override Point GetCentre()
            {
                return new Point((int)(Position.X + Width / 2), (int)(Position.Y + Height / 2));
            }
        }

        public class Circle : Figure
        {
            public double Radius { get; set; }
            public override double GetArea()
            {
                return Math.Pow(Radius, 2) * Math.PI;
            }

            public override Point GetCentre()
            {
                return new Point((int)(Position.X + Radius), (int)(Position.Y + Radius));
            }
        }
        public class Square : Figure
        {
            public double Side { get; set; }
            public override double GetArea()
            {
                return Math.Pow(Side, 2);
            }

            public override Point GetCentre()
            {
                return new Point((int)(Position.X + Side / 2), (int)(Position.Y + Side / 2));
            }
        }
        public class Triangle : Figure
        {
            public double FirstLeg { get; set; }
            public double SecondLeg { get; set; }
            public override double GetArea()
            {
                return (FirstLeg * SecondLeg) / 2;
            }

            public override Point GetCentre()
            {
                return new Point((int)(Position.X + FirstLeg / 2), (int)(Position.Y + SecondLeg / 2));
            }
        }
        public class Trapeze : Figure
        {
            public double FirstSide { get; set; }
            public double SecondSide { get; set; }
            public double Height { get; set; }
            public override double GetArea()
            {
                return (FirstSide + SecondSide / 2) * Height;
            }

            public override Point GetCentre()
            {
                return new Point((int)(Position.X + Height / 2), (int)(Position.Y + FirstSide / 2));
            }
        }
        public class Rhomb : Figure
        {
            public double FirstDiametr { get; set; }
            public double SecondDiametr { get; set; }
            public override double GetArea()
            {
                return FirstDiametr * SecondDiametr / 2;
            }

            public override Point GetCentre()
            {
                return new Point((int)(Position.X + FirstDiametr / 2), (int)(Position.Y + SecondDiametr / 2));
            }
        }
        public class Parallelogram : Figure
        {
            public double Side { get; set; }
            public double Height { get; set; }
            public double FirstDiagonal { get; set; }
            public double SecondDiagonal { get; set; }
            public override double GetArea()
            {
                return Side * Height;
            }

            public override Point GetCentre()
            {
                return new Point((int)(Position.X + FirstDiagonal / 2), (int)(Position.Y + SecondDiagonal / 2));
            }
        }
        public class Pentagon : Figure
        {
            public double Side { get; set; }
            public double Radius { get; set; }
            public override double GetArea()
            {
                return (Side * 5 * Radius) / 2;
            }

            public override Point GetCentre()
            {
                return new Point((int)(Position.X + Radius), (int)(Position.Y + Radius));
            }
        }
        public class Decagon : Figure
        {
            public double Side { get; set; }
            public double Radius { get; set; }
            public override double GetArea()
            {
                return (Side * 10 * Radius) / 2;
            }

            public override Point GetCentre()
            {
                return new Point((int)(Position.X + Radius), (int)(Position.Y + Radius));
            }
        }
        public class GetInfo
        {
            public static void GetFigureInfo(Figure figure)
            {
                Console.WriteLine($"Название фигуры: {figure.Name}");
                Console.WriteLine($"Площадь фигуры: {figure.GetArea()}\n");
                Console.WriteLine($"Цвет фигуры: {figure.Color}\n");
                Console.WriteLine($"Положение фигуры: {figure.Position}\n");
                Console.WriteLine($"Координаты центра: {figure.GetCentre()}\n");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа № 3 - Полиморфизм");
            Console.WriteLine("Выполнил - Братнов Данил");
        }
    }
}
