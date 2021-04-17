using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Bridge
{
   public class Util
    {
       public Util()
        {

        }
        public List<string> Initialize()
        {
            List<string> testBank = new List<string>();

            using (var reader = new StreamReader(@"../../Questions.csv"))
            {                
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    testBank.Add(line);
                }
            }
            return testBank;
        }
        public List<string> MakeTest(List<string> testBank, int howMany)
        {
            List<string> test = new List<string>();
            List<int> randomNumbers = new List<int>();
            int number = 0;
            Random _random = new Random();            
            
            for (int i = 0; i < howMany; i++)
            {
                do
                {
                    number = _random.Next(0, testBank.Count-1);
                } while (randomNumbers.Contains(number));

                randomNumbers.Add(number);
                test.Add(testBank[randomNumbers[i]]);
            }            
            return test;
        }
        public int GiveTest(List<string> test)
        {
            int score = 0; int number = 0;
            List<string> correctAnswers = new List<string>();
            List<int> randomNumbers = new List<int>();
            Random _random = new Random();
            for (int i=0;i<test.Count;i++)
            {
                var line = test[i];
                var values = line.Split(',');
                correctAnswers.Add(values[1]);
                
                Console.WriteLine(i+1 + ". \"" + values[0] + "?\"");
                int j = 0;
                for (;j<4;j++)
                {
                    do
                    {
                        number = _random.Next(1, 5);
                    } while (randomNumbers.Contains(number));
                    randomNumbers.Add(number);
                    Console.Write("\t\t" + (j+1) + ". \"" + values[randomNumbers[j]] + "\"\n");
                }

                int option;
                string input;
                
                Console.Write("Enter your answer: ");
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Sorry, the correct answer is \"" + correctAnswers[i] + "\"");
                    randomNumbers.Clear();
                    continue;
                }

                else if (!randomNumbers.Contains(int.Parse(input)))
                {                    
                    do
                    {
                        Console.Write("Choose from given options!\n");
                        Console.Write("Enter your answer: ");
                        input = Console.ReadLine();
                        
                        } while (!randomNumbers.Contains(int.Parse(input)));
                }

                else
                    option = int.Parse(input);

                    string userAnswer = "";
                    option = int.Parse(input);
                    userAnswer = values[randomNumbers[option - 1]];
                    if (userAnswer == correctAnswers[i])
                    {
                        Console.WriteLine("Correct! Good job.");
                        score++;
                    }
                    else
                        Console.WriteLine("Sorry, the correct answer is \"" + correctAnswers[i] + "\"");              

                randomNumbers.Clear();
            }
            return score;
        }
    }
}
