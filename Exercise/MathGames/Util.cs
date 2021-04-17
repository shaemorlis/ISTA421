using System;
using System.Collections.Generic;
using System.Text;

namespace MathGames
{
    class Util
    {
        public (int,int) Initialize()
        {
            int probType = 0;
            int numProb = 0;
            Console.WriteLine("  To add, enter 1,");
            Console.WriteLine("  To subtract, enter 2,");
            Console.WriteLine("  To multiply, enter 3,");
            Console.WriteLine("  To divide, enter 4.");
            Console.Write("Choose your problem type: ");
            probType = Convert.ToInt32(Console.ReadLine());            
            
            switch (probType)
            {
                case 1:
                    do
                    {
                        Console.Write("Enter number of problems between 1 and 12: ");
                        numProb = Convert.ToInt32(Console.ReadLine());
                    } while (numProb < 1 || numProb > 12);
                                          
                    Console.Write("You are testing Addition and you have " + numProb + " problems\nTo begin your test, type any key: ");
                    Console.ReadKey();
                    Console.WriteLine();
                    break;
                case 2:
                    do
                    {
                        Console.Write("Enter number of problems between 1 and 12: ");
                        numProb = Convert.ToInt32(Console.ReadLine());
                    } while (numProb < 1 || numProb > 12);

                    Console.Write("You are testing Subtraction and you have " + numProb + " problems\nTo begin your test, type any key: ");
                    Console.ReadKey();
                    Console.WriteLine();
                    break;
                case 3:
                    do
                    {
                        Console.Write("Enter number of problems between 1 and 12: ");
                        numProb = Convert.ToInt32(Console.ReadLine());
                    } while (numProb < 1 || numProb > 12);

                    Console.Write("You are testing Multiplication and you have " + numProb + " problems\nTo begin your test, type any key: ");
                    Console.ReadKey();
                    Console.WriteLine();
                    break;
                case 4:
                    do
                    {
                        Console.Write("Enter number of problems between 1 and 12: ");
                        numProb = Convert.ToInt32(Console.ReadLine());
                    } while (numProb < 1 || numProb > 12);

                    Console.Write("You are testing Division and you have " + numProb + " problems\nTo begin your test, type any key: ");
                    Console.ReadKey();
                    Console.WriteLine();
                    break;
                default:                    
                    break;
            }

            return (probType, numProb);
        }

        public int Add(int numOfProblems)
        {
            int num1 = 0, num2 = 0, score = 0;
            int userResult = 0 , actualResult = 0;
            string input = "";
            Random random = new Random();            

            for(int i=1;i<=numOfProblems;i++)
            {
                num1 = random.Next(1, 12);
                num2 = random.Next(1, 12);

                actualResult = num1 + num2;

                Console.Write(i + ". " + num1 + " + " + num2 + " = ");
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Sorry, the correct answer is " + actualResult);
                    continue;
                }
                else
                {
                    userResult = Convert.ToInt32(input);
                }               

                if(userResult == actualResult)
                {                    
                    Console.WriteLine("Correct.");
                    score++;
                }
                else
                {
                    Console.WriteLine("Sorry, the correct answer is " + actualResult);
                }
            }
            return score;
        }

        public int Subtract(int numOfProblems)
        {
            int num1 = 0, num2 = 0, score = 0;
            int userResult = 0, actualResult = 0;
            string input = "";
            Random random = new Random();

            for (int i = 1; i <= numOfProblems; i++)
            {
                num1 = random.Next(1, 12);
                num2 = random.Next(1, 12);

                if (num1 > num2)
                {
                    actualResult = num1 - num2;
                    Console.Write(i + ". " + num1 + " - " + num2 + " = ");
                }
                else
                {
                    actualResult = num2 - num1;
                    Console.Write(i + ". " + num2 + " - " + num1 + " = ");
                }
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Sorry, the correct answer is " + actualResult);
                    continue;
                }
                else
                {
                    userResult = Convert.ToInt32(input);
                }              

                if (userResult == actualResult)
                {
                    Console.WriteLine("Correct.");
                    score++;
                }
                else
                {
                    Console.WriteLine("Sorry, the correct answer is " + actualResult);
                }
            }
            return score;
        }

        public int Multiply(int numOfProblems)
        {
            int num1 = 0, num2 = 0, score = 0;
            int userResult = 0, actualResult = 0;
            string input = "";
            Random random = new Random();

            for (int i = 1; i <= numOfProblems; i++)
            {
                num1 = random.Next(1, 12);
                num2 = random.Next(1, 12);

                actualResult = num1 * num2;

                Console.Write(i + ". " + num1 + " * " + num2 + " = ");
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Sorry, the correct answer is " + actualResult);
                    continue;
                }
                else
                {
                    userResult = Convert.ToInt32(input);
                }                

                if (userResult == actualResult)
                {
                    Console.WriteLine("Correct.");
                    score++;
                }
                else
                {
                    Console.WriteLine("Sorry, the correct answer is " + actualResult);
                }
            }
            return score;
        }

        public int Divide(int numOfProblems)
        {
            float num1 = 0, num2 = 0;
            int score = 0;
            float userResult = 0, actualResult = 0;
            string input = "";
            Random random = new Random();

            for (int i = 1; i <= numOfProblems; i++)
            {
                num1 = random.Next(1, 12);
                num2 = random.Next(1, 12);

                actualResult = num1 / num2;
                actualResult = (float)Math.Round(actualResult, 2);

                Console.Write(i + ". " + num1 + " / " + num2 + " = ");
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Sorry, the correct answer is " + actualResult);
                    continue;
                }
                else
                {
                    userResult = float.Parse(input);
                    userResult = (float)Math.Round(userResult, 2);
                }               

                if (userResult == actualResult)
                {
                    Console.WriteLine("Correct.");
                    score++;
                }
                else
                {
                    Console.WriteLine("Sorry, the correct answer is " + actualResult);
                }
            }
            return score;
        }

        public string Report(int score, int numOfProblems)
        {
            float average = 0, scores = 0, problems = 0;
            scores = (float)score;
            problems = (float)numOfProblems;
            average = scores / problems;
            average = average * 100;
            int grade = (int)(average);
            string report = "You got " + score + " out of " + numOfProblems + " correct and your grade is " + grade;
            return report;
        }

    }
}
