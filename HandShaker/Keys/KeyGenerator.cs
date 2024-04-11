using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandShaker.Keys
{
    public static class KeyGenerator
    {
        private static readonly Random random = new Random();

        public static string GenerateKey(int length)
        {
            var resultChars = new char[length];

            for (int i = 0; i < length; ++i)
            {
                var curCharType = random.Next(3);

                if (curCharType == 0)
                {
                    // current char is a capital letter
                    resultChars[i] = (char)random.Next('A', 'Z' + 1);
                }
                else if (curCharType == 1)
                {
                    // current char is a small letter
                    resultChars[i] = (char)random.Next('a', 'z' + 1);
                }
                else
                {
                    // current char is a digit
                    resultChars[i] = (char)random.Next('0', '9' + 1);
                }
            }

            return new string(resultChars);
        }

        public static string GenerateKey(int minLength, int maxLength)
        {
            var length = random.Next(minLength, maxLength + 1);

            var resultChars = new char[length];

            for (int i = 0; i < length; ++i)
            {
                var curCharType = random.Next(3);

                if (curCharType == 0)
                {
                    // current char is a capital letter
                    resultChars[i] = (char)random.Next('A', 'Z' + 1);
                }
                else if (curCharType == 1)
                {
                    // current char is a small letter
                    resultChars[i] = (char)random.Next('a', 'z' + 1);
                }
                else
                {
                    // current char is a digit
                    resultChars[i] = (char)random.Next('0', '9' + 1);
                }
            }

            return new string(resultChars);
        }
    

        public static string GetUniversalKey()
        {
            var key = "asgrfghk--gg.x?Z".Substring(0, 16);

            return key;
        }
    }

    
}
