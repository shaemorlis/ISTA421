using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cssbs_ex14
{
    class Util
    {
        private static int[] counting = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };
        private static char[] alphabets = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private static int[] conti_enc_key;

        public static string GetPlainText()
        {
            string enteredText;
            Console.Write("Enter plain text: ");
            enteredText = Console.ReadLine();

            return enteredText.ToUpper();
        }

        public static string GetSingleKey()
        {
            string key;

            while (true)
            {
                Console.Write("Enter your single key as a Alpha character: ");
                key = Console.ReadLine();

                if (key.Length == 1 && Char.IsLetter(key[0])) // if length is 1 then it should be character
                    break;
                else
                    Console.WriteLine("single key should be one Alpha character!!!!!");
            }

            return key.ToUpper();
        }

        public static string GetMultiKey()
        {
            string key;
            Console.Write("Enter your multi key as a Alpha characters: ");
            key = Console.ReadLine();

            return key.ToUpper();
        }

        public static int[] Clean(string plaintext)
        {

            int newArrayCount = 0;
            for (int i = 0; i < plaintext.Length; i++)
            {
                int value = (char)plaintext[i];
                if (value >= 65 && value <= 90)
                    newArrayCount++;
            }
            int[] array = new int[newArrayCount];

            int newArrayIndex = 0;

            for (int i = 0; i < plaintext.Length; i++)
            {
                int value = (char)plaintext[i];
                if (value >= 65 && value <= 90)
                {
                    array[newArrayIndex] = plaintext[i];
                    newArrayIndex++;
                }

            }

            return array;
        }

        public static string SingleEnc(int[] clean_text, int[] clean_skey)
        {
            char[] encryptedString = new char[clean_text.Length];
            int[] encryptedIntegerArray = new int[clean_text.Length];

            for (int i = 0; i < clean_text.Length; i++)
            {
                int sumNumber = 0;
                for (int k = 0; k < counting.Length; k++)
                    if ((char)clean_skey[0] == alphabets[k])
                        sumNumber = counting[k];

                int sum = clean_text[i] + sumNumber;
                if (sum > 90)
                    encryptedIntegerArray[i] = sum - 26;
                else
                    encryptedIntegerArray[i] = sum;

                encryptedString[i] = (char)encryptedIntegerArray[i];
            }

            return new string(encryptedString); // converting char array to string
        }

        public static string MultiEnc(int[] clean_text, int[] clean_mkey)
        {
            char[] encryptedString = new char[clean_text.Length];
            int[] encryptedIntegerArray = new int[clean_text.Length];
            int[] newKey = new int[clean_text.Length];
            int encryptedIntegerArrayIndex = 0;

            int i = 0;
            while (i < clean_text.Length)
            {
                for (int j = 0; j < clean_mkey.Length; j++)
                {
                    if (i < clean_text.Length)
                    {
                        newKey[i] = clean_mkey[j];
                        i++;

                    }
                }
            }

            for (i = 0; i < clean_text.Length; i++)
            {
                int sumNumber = 0;
                for (int k = 0; k < counting.Length; k++)
                    if ((char)newKey[i] == alphabets[k])
                    {
                        sumNumber = counting[k];
                        break;
                    }


                int sum = clean_text[i] + sumNumber;
                if (sum > 90)
                    encryptedIntegerArray[encryptedIntegerArrayIndex] = sum - 26;
                else
                    encryptedIntegerArray[encryptedIntegerArrayIndex] = sum;
                encryptedIntegerArrayIndex++;
            }

            for (i = 0; i < clean_text.Length; i++)
                encryptedString[i] = (char)encryptedIntegerArray[i];

            return new string(encryptedString); // converting char array to string
        }

        public static string ContiEnc(int[] clean_text, int[] clean_mkey)
        {
            char[] encryptedString = new char[clean_text.Length];
            int[] encryptedIntegerArray = new int[clean_text.Length];
            int[] newKey = new int[clean_text.Length];
            int encryptedIntegerArrayIndex = 0;

            int indexNewKey = 0;
            for (int j = 0; j < clean_mkey.Length && j < clean_text.Length; j++)
            {
                newKey[indexNewKey] = clean_mkey[j];
                indexNewKey++;
            }

            for (int i = 0; indexNewKey < clean_text.Length; i++)
            {
                newKey[indexNewKey] = clean_text[i];
                indexNewKey++;
            }

            conti_enc_key = new int[newKey.Length];
            for (int i = 0; i < newKey.Length; i++)
                conti_enc_key[i] = newKey[i];

            for (int i = 0; i < clean_text.Length; i++)
            {
                int sumNumber = 0;
                for (int k = 0; k < counting.Length; k++)
                    if ((char)newKey[i] == alphabets[k])
                    {
                        sumNumber = counting[k];
                        break;
                    }


                int sum = clean_text[i] + sumNumber;
                if (sum > 90)
                    encryptedIntegerArray[encryptedIntegerArrayIndex] = sum - 26;
                else
                    encryptedIntegerArray[encryptedIntegerArrayIndex] = sum;
                encryptedIntegerArrayIndex++;
            }

            for (int i = 0; i < clean_text.Length; i++)
                encryptedString[i] = (char)encryptedIntegerArray[i];

            return new string(encryptedString); // converting char array to string
        }

        public static string ContiDec(string enc_conti, int[] clean_mkey)
        {
            char[] decryptedString = new char[enc_conti.Length];
            int[] decryptedIntegerArray = new int[enc_conti.Length];
            int[] newKey = new int[enc_conti.Length];
            int decryptedIntegerArrayIndex = 0;

            for (int i = 0; i < newKey.Length; i++)
                newKey[i] = conti_enc_key[i];

            for (int i = 0; i < enc_conti.Length; i++)
            {
                int sumNumber = 0;
                for (int k = 0; k < counting.Length; k++)
                    if ((char)newKey[i] == alphabets[k])
                    {
                        sumNumber = counting[k];
                        break;
                    }


                int sum = enc_conti[i] - sumNumber;
                if (sum < 65)
                    decryptedIntegerArray[decryptedIntegerArrayIndex] = sum + 26;
                else
                    decryptedIntegerArray[decryptedIntegerArrayIndex] = sum;
                decryptedIntegerArrayIndex++;
            }

            for (int i = 0; i < enc_conti.Length; i++)
                decryptedString[i] = (char)decryptedIntegerArray[i];

            return new string(decryptedString); // converting char array to string
        }

        public static string MultiDec(string enc_multi, int[] clean_mkey)
        {
            char[] decryptedString = new char[enc_multi.Length];
            int[] decryptedIntegerArray = new int[enc_multi.Length];
            int[] newKey = new int[enc_multi.Length];
            int decryptedIntegerArrayIndex = 0;

            int i = 0;
            while (i < enc_multi.Length)
            {
                for (int j = 0; j < clean_mkey.Length; j++)
                {
                    if (i < enc_multi.Length)
                    {
                        newKey[i] = clean_mkey[j];
                        i++;

                    }
                }
            }

            for (i = 0; i < enc_multi.Length; i++)
            {
                int sumNumber = 0;
                for (int k = 0; k < counting.Length; k++)
                    if ((char)newKey[i] == alphabets[k])
                    {
                        sumNumber = counting[k];
                        break;
                    }


                int sum = enc_multi[i] - sumNumber;
                if (sum < 65)
                    decryptedIntegerArray[decryptedIntegerArrayIndex] = sum + 26;
                else
                    decryptedIntegerArray[decryptedIntegerArrayIndex] = sum;
                decryptedIntegerArrayIndex++;
            }

            for (i = 0; i < enc_multi.Length; i++)
                decryptedString[i] = (char)decryptedIntegerArray[i];

            return new string(decryptedString); // converting char array to string
        }

        public static string SingleDec(string enc_single, int[] clean_skey)
        {
            char[] decryptedString = new char[enc_single.Length];
            int[] decryptedIntegerArray = new int[enc_single.Length];

            for (int i = 0; i < enc_single.Length; i++)
            {
                int sumNumber = 0;
                for (int k = 0; k < counting.Length; k++)
                    if ((char)clean_skey[0] == alphabets[k])
                        sumNumber = counting[k];

                int sub = enc_single[i] - sumNumber;
                if (sub < 65)
                    decryptedIntegerArray[i] = sub + 26;
                else
                    decryptedIntegerArray[i] = sub;

                decryptedString[i] = (char)decryptedIntegerArray[i];
            }

            return new string(decryptedString); // converting char array to string
        }
    }



    class Program
    {
        static void Main(string[] args)
        {

            string plaintext = Util.GetPlainText();
            string singlekey = Util.GetSingleKey();
            string multikey = Util.GetMultiKey();
            Console.WriteLine();

            Console.WriteLine($"You entered [{ plaintext.ToLower() }] as plaintext");
            Console.WriteLine($"You entered [{ singlekey.ToLower() }] as your singlekey");
            Console.WriteLine($"You entered [{ multikey.ToLower() }] as your multikey");
            Console.WriteLine();

            int[] clean_text = Util.Clean(plaintext);
            int[] clean_skey = Util.Clean(singlekey);
            int[] clean_mkey = Util.Clean(multikey);

            string enc_single = Util.SingleEnc(clean_text, clean_skey);
            string enc_multi = Util.MultiEnc(clean_text, clean_mkey);
            string enc_conti = Util.ContiEnc(clean_text, clean_mkey);

            Console.WriteLine($"Encrypted message with single key is [{ enc_single }] ");
            Console.WriteLine($"Encrypted message with multi key is [{ enc_multi }] ");
            Console.WriteLine($"Encrypted message with continous key is [{ enc_conti }] ");
            Console.WriteLine();

            string dec_single = Util.SingleDec(enc_single, clean_skey);
            string dec_multi = Util.MultiDec(enc_multi, clean_mkey);
            string dec_conti = Util.ContiDec(enc_conti, clean_mkey);

            Console.WriteLine($"Decrypted message with single key is [{ dec_single }] ");
            Console.WriteLine($"Decrypted message with multi key is [{ dec_multi }] ");
            Console.WriteLine($"Decrypted message with continous key is [{ dec_conti }] ");
            Console.WriteLine("\nPress any key to continue......");

            Console.ReadLine();

        }
    }
}
