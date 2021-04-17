using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace cssbs_ex09
{
    class Util
    {
        //Dictionary for holding Account Information
        static Dictionary<string, string> Accounts = new Dictionary<string, string>();

        //Encrypt data using SHA
        public static string Encrypt(string key, string data)
        {
            string encData = null;
            //Getting Hash keys from the input key
            byte[][] keys = GetHashKeys(key);

            try
            {
                //Encrypting String to Bytes. 
                encData = EncryptStringToBytes_Aes(data, keys[0], keys[1]);
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine("CryptographicException Occurred: " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("ArgumentNullException Occurred: " + ex.Message);
            }

            return encData;
        }
        //Decrypt data using SHA
        public static string Decrypt(string key, string data)
        {
            string decData = null;
            //Getting Hash keys from the input key
            byte[][] keys = GetHashKeys(key);

            try
            {
                //Decrypting String from given bytes and keys
                decData = DecryptStringFromBytes_Aes(data, keys[0], keys[1]);
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine("CryptographicException Occurred: " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("ArgumentNullException Occurred: " + ex.Message);
            }

            return decData;
        }

        //Getting hash keys
        private static byte[][] GetHashKeys(string key)
        {
            byte[][] result = new byte[2][];
            Encoding enc = Encoding.UTF8;

            SHA256 sha2 = new SHA256CryptoServiceProvider();

            byte[] rawKey = enc.GetBytes(key);
            byte[] rawIV = enc.GetBytes(key);

            byte[] hashKey = sha2.ComputeHash(rawKey);
            byte[] hashIV = sha2.ComputeHash(rawIV);

            Array.Resize(ref hashIV, 16);

            result[0] = hashKey;
            result[1] = hashIV;

            return result;
        }

        //Encrypting String to Bytes.
        private static string EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            byte[] encrypted;

            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt =
                            new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(encrypted);
        }

        //Decrypting String from given bytes and keys
        private static string DecryptStringFromBytes_Aes(string cipherTextString, byte[] Key, byte[] IV)
        {
            byte[] cipherText = Convert.FromBase64String(cipherTextString);

            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            string plaintext = null;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt =
                            new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }

        //Printing the Menu
        public static int printUI()
        {
            while (true)
            {

                Console.WriteLine("--------------------------------------------------------------------\n");
                Console.WriteLine("\n\tPASSWORD AUTHENTICATION SYSTEM\n");
                Console.WriteLine("\n\tPlease select one option:\n");
                Console.WriteLine("\n\t1. Establish an account");
                Console.WriteLine("\n\t2. Authenticate a user");
                Console.WriteLine("\n\t3. Exit the system\n");
                Console.Write("\n\tEnter selection: ");

                string choose = Console.ReadLine();

                try
                {
                    int choice = int.Parse(choose);
                    Console.WriteLine("\n\n--------------------------------------------------------------------");
                    return choice;
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n\tPlease enter the integer value\n");
                }
            }
        }

        //Getting user from the List if Exist else create new
        public static void getNewUser()
        {

            Console.Write("\tPlease enter the Username: ");
            string username = Console.ReadLine();

            Console.Write("\n\tPlease enter the Password: ");
            string password = Console.ReadLine();

            if (Accounts.ContainsKey(username))
            {
                Console.WriteLine("\n\tUser already Exists with Username: " + username);
            }
            else
            {
                string encryptedPassword = Encrypt(username, password);
                Accounts[username] = encryptedPassword;
                Console.WriteLine("\n\tUser entered succesfully");
            }

        }
        //Printing User State
        public static void printUsers()
        {
            if (Accounts.Count == 0)
                Console.WriteLine("\tNo Existing Users :\n");
            else
            {
                Console.WriteLine("\tExisting Users");
                for (int index = 0; index < Accounts.Count; index++)
                {
                    var account = Accounts.ElementAt(index);
                    var itemKey = account.Key;
                    Console.WriteLine("\t" + itemKey + "\n");
                }
            }
        }
        //Getting user details
        public static void getUser()
        {
            Console.Write("\tPlease enter the Username: ");
            string username = Console.ReadLine();

            Console.Write("\n\tPlease enter the Password: ");
            string password = Console.ReadLine();

            foreach (var account in Accounts)
            {
                if (account.Key.Equals(username))
                {
                    string DecryptedPassword = Decrypt(username, Accounts[username]);
                    if (DecryptedPassword.Equals(password))
                    {
                        Console.WriteLine("\n\tCongratulations!!!! User Authenticated");
                    }
                    else
                    {
                        Console.WriteLine("\n\tUsername found but Password was not correct");
                    }
                }
                else
                {
                    Console.WriteLine("\n\tUser Not Autheticated");
                }
            }
        }
    }
    class Program
    {
        //Driver program
        static void Main(string[] args)
        {

            int userResponse = 3;
            
            while (userResponse != 0)
            {
                userResponse = Util.printUI();
                if (userResponse == 1)
                {
                    Util.getNewUser();
                }
                else if (userResponse == 2)
                {
                    Util.getUser();
                    //userResponse = Util.printUI(); 
                }
                else if (userResponse == 3)
                {
                    Util.printUsers();
                    userResponse = 0;
                    //userResponse = Util.printUI();
                }
                else
                {
                    Console.WriteLine("Sorry , I didn't understand what you wanted to do.");
                    //userResponse = Util.printUI();
                }
            };
            Console.WriteLine("Exiting.....");
            Console.ReadLine();
            System.Environment.Exit(0);

        }
    }
}
