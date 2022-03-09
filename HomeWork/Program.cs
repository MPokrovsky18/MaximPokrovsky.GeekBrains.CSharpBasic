using System;
using MP.Utils;


namespace HomeWork
{
    //author: Maxim Pokrovsky
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            //Task3();
            Task4();
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

        #region Task 02

        /*
                Написать метод подсчета количества цифр числа.
         */

        static void Task2()
        {
            ConsoleHelper.StartSettings("Подсчет количества цифр");
            Console.Write("Введите число: ");
            int number = int.Parse(Console.ReadLine());
            int count = GetNumberOfDigits(number);
            Console.WriteLine($"В числе {number} количество цифр равно {count}.");
            ConsoleHelper.Pause();
        }

        static int GetNumberOfDigits(long number)
        {
            if (number == 0)
            {
                return 1;
            }

            int count = 0;

            while (number > 0)
            {
                number /= 10;
                count++;
            }

            return count;
        }

        #endregion

        #region Task 03

        /*
                С клавиатуры вводятся числа, пока не будет введен 0. 
                Подсчитать сумму всех нечетных положительных чисел.
         */

        static void Task3()
        {
            ConsoleHelper.StartSettings("Cумма нечетных положительных чисел");
            Console.WriteLine("Вводите числа. Чтобы прервать ввод и подсчитать сумму всех положительных нечетных чисел - введите 0.");
            Console.WriteLine("================================");
            int sum = GetSumOddNumbers();
            Console.WriteLine("================================");
            Console.WriteLine("Сумма положительных нечетных чисел равна " + sum);
            ConsoleHelper.Pause();
        }

        static int GetSumOddNumbers()
        {
            int userInput;
            int sum = 0;

            do
            {
                Console.Write("Введите число: ");
                userInput = int.Parse(Console.ReadLine());

                if (userInput > 0 && IsOdd(userInput))
                {
                    sum += userInput;
                }

            }
            while (userInput != 0);

            return sum;
        }

        static bool IsOdd(int number)
        {
            return number % 2 != 0;
        }

        #endregion

        #region Task 04

        /*
                Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. 
            На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). 
            Используя метод проверки логина и пароля, написать программу: 
                пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает. 
            С помощью цикла do while ограничить ввод пароля тремя попытками.
         */

        static void Task4()
        {
            ConsoleHelper.StartSettings("Авторизация");

            if (CheckAuthorization() == true)
            {
                Console.WriteLine("Доступ к программе открыт.");
            }
            else
            {
                Console.WriteLine("Доступ к программе закрыт.");
            }

            ConsoleHelper.Pause();
        }

        static bool CheckAuthorization()
        {
            int attemptsCount = 3;
            bool isCorrectInput = false;
            string userInputLogin;
            string userInputPassword;

            do
            {
                Console.Clear();
                Console.WriteLine($"Попыток авторизоваться: {attemptsCount}");
                Console.WriteLine("======================");
                Console.Write("Введите логин: ");
                userInputLogin = Console.ReadLine();
                Console.Write("Введите пароль: ");
                userInputPassword = Console.ReadLine();
                Console.WriteLine("======================");
                isCorrectInput = VerifyLoginAndPassword(userInputLogin, userInputPassword);

                if (isCorrectInput)
                {
                    Console.WriteLine("Авторизация выполнена успешно!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Неверный логин или пароль.");
                    attemptsCount--;
                    ConsoleHelper.Pause();
                }

            }
            while (attemptsCount > 0);

            Console.Clear();
            Console.WriteLine("Закончились попытки авторизации. Попробуйте позднее.");
            return false;
        }

        static bool VerifyLoginAndPassword(string enteredLogin, string enteredPassword)
        {
            string login = "root";
            string password = "GeekBrains";
            return enteredLogin == login && enteredPassword == password;
        }

        #endregion
    }

}
