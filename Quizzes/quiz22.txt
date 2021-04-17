using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpQuiz22
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle a = new Circle(3);
            Console.WriteLine(a.ToString());
            Circle b = new Circle(4);
            Console.WriteLine(b.ToString());
            Console.WriteLine("New + Operator");
            Circle c = (a + b);
            Console.WriteLine(c.ToString());
            Console.WriteLine("New - Operator");
            c = (a - b);
            Console.WriteLine(c.ToString());
            Console.WriteLine("New * Operator");
            c = a * b;
            Console.WriteLine(c.ToString());
        }
        struct Circle
        {
            private double Radius { get; set; }
            private string Name { get; set; }
            private double Area { get; set; }
            private double Diameter { get; set; }
            private double Circumference { get; set; }

            public Circle(double radius)
            {
                Radius = radius;
                Area = Math.PI * radius * radius;
                Name = "Circle";
                Diameter = 2 * radius;
                Circumference = Math.PI * Diameter;
            }


            public override string ToString() => $"I am a {Name} and my radius is {Radius} and my area is {Area} and my circumference is {Circumference}!";
            public static Circle operator +(Circle lhs, Circle rhs)
            {
                return new Circle(radius: Math.Sqrt((lhs.Area + rhs.Area) / Math.PI));
            }
            public static Circle operator *(Circle lhs, Circle rhs)
            {
                return new Circle(radius: Math.Sqrt((lhs.Area * rhs.Area) / Math.PI));
            }
            public static Circle operator -(Circle lhs, Circle rhs)
            {
                if (lhs.Area > rhs.Area)
                    return new Circle(radius: Math.Sqrt((lhs.Area - rhs.Area) / Math.PI));
                else
                {
                    return new Circle(radius: Math.Sqrt((rhs.Area - lhs.Area) / Math.PI));
                }
            }
        }
    }
}