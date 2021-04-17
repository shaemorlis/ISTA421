using System;

namespace MathGames
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Math Games");
            Util util = new Util();
            int probType = 0;
            int numProb = 0;
            int score = 0;
            (probType, numProb) = util.Initialize();
             if(probType == 1)
                score = util.Add(numProb);
             else if(probType == 2)
                score = util.Subtract(numProb);
             else if(probType == 3)
                score = util.Multiply(numProb);
             else if(probType == 4)
                score = util.Divide(numProb);  
             else
             {
                Console.WriteLine("Sorry, you made an invalid choice.");
                Environment.Exit(0);
             }             

             string report = util.Report(score, numProb);
             Console.WriteLine(report);
        }
    }
}
