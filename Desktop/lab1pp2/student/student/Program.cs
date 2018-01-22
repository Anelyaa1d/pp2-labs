using System;

namespace lab1
{
    public class Student
    {
        public string name;
        public float gpa;
        public int age;
        public Student()
        {
            name = "KBTU";
            gpa = 4;
            age = 18;
        }
        public Student(string n, float g, int a)
        {
            name = n;
            gpa = g;
            age = a;
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
            Student s = new Student();
            Console.WriteLine(s);
            Console.ReadKey();

        }
    }
}
