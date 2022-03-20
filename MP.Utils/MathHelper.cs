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

        static bool CheckOddNumber(int number)
        {
            return number % 2 != 0;
        }
    }
}
