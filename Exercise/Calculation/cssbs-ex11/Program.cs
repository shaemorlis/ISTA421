using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cssbs_ex11
{
    struct point
    {
        public int x;
        public int y;
        public int z;
    }
    class Datum2
    {
        int countX = 0;
        int countY = 0;
        public point[] points = new point[100];
        public int GenerateRandomNumbersForX()
        {
            int numberX = 0;
            Random rand = new Random();
            numberX = rand.Next(1, 100);
            points[countX].x = numberX;
            countX++;

            return numberX;
        }
        public int GenerateRandomNumbersForY()
        {
            int numberY = 0;
            Random rand = new Random();
            numberY = rand.Next(1, 100);
            points[countY].y = numberY;
            countY++;

            return numberY;
        }

        public float Calculate2DDistance(point p1, point p2)
        {
            float distance = (float)Math.Sqrt(((p2.x - p1.x) * (p2.x - p1.x)) + ((p2.y - p1.y) * (p2.y - p1.y)));
            return distance;
        }

        public void CalculateShortest2DDistance()
        {
            float shortestDistance = 100000;
            for (int i = 0; i < 100; i++)
            {
                for (int j = i + 1; j < 99; j++)
                {
                    float currentDistance = Calculate2DDistance(points[i], points[j]);
                    if (shortestDistance > currentDistance)
                    {
                        shortestDistance = currentDistance;
                        Console.WriteLine("The closest points are array element  " + i + " -- " + points[i].x + ", " + points[i].y + " array element " + j + " -- " + points[j].x + ", " + points[j].y + " having a distance of " + shortestDistance);
                    }
                }
            }
        }
    }
    class Datum3
    {
        int countX = 0;
        int countY = 0;
        int countZ = 0;
        public point[] points = new point[100];
        public int GenerateRandomNumbersForX()
        {
            int numberX = 0;
            Random rand = new Random();
            numberX = rand.Next(1, 1000);
            points[countX].x = numberX;
            countX++;

            return numberX;
        }
        public int GenerateRandomNumbersForY()
        {
            int numberY = 0;
            Random rand = new Random();
            numberY = rand.Next(1, 1000);
            points[countY].y = numberY;
            countY++;

            return numberY;
        }
        public int GenerateRandomNumbersForZ()
        {
            int numberZ = 0;
            Random rand = new Random();
            numberZ = rand.Next(1, 1000);
            points[countZ].z = numberZ;
            countZ++;

            return numberZ;
        }

        public float Calculate3DDistance(point p1, point p2)
        {
            float distance = (float)Math.Sqrt(((p2.x - p1.x) * (p2.x - p1.x)) + ((p2.y - p1.y) * (p2.y - p1.y)) + ((p2.z - p1.z) * (p2.z - p1.z)));
            return distance;
        }

        public void CalculateShortest3DDistance()
        {
            float shortestDistance = 100000;
            for (int i = 0; i < 100; i++)
            {
                for (int j = i + 1; j < 99; j++)
                {
                    float currentDistance = Calculate3DDistance(points[i], points[j]);
                    if (shortestDistance > currentDistance)
                    {
                        shortestDistance = currentDistance;
                        Console.WriteLine("The closest points are array element  " + i + " -- " + points[i].x + ", " + points[i].y + ", " + points[i].z + " array element " + j + " -- " + points[j].x + ", " + points[j].y + ", " + points[j].z + " having a distance of " + shortestDistance);
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is the Vector Distance exercise");
            bool again = true;
            while (again)
            {
                Console.Write("\nEnter 2 to calculate 2 element vector, " + " 3 to calculate 3 element vector, 9 to quit: ");
                string input = Console.ReadLine();

                if (input.Equals("2"))
                {
                    Console.WriteLine("\n two element vector");
                    Datum2 d2 = new Datum2();

                    for (int i = 0; i < 100; i++)
                    {
                        d2.points[i].x = d2.GenerateRandomNumbersForX();
                        d2.points[i].y = d2.GenerateRandomNumbersForY();
                    }

                    d2.CalculateShortest2DDistance();
                }

                else if (input.Equals("3"))
                {
                    Console.WriteLine("\n three element vector");
                    Datum3 d3 = new Datum3();

                    for (int i = 0; i < 100; i++)
                    {
                        d3.points[i].x = d3.GenerateRandomNumbersForX();
                        d3.points[i].y = d3.GenerateRandomNumbersForY();
                        d3.points[i].z = d3.GenerateRandomNumbersForZ();
                    }

                    d3.CalculateShortest3DDistance();
                }

                else if (input.Equals("9"))
                    again = false;

                else
                    Console.WriteLine("\n Didn’t recognize input");
            }
            Environment.Exit(0);
        }
    }
}
