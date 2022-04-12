using System;

namespace Lab2
{
    public abstract class Figure
    {
        public string Name { get; set; }
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
    }
    public class Circle : Figure
    {
        public double Radius { get; set; }
        public override double GetArea()
        {
            return Math.Pow(Radius, 2) * Math.PI;
        }
    }
    public class Square : Figure
    {
        public double Side { get; set; }
        public override double GetArea()
        {
            return Math.Pow(Side, 2);
        }
    }
    public class Triangle : Figure
    {
        public double FirstHipotenuse { get; set; }
        public double SecondHipotenuse { get; set; }
        public override double GetArea()
        {
            return (FirstHipotenuse * SecondHipotenuse) / 2;
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
    }
    public class Rhomb : Figure
    {
        public double FirstDiametr { get; set; }
        public double SecondDiametr { get; set; }
        public override double GetArea()
        {
            return FirstDiametr * SecondDiametr / 2;
        }
    }
    public class Parallelogram : Figure
    {
        public double Side { get; set; }
        public double Height { get; set; }
        public override double GetArea()
        {
            return Side * Height;
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
    }
    public class Decagon : Figure
    {
        public double Side { get; set; }
        public double Radius { get; set; }
        public override double GetArea()
        {
            return (Side * 10 * Radius) / 2;
        }
    }
    public class GetInfo
    {
        public static void GetFigureInfo(Figure figure)
        {
            Console.WriteLine("Название фигуры: {0}", figure.Name);
            Console.WriteLine("Площадь фигуры: {0}\n", figure.GetArea());
        }
    }

    public class Program 
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная 2 - Наследование");
            Console.WriteLine("Выполнил - Братанов Данил\n\n");

            Rectangle rectangle = new Rectangle()
            {
                Name = "Прямоугольник", 
                Width = 15.2, 
                Height = 13.7
            };
            GetInfo.GetFigureInfo(rectangle);

            Circle circle = new Circle()
            {
                Name = "Круг", 
                Radius = 3.14
            };
            GetInfo.GetFigureInfo(circle);

            Square square = new Square()
            {
                Name = "Квадрат",
                Side = 5.32
            };
            GetInfo.GetFigureInfo(square);

            Triangle triangle = new Triangle()
            {
                Name = "Треугольник",
                FirstHipotenuse = 3.43,
                SecondHipotenuse = 2.32
            };
            GetInfo.GetFigureInfo(triangle);

            Trapeze trapeze = new Trapeze()
            {
                Name = "Трапеция", 
                FirstSide = 2.43,
                SecondSide = 4.13,
                Height = 5.7
            };
            GetInfo.GetFigureInfo(trapeze);

            Rhomb rhomb = new Rhomb()
            {
                Name = "Ромб",
                FirstDiametr = 2.43,
                SecondDiametr = 5.7
            };
            GetInfo.GetFigureInfo(rhomb);

            Parallelogram parallelogram = new Parallelogram()
            {
                Name = "Параллелограмм",
                Height = 3.43,
                Side = 2.54
            };
            GetInfo.GetFigureInfo(parallelogram);

            Pentagon pentagon = new Pentagon()
            {
                Name = "Правильный пятиугольник",
                Side = 3.4,
                Radius = 4.1
            };
            GetInfo.GetFigureInfo(pentagon);

            Decagon decagon = new Decagon()
            {
                Name = "Правильный десятиугольник",
                Side = 3.4,
                Radius = 4.1
            };
            GetInfo.GetFigureInfo(decagon);
        }   
    }

}
