using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz20
{
    class Program
    {
        public delegate void MyDelegate();

        class Rifle
        {
            public void printRifle()
            {
                Console.WriteLine("I am a shotgun and I go Boom");
            }
        }

        class Pistol
        {
            public void printPistol()
            {
                Console.WriteLine("I am a rifle and I go Bang");
            }
        }

        class Shotgun
        {
            public void printShotgun()
            {
                Console.WriteLine("I am a pistol and I go Pop");
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("This is C Sharp quiz 20");

            Rifle   rifle   = new Rifle();
            Pistol  pistol  = new Pistol();
            Shotgun shotgun = new Shotgun();

            MyDelegate myDelegate = new MyDelegate(rifle.printRifle);

            myDelegate += pistol.printPistol;
            myDelegate += shotgun.printShotgun;

            myDelegate();

            Console.WriteLine("Press any key to Continue ...");
            Console.ReadKey();

        }
    }
}
