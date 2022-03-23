using System;


namespace MP.Utils
{
    public class MathHelper
    {
        public static int GetNumberOfDigits(long number)
        {
            int count = 0;

            do
            {
                count++;
                number /= 10;
            }
            while (number != 0);

            return count;
        }

        public static bool CheckOddNumber(int number)
        {
            return number % 2 != 0;
        }

        public static int GetMaxCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                int c = a % b;
                a = b;
                b = c;
            }

            return Math.Abs(a);
        }
    }
}
