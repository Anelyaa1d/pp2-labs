using System;

namespace lab1
{
    public class Student
    {
        public string name;
        public double gpa;
        public int age;
        public Student()
        {
            name = "KBTU";
            gpa = 4;
            age = 18;
        }
        public Student(string n, double g, int a)
        {
            name = n;
            gpa = g;
            age = a;
        }
        public Student(string a, double b)
        {
            name = a;
            gpa = b;
        }
        public override string ToString()
        {
            return name + " " + gpa + " " + age;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s2 = new Student();
            Student s = new Student("Meder",4.0);
            Console.WriteLine(s);
            Console.ReadKey();

        }
    }
}
