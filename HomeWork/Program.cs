using System;
using MP.Utils;


namespace HomeWork
{
    //author: Maxim Pokrovsky
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.StartSettings("Начало программы");
            Console.WriteLine("Добро пожаловать! Для продолжения необходимо выполнить авторизацю.");
            ConsoleHelper.Pause();

            if (CheckAuthorization())
            {
                ShowMenu();
            }

            Console.Clear();
            Console.WriteLine("Программа завершена.");
            ConsoleHelper.Pause();
        }

        #region Menu

        static void ShowMenu()
        {
            string nameTask1 = "Минимальное из трёх чисел";
            string nameTask2 = "Подсчет количества цифр";
            string nameTask3 = "Cумма нечетных положительных чисел";
            string nameTask4 = "Авторизация";
            string nameTask5 = "Индекс массы тела";
            string nameTask6 = "\"Хорошие\" числа";
            bool isExecute = true;

            while (isExecute)
            {
                ConsoleHelper.StartSettings("Меню");
                Console.WriteLine($"1. {nameTask1}\n2. {nameTask2}\n3. {nameTask3}\n4. {nameTask4}\n5. {nameTask5}\n6. {nameTask6}\n\tДля выхода введите 0");
                Console.Write("Введите номер программы: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Task1(nameTask1);
                        break;
                    case "2":
                        Task2(nameTask2);
                        break;
                    case "3":
                        Task3(nameTask3);
                        break;
                    case "4":
                        Task4(nameTask4);
                        break;
                    case "5":
                        Task5(nameTask5);
                        break;
                    case "6":
                        Task6(nameTask6);
                        break;
                    case "0":
                        isExecute = false;
                        Console.WriteLine("Выполнен выход из меню.");
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод.");
                        break;
                }

                ConsoleHelper.Pause();
            }
        }

        #endregion

        #region Task 01

        /*
                Написать метод, возвращающий минимальное из трёх чисел. 
         */

        static void Task1(string taskName)
        {
            ConsoleHelper.StartSettings(taskName);
            Console.Write("Введите первое число: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Введите третье число: ");
            int c = int.Parse(Console.ReadLine());
            int minimum = GetMinimum(a, b, c);
            Console.WriteLine($"Из чисел {a}, {b} и {c} минимальное: {minimum}");
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

        static void Task2(string taskName)
        {
            ConsoleHelper.StartSettings(taskName);
            Console.Write("Введите число: ");
            int number = int.Parse(Console.ReadLine());
            int count = GetNumberOfDigits(number);
            Console.WriteLine($"В числе {number} количество цифр равно {count}.");
        }

        static int GetNumberOfDigits(long number)
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

        #endregion

        #region Task 03

        /*
                С клавиатуры вводятся числа, пока не будет введен 0. 
                Подсчитать сумму всех нечетных положительных чисел.
         */

        static void Task3(string taskName)
        {
            ConsoleHelper.StartSettings(taskName);
            Console.WriteLine("Вводите числа. Чтобы прервать ввод и подсчитать сумму всех положительных нечетных чисел - введите 0.");
            Console.WriteLine("================================");
            int sum = GetSumOddNumbers();
            Console.WriteLine("================================");
            Console.WriteLine("Сумма положительных нечетных чисел равна " + sum);
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

        static void Task4(string taskName)
        {
            ConsoleHelper.StartSettings(taskName);

            if (CheckAuthorization() == true)
            {
                Console.WriteLine("Доступ к программе открыт.");
            }
            else
            {
                Console.WriteLine("Доступ к программе закрыт.");
            }
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

        #region Task 05

        /*
                а) Написать программу, которая запрашивает массу и рост человека, 
                    вычисляет его индекс массы и сообщает, 
                    нужно ли человеку похудеть, набрать вес или всё в норме.
                б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
         */

        static void Task5(string taskName)
        {
            ConsoleHelper.StartSettings(taskName);
            double lowerBorderNormalBMI = 18.5;
            double upperBorderNormalBMI = 25;
            Console.Write("Введите Ваш вес(кг): ");
            double mass = double.Parse(Console.ReadLine());
            Console.Write("Введите Ваш рост(см): ");
            double hight = double.Parse(Console.ReadLine()) / 100;
            Console.WriteLine("===========================");
            ShowBMIInfo(mass, hight, lowerBorderNormalBMI, upperBorderNormalBMI);
        }

        static void ShowBMIInfo(double mass, double hight, double lowerBorderNormalBMI, double upperBorderNormalBMI)
        {
            double bodyMassIndex = GetBodyMassIndex(mass, hight);
            double targetBodyMassIndex = GetTargetBodyMassIndex(bodyMassIndex, lowerBorderNormalBMI, upperBorderNormalBMI);
            string info = $"Индекс массы Вашего тела - {bodyMassIndex:F2}.";

            if (targetBodyMassIndex > 0)
            {
                info += "\nДо нормы Вам необходимо ";
                double differenceWeight = GetDifferenceWeight(mass, hight, targetBodyMassIndex);
                info += (differenceWeight < 0) ? "набрать " : "сбросить ";
                info += $"{Math.Abs(differenceWeight):F1} кг.";
            }
            else
            {
                info += "\nВаш вес в пределах нормы.";
            }

            Console.WriteLine(info);
        }

        static double GetBodyMassIndex(double mass, double hight)
        {
            return mass / (hight * hight);
        }

        static double GetTargetBodyMassIndex(double currentBMI, double lowerBorder, double upperBorder)
        {
            if (currentBMI < lowerBorder)
            {
                return lowerBorder;
            }
            else if (currentBMI > upperBorder)
            {
                return upperBorder;
            }

            return 0;
        }

        static double GetDifferenceWeight(double currentWeight, double hight, double targetBMI)
        {
            return currentWeight - (targetBMI * hight * hight);
        }

        #endregion

        #region Task 06

        /*
            Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000. 
            «Хорошим» называется число, которое делится на сумму своих цифр. 
            Реализовать подсчёт времени выполнения программы, используя структуру DateTime.
         */

        static void Task6(string taskName)
        {
            ConsoleHelper.StartSettings(taskName);
            int startNumber = 1;
            int endNumber = 1_000_000_000;
            int count = 0;
            DateTime start = DateTime.Now;

            for (int i = startNumber; i <= endNumber; i++)
            {
                if (CheckIsGoodNumber(i))
                {
                    count++;
                }
            }

            DateTime end = DateTime.Now;
            Console.WriteLine($"В диапозоне от {startNumber} до {endNumber} \"хороших чисел\": {count} шт.");
            Console.WriteLine($"Время, затраченное на выполнение программы: {(end - start)}");
        }

        static bool CheckIsGoodNumber(long number)
        {
            return number % GetNumberOfDigits(number) == 0;
        }

        #endregion
    }
}
