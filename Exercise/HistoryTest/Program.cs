using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace cssbs_ex13
{
    class Program
    {
        static void Main(string[] args)
        {
            Util util = new Util();

            Console.WriteLine("Initializing test bank ...\n");

            // initialize test
            List<string> testBank = util.Initialize();
            Console.WriteLine($"Test bank initialized , {testBank.Count} lines.");

            // Create a test
            Console.Write($"How many questions would you like to answer? " +
            $" Enter from 1 to { testBank.Count } : ");

            int howMany = int.Parse(Console.ReadLine());
            List<string> test = util.MakeTest(testBank, howMany);
            Console.WriteLine($"Test created, { test.Count} questions.");

            // Give test
            Console.WriteLine("−−−−−−−−−−−−−−−−−−−−−−−−\n" +
            "Press any key to start test. \n" +
            "−−−−−−−−−−−−−−−−−−−−−−−−");

            Console.ReadKey();
            int score = util.GiveTest(test);
            Console.WriteLine($"You answered { score } out of { howMany} correctly " +
            $"and your grade is { (double)score / howMany * 100.0}");
        }
    }
}
