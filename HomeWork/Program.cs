using System;
using MP.Utils;


namespace HomeWork
{
    //author: Maxim Pokrovsky
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
        }

        #region Task 01

        /*
                Написать метод, возвращающий минимальное из трёх чисел. 
         */

        static void Task1()
        {
            ConsoleHelper.StartSettings("Минимальное из трёх чисел");
            Console.Write("Введите первое число: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Введите третье число: ");
            int c = int.Parse(Console.ReadLine());
            int minimum = GetMinimum(a, b, c);
            Console.WriteLine($"Из чисел {a}, {b} и {c} минимальное: {minimum}");
            ConsoleHelper.Pause();
        }

        static int GetMinimum(int a, int b, int c)
        {
            int min = a;

            if (b < min)
            {
                min = b;
            }

            if (c < min)
            {
                min = c;
            }

            return min;
        }

        #endregion

    }

}
