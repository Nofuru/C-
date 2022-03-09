using System;

namespace Lab1_ClassComplex
{
    public class Complex
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public void Add(Complex varNumber)
        {
            Real += varNumber.Real;
            Imaginary += varNumber.Imaginary;
        }

        public void Substract(Complex varNumber)
        {
            Real -= varNumber.Real;
            Imaginary -= varNumber.Imaginary;
        }

        public void Multyply(Complex varNumber)
        {
            Real *= varNumber.Real;
            Imaginary *= varNumber.Imaginary;
        }

        public void Devide(Complex varNumber)
        {
            Real /= varNumber.Real;
            Imaginary /= varNumber.Imaginary;
        }

        public static void ConclusionResult(Complex firstNumber, Complex secondNumber)
        {
            Console.WriteLine("firstNumber = {0} + {1}i", firstNumber.Real, firstNumber.Imaginary);
            Console.WriteLine("secondNumber = {0} + {1}i", secondNumber.Real, secondNumber.Imaginary);
        }


    }
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная 1 - Инкапсуляция");
            Console.WriteLine("Выполнил - Братанов Данил");

            Complex firstNumber = new Complex() { Real = 3, Imaginary = 0.5 };
            Complex secondNumber = new Complex() { Real = 2, Imaginary = 0.8 };

            firstNumber.Add(secondNumber);
            secondNumber.Substract(firstNumber);

            Complex.ConclusionResult(firstNumber, secondNumber);

            firstNumber.Multyply(secondNumber);
            secondNumber.Devide(firstNumber);

            Complex.ConclusionResult(firstNumber, secondNumber);
        }
    }
}


