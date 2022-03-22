using System;
using System.Drawing;

namespace Lab1_ClassStudent
{
    class Student
    {
        Random random = new Random();
        public string Name { get; set; }
        public string Sex { get; set; }
        public string HairColor { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        public Student Add(Student varStudent)
        {
            Student addedStudent = new Student() { 
                Name = varStudent.Name,
                Age = (Age + varStudent.Age) / 2,
                HairColor = varStudent.HairColor,
                Height = (Height + varStudent.Height) / 2,
                Sex = varStudent.Sex,
                Weight = (Weight + varStudent.Weight) / 2
            };
            return addedStudent;
        }
        public static void GetStudentData(Student varStudent)
        {
            Console.WriteLine(varStudent.Name);
            Console.WriteLine(varStudent.Age);
            Console.WriteLine(varStudent.HairColor);
            Console.WriteLine(varStudent.Height);
            Console.WriteLine(varStudent.Sex);
            Console.WriteLine(varStudent.Weight);
        }

    }

    public class Program
    {
        static void Main(string[] args)
        {
            Student firstStudent = new Student() { Name = "Антон", Age = 20, HairColor = "черный", Height = 180, Sex = "мужской", Weight = 65 };
            Student secondStudent = new Student() { Name = "Даша", Age = 22, HairColor = "бордовый", Height = 168, Sex = "женский", Weight = 48 };

            Student.GetStudentData(firstStudent.Add(secondStudent));
        }
    }
}
