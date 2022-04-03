using System;
using System.IO;
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
            Task2("Минимум функции");
            Console.WriteLine("Программа завершена.");
            ConsoleHelper.Pause();
        }

        #region Menu

        static void ShowMenu()
        {
            string nameTask1 = "Таблицы функций";
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
                        Task1(nameTask1);
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
            Console.WriteLine("Таблица функции 3*sin(x):");
            Table((a, x) => a * Math.Sin(x), 3, -2, 2);
            Console.WriteLine("Таблица функции 4*x^2:");
            Table((a, x) => a * x * x, 4, 0, 3);

        }

        public delegate double Fun(double a, double x);

        public static void Table(Fun F, double a, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");

            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(a, x));
                x += 1;
            }

            Console.WriteLine("---------------------");
        }

        #endregion

        #region

        /*
         
                    Модифицировать программу нахождения минимума функции так, 
                        чтобы можно было передавать функцию в виде делегата.

                    а) Сделать меню с различными функциями и представить пользователю выбор, 
                            для какой функции и на каком отрезке находить минимум. 
                    И спользовать массив (или список) делегатов, в котором хранятся различные функции.

                    б) *Переделать функцию Load, чтобы она возвращала массив считанных значений. 
                            Пусть она возвращает минимум через параметр (с использованием модификатора out).
         
         */

        static void Task2(string taskName)
        {
            ConsoleHelper.StartSettings(taskName);
            SaveFunc("data.bin", -100, 100, 0.5);
            Console.WriteLine(Load("data.bin"));
            Console.ReadKey();
        }

        public static double F(double x) => x * x - 50 * x + 10;

        public static void SaveFunc(string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;

            while (x <= b)
            {
                bw.Write(F(x));
                x += h;
            }

            bw.Close();
            fs.Close();
        }

        public static double Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double d;

            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                d = bw.ReadDouble();

                if (d < min)
                {
                    min = d;
                }
            }

            bw.Close();
            fs.Close();
            return min;
        }

        #endregion
    }
}
