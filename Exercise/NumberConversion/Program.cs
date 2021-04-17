using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberConversion
{
    class Program
    {
        
        static void Main(string[] args)
        {
            const int BASE_2    = 2;
            const int BASE_8    = 8;
            const int BASE_10   = 10;
            const int BASE_16   = 16;

            Util utilObj = new Util();

            while (true)
            {
                
                // check  to see  if  we will go  for  another round
                Console.Write("Enter Q to exit, N to continue: ");
                string exit = Console.ReadLine();
                if (exit == "Q" || exit == "q")
                    Environment.Exit(0);

                // get  the  base  to convert  from
                Console.Write("Please enter the base to convert from [2 | 8 | 10 | 16] : ");

                string n2 = Console.ReadLine();
                int from = int.Parse(n2);

                //  get  the "number" to  convert
                Console.Write("Please enter the integer to convert : ");
                string n1 = Console.ReadLine();
                int number;

                bool success = Int32.TryParse(n1,out number);

                if (success)
                    Console.WriteLine($" Number:{ number}, Base :{ from}\n");
                else
                    Console.WriteLine($" Number:{ n1}, Base :{ from}\n");
                long result = 0;
                string str_result = "";

                if (from == BASE_10)
                {
                    result = utilObj.dec2bin(number);
                    Console.WriteLine($" Binary conversion is: { result}");
                    result = utilObj.dec2oct(number);
                    Console.WriteLine($" Octal conversion is: { result}");
                    str_result = utilObj.dec2hex(number);
                    Console.WriteLine($" Hex conversion is: { str_result}");
                }

                else if (from == BASE_2)
                {
                    result = utilObj.bin2dec(number);
                    Console.WriteLine($" Decimal conversion is: { result}");
                    result = utilObj.bin2oct(number);
                    Console.WriteLine($" Octal conversion is: { result}");
                    str_result = utilObj.bin2hex(number);
                    Console.WriteLine($" Hex conversion is: { str_result}");
                }

                else if (from == BASE_8)
                {
                    result = utilObj.oct2bin(number);
                    Console.WriteLine($" Binary conversion is: { result}");
                    result = utilObj.oct2dec(number);
                    Console.WriteLine($" Decimal conversion is: { result}");
                    str_result = utilObj.oct2hex(number);
                    Console.WriteLine($" Hex conversion is: { str_result}");
                }

                else if (from == BASE_16)
                {
                    result = utilObj.hex2bin(n1);
                    Console.WriteLine($" Binary conversion is: { result}");
                    result = utilObj.hex2oct(n1);
                    Console.WriteLine($" Octal conversion is: { result}");
                    result = utilObj.hex2dec(n1);
                    Console.WriteLine($" Decimal conversion is: { result}");
                }

                else
                {
                    Console.WriteLine("Error in base to convert from.");
                }

            }
        }
    }
}
