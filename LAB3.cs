using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;


namespace LAB3
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

            public virtual void Draw(Graphics gr) { }

        }

        public class Rectangle : Figure
        {
            public double Width { get; set; }
            public double Height { get; set; }

            public override double GetArea()
            {
                return Width * Height;
            }

            public override Point GetCentre()
            {
                return new Point((int)(Position.X + Width / 2), (int)(Position.Y + Height / 2));
            }

            public override void Draw(Graphics gr)
            {
                gr.DrawRectangle(new Pen(Color), Position.X, Position.Y, (int)Width, (int)Height);
                gr.DrawString(GetCentre().ToString(), new Font("Arial", 9), Brushes.Black, GetCentre());
            }
        }
        public class Circle : Figure
        {
            public double Radius { get; set; }

            public const double pi = 3.14159265359;

            public override double GetArea()
            {
                return Radius * pi;
            }

            public override Point GetCentre()
            {
                return new Point((int)(Position.X + Radius), (int)(Position.Y + Radius));
            }
            public override void Draw(Graphics gr)
            {
                gr.DrawEllipse(new Pen(Color), new RectangleF(Position.X, Position.Y, (float)Radius * 2, (float)Radius * 2));
                gr.DrawString(GetCentre().ToString(), new Font("Arial", 9), Brushes.Black, GetCentre());
            }
        }
        public class Square : Figure
        {
            public double Side { get; set; }

            public override double GetArea()
            {
                return Side * Side;
            }

            public override Point GetCentre()
            {
                return new Point((int)(Position.X + Side / 2), (int)(Position.Y + Side / 2));
            }
            public override void Draw(Graphics gr)
            {
                gr.DrawRectangle(new Pen(Color), Position.X, Position.Y, (int)Side, (int)Side);
                gr.DrawString(GetCentre().ToString(), new Font("Arial", 9), Brushes.Black, GetCentre());
            }
        }
        public class Triangle : Figure
        {
            public double LeftSide { get; set; }
            public double RightSide { get; set; }
            public double BottomSide { get; set; }
            public string TypeOfTriangle()
            {
                double eps = 0.01;
                String TypeOfTriangle = "unknown";
                if (this.LeftSide - this.RightSide < eps && this.LeftSide - this.BottomSide < eps)
                {
                    TypeOfTriangle = "Равносторонний";
                }
                else if (this.LeftSide - this.RightSide < eps)
                {
                    TypeOfTriangle = "Равнобедренный";
                }
                else if (Math.Pow(this.LeftSide, 2) + Math.Pow(this.BottomSide, 2) - Math.Pow(this.LeftSide, 2) < eps)
                {
                    TypeOfTriangle = "Прямоугольный";
                }
                else
                {
                    TypeOfTriangle = "Разносторонний";
                }
                return TypeOfTriangle;
            }
            private double GetHeight()
            {
                double Height = 0;
                string TriangleType = this.TypeOfTriangle();
                if (TriangleType == "Разносторонний")
                {
                    Height = 2 * this.GetArea() / this.BottomSide;
                }
                else if (TriangleType == "Равнобедренный")
                {
                    Height = Math.Sqrt(Math.Pow(this.LeftSide, 2) - (Math.Pow(this.BottomSide, 2)) / 4);
                }
                else if (TriangleType == "Прямоугольный")
                {
                    Height = this.LeftSide * this.BottomSide / this.RightSide;
                }
                else if (TriangleType == "Равносторонний")
                {
                    Height = (this.LeftSide * Math.Sqrt(3)) / 2;
                }
                return Height;
            }
            private double FindHalfBottomSide()
            {
                double Height = GetHeight();
                double Half_bottom_side = Math.Sqrt(Math.Pow(this.LeftSide, 2) - Math.Pow(Height, 2));
                return Half_bottom_side;
            }
            private Point[] GetPoints()
            {
                double Height = GetHeight();
                double HalfBottomSide = this.FindHalfBottomSide();

                Point[] points = new Point[3];
                points[0] = new Point(this.Position.X, this.Position.Y);
                points[1] = new Point(this.Position.X + (int)HalfBottomSide, this.Position.Y + (int)Height);
                points[2] = new Point(this.Position.X + (int)this.BottomSide, this.Position.Y);
                return points;
            }
            public override double GetArea()
            {
                double p = (LeftSide + RightSide + BottomSide) / 2;
                return Math.Sqrt(p * (p - LeftSide) * (p - RightSide) * (p - BottomSide));
            }
            public override Point GetCentre()
            {
                double Height = GetHeight();
                double HalfBottomSide = FindHalfBottomSide();
                double PointX = (this.Position.X + this.Position.X + HalfBottomSide + this.Position.X + this.BottomSide) / 3;
                double PointY = (this.Position.Y + this.Position.Y + (int)Height + this.Position.Y) / 3;
                return new Point((int)(PointX), (int)(PointY));
            }
            public override void Draw(Graphics gr)
            {
                Point[] points = this.GetPoints();
                gr.DrawLine(new Pen(Color), points[0], points[1]);
                gr.DrawLine(new Pen(Color), points[1], points[2]);
                gr.DrawLine(new Pen(Color), points[0], points[2]);
                gr.DrawString(this.GetCentre().ToString(), new Font("Arial", 9), Brushes.Black, this.GetCentre());
            }
        }
        public class Trapeze : Figure
        {
            public double MainTop { get; set; }
            public double MainBottom { get; set; }
            public double LeftSide { get; set; }
            public double RightSide { get; set; }
            protected double GetHeight()
            {
                double Height;
                Height = Math.Sqrt(Math.Pow(LeftSide, 2) - Math.Pow(((Math.Pow(this.MainBottom - this.MainTop, 2) +
                        Math.Pow(this.LeftSide, 2) - Math.Pow(this.RightSide, 2)) / (2 * (this.MainBottom - this.MainTop))), 2));
                return Height;
            }
            public override double GetArea()
            {
                double Height = GetHeight();
                return (MainBottom + MainTop) / 2 * Height;
            }
            public override void Draw(Graphics gr)
            {
                Point[] Points = SetPoints();
                gr.DrawLine(new Pen(Color), Points[0], Points[1]);
                gr.DrawLine(new Pen(Color), Points[1], Points[2]);
                gr.DrawLine(new Pen(Color), Points[2], Points[3]);
                gr.DrawLine(new Pen(Color), Points[0], Points[3]);
                gr.DrawString(this.GetCentre().ToString(), new Font("Arial", 9), Brushes.Black, this.GetCentre());
            }

            public Point[] SetPoints()
            {
                double Height = GetHeight();
                Point[] Points = new Point[4];
                Points[0] = new Point(this.Position.X, this.Position.Y);
                Points[1] = new Point(this.Position.X, this.Position.Y + (int)Height);
                Points[2] = new Point(this.Position.X + (int)MainTop, this.Position.Y + (int)Height);
                Points[3] = new Point(this.Position.X + (int)this.MainBottom, this.Position.Y);
                return Points;
            }
            public override Point GetCentre()
            {
                double Height = GetHeight();
                return new Point((int)(Position.X + MainTop / 2), (int)(Position.Y + Height / 2));
            }
        }
        public class Rhomb : Figure
        {
            public double Side { get; set; }
            public double Height { get; set; }
            public override double GetArea()
            {
                return Side * Height;
            }
            public override Point GetCentre()
            {
                double Section = GetSection();
                return new Point((int)(Position.X + (Side - Section) / 2), (int)(Position.Y + Height / 2));
            }
            public override void Draw(Graphics gr)
            {
                Point[] Points = GetPoints();
                gr.DrawLine(new Pen(Color), Points[0], Points[1]);
                gr.DrawLine(new Pen(Color), Points[1], Points[2]);
                gr.DrawLine(new Pen(Color), Points[2], Points[3]);
                gr.DrawLine(new Pen(Color), Points[0], Points[3]);
                gr.DrawString(this.GetCentre().ToString(), new Font("Arial", 9), Brushes.Black, this.GetCentre());
            }
            protected Point[] GetPoints()
            {
                double Section = GetSection();
                Point[] Points = new Point[4];
                Points[0] = new Point(this.Position.X, this.Position.Y);
                Points[1] = new Point(this.Position.X - (int)Section, this.Position.Y + (int)Height);
                Points[2] = new Point(this.Position.X - (int)Section + (int)Side, this.Position.Y + (int)Height);
                Points[3] = new Point(this.Position.X + (int)this.Side, this.Position.Y);
                return Points;
            }
            protected double GetSection()
            {
                double Section = Math.Sqrt(Math.Pow(Side, 2) - Math.Pow(Height, 2));
                return Section;
            }
        }
        public class Parallelogram : Figure
        {
            public double TopSide { get; set; }
            public double LeftSide { get; set; }
            public double Height { get; set; }
            public override double GetArea()
            {
                return TopSide * Height;
            }
            public override Point GetCentre()
            {
                double Section = GetSection();
                return new Point((int)(Position.X + (TopSide - Section) / 2), (int)(Position.Y + Height / 2));
            }
            public override void Draw(Graphics gr)
            {
                Point[] Points = GetPoints();
                gr.DrawLine(new Pen(Color), Points[0], Points[1]);
                gr.DrawLine(new Pen(Color), Points[1], Points[2]);
                gr.DrawLine(new Pen(Color), Points[2], Points[3]);
                gr.DrawLine(new Pen(Color), Points[0], Points[3]);
                gr.DrawString(this.GetCentre().ToString(), new Font("Arial", 9), Brushes.Black, this.GetCentre());
            }
            protected Point[] GetPoints()
            {
                double Section = GetSection();
                Point[] Points = new Point[4];
                Points[0] = new Point(this.Position.X, this.Position.Y);
                Points[1] = new Point(this.Position.X - (int)Section, this.Position.Y + (int)Height);
                Points[2] = new Point(this.Position.X - (int)Section + (int)TopSide, this.Position.Y + (int)Height);
                Points[3] = new Point(this.Position.X + (int)this.TopSide, this.Position.Y);
                return Points;
            }
            protected double GetSection()
            {
                double Section = Math.Sqrt(Math.Pow(LeftSide, 2) - Math.Pow(Height, 2));
                return Section;
            }
        }
        public class Pentagon : Figure
        {
            public double Radius { get; set; }
            public override double GetArea()
            {
                return (5 / 2) * Math.Pow(Radius, 2) * Math.Sin(1.25664);
            }
            public override Point GetCentre()
            {
                return new Point((int)(Position.X + Radius), (int)(Position.Y + Radius));
            }
            public override void Draw(Graphics gr)
            {
                List<Point> Points = GetPoints();
                gr.DrawPolygon(Pens.Red, Points.ToArray());
                gr.DrawString(this.GetCentre().ToString(), new Font("Arial", 9), Brushes.Black, this.GetCentre());
            }
            protected List<Point> GetPoints()
            {
                List<Point> Points = new List<Point>();
                for (int i = 0; i < 360; i += 72)
                {
                    double rad = (double)i / 180.0 * 3.14;
                    double x = Position.X + (int)(-Radius * Math.Cos(rad));
                    double y = Position.Y + (int)(-Radius * Math.Sin(rad));

                    Points.Add(new Point((int)x + (int)Radius, (int)y + (int)Radius));
                }
                return Points;
            }
        }
        public class Decagon : Figure
        {
            public double Radius { get; set; }
            public override double GetArea()
            {
                return (10 / 2) * Math.Pow(Radius, 2) * Math.Sin(0.628319);
            }
            public override Point GetCentre()
            {
                return new Point((int)(Position.X + Radius), (int)(Position.Y + Radius));
            }
            public override void Draw(Graphics gr)
            {
                List<Point> Points = GetPoints();
                gr.DrawPolygon(Pens.Red, Points.ToArray());
                gr.DrawString(this.GetCentre().ToString(), new Font("Arial", 9), Brushes.Black, this.GetCentre());
            }
            protected List<Point> GetPoints()
            {
                List<Point> Points = new List<Point>();
                for (int i = 0; i < 360; i += 36)
                {
                    double rad = (double)i / 180.0 * 3.14;
                    double x = Position.X + (int)(Radius * Math.Cos(rad));
                    double y = Position.Y + (int)(Radius * Math.Sin(rad));

                    Points.Add(new Point((int)x + (int)Radius, (int)y + (int)Radius));
                }
                return Points;
            }
        }
        
        public static Figure[] figures =
        {
            new Rectangle()
            {
                Name = "Прямоугольник",
                Color = System.Drawing.Color.Black,
                Position = new System.Drawing.Point(30, 30),
                Width = 50,
                Height = 150
            },
            new Circle()
            {
                Name = "Круг",
                Color = System.Drawing.Color.Blue,
                Position = new System.Drawing.Point(120, 60),
                Radius = 50
            },
            new Square()
            {
                Name = "Квадрат",
                Color = System.Drawing.Color.Violet,
                Position = new System.Drawing.Point(240, 60),
                Side = 50
            },
            new Triangle()
            {
                Name = "Треугольник",
                Color = System.Drawing.Color.Bisque,
                Position = new System.Drawing.Point(350, 60),
                LeftSide = 70,
                RightSide = 90,
                BottomSide = 120
            },
            new Trapeze()
            {
                Name = "Трапеция",
                Color = System.Drawing.Color.Red,
                Position = new System.Drawing.Point(500, 60),
                MainTop = 50,
                MainBottom = 120,
                LeftSide = 80,
                RightSide = 65
            },
            new Rhomb()
            {
                Name = "Ромб",
                Color = System.Drawing.Color.Green,
                Position = new System.Drawing.Point(700, 60),
                Side = 90,
                Height = 50
            },
            new Parallelogram()
            {
                Name = "Параллелограм",
                Color = System.Drawing.Color.Gray,
                Position = new System.Drawing.Point(50, 300),
                TopSide = 100,
                LeftSide = 80,
                Height = 70
            },
            new Pentagon()
            {
                Name = "Правильный пятиугольник",
                Color = System.Drawing.Color.LightCyan,
                Position = new System.Drawing.Point(200, 250),
                Radius = 70
            },
            new Decagon()
            {
                Name = "Правильный десятиугольник",
                Color = System.Drawing.Color.White,
                Position = new System.Drawing.Point(400, 250),
                Radius = 70
            }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №3 - Полиморфизм\n");
            Console.WriteLine("Выполнил Братанов Данил\n");
            Console.WriteLine(figures.Length);

            var Form = new Form()
            {
                Text = "Лаб 3 - Полиморфизм",
                Size = new System.Drawing.Size(800, 600),
                StartPosition = FormStartPosition.CenterScreen
            };

            for (int i = 0; i < figures.GetLength(0); i++)
            {
                Console.WriteLine($"Название фигуры: {figures[i].Name}");
                Console.WriteLine($"Площадь фигуры: {figures[i].GetArea()}\n");
                Console.WriteLine($"Цвет фигуры: {figures[i].Color}\n");
                Console.WriteLine($"Положение фигуры: {figures[i].Position}\n");
                Console.WriteLine($"Координаты центра: {figures[i].GetCentre()}\n");
            }

            Form.Paint += Frm_Paint;
            Application.Run(Form);

        }

        private static void Frm_Paint(object sender, PaintEventArgs e)
        {
            foreach (var figure in figures)
            {
                figure.Draw(e.Graphics);
            }
        }
    }
}
