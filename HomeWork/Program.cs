using System;
using MP.Utils;


namespace HomeWork
{
    //author: Maxim Pokrovsky
    internal class Program
    {
        static void Main(string[] args)
        {
            //ConsoleHelper.StartSettings("Начало программы");
            //ShowMenu();
            //Console.Clear();
            Task1("Таблицы функций");
            Console.WriteLine("Программа завершена.");
            ConsoleHelper.Pause();
        }

        #region Menu

        static void ShowMenu()
        {
            string nameTask1 = "";
            string nameTask2 = "";
            string nameTask3 = "";
            string nameTask4 = "";


            bool isExecute = true;

            while (isExecute)
            {
                ConsoleHelper.StartSettings("Меню");
                Console.WriteLine($"1. {nameTask1}\n2. {nameTask2}\n3. {nameTask3}\n4. {nameTask4}\n\tДля выхода введите 0");
                Console.Write("Введите номер программы: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
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
         
                  Изменить программу вывода таблицы функции так, 
                чтобы можно было передавать функции типа double (double, double). 
                Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).

         */

        static void Task1(string taskName)
        {
            Console.WriteLine("Таблица функции MyFunc:");
            Table(MyFunc, -2, 2);
            Console.WriteLine("Таблица функции Sin:");
            Table(Math.Sin, -2, 2);
            Console.WriteLine("Таблица функции x^2:");
            Table(x => x * x, 0, 3);

        }

        public delegate double Fun(double x);

        public static void Table(Fun F, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");

            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x));
                x += 1;
            }

            Console.WriteLine("---------------------");
        }

        public static double MyFunc(double x) => x * x * x;

        #endregion

    }
}
