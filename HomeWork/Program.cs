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
            ConsoleHelper.StartSettings("Начало программы");
            ShowMenu();
            Console.Clear();
            Console.WriteLine("Программа завершена.");
            ConsoleHelper.Pause();
        }

        #region Menu

        static void ShowMenu()
        {
            string nameTask1 = "Таблицы функций";
            string nameTask2 = "Минимум функции";


            bool isExecute = true;

            while (isExecute)
            {
                ConsoleHelper.StartSettings("Меню");
                Console.WriteLine($"1. {nameTask1}\n2. {nameTask2}\n\tДля выхода введите 0");
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
            ConsoleHelper.StartSettings(taskName);
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

        #region Task 02

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
            string fileName = "data.bin";
            Func[] funcs =
            {
                x => Math.Sin(x),
                x => Math.Cos(x),
                x => Math.Log(x),
                x => Math.Pow(x, 2),
                x => Math.Pow(x, 3)
            };
            string[] menuItems =
            {
                "1. Sin(x)",
                "2. Cos(x)",
                "3. Log(x)",
                "4. x^2",
                "5. x^3"
            };
            Console.WriteLine("Выберите функцию:");

            foreach (string item in menuItems)
            {
                Console.WriteLine(item);
            }

            Console.Write("Ввод: ");

            if (int.TryParse(Console.ReadLine(), out int userInput) && userInput > 0 && userInput <= menuItems.Length)
            {
                Console.WriteLine("================================");
                Console.WriteLine("Определение отрезка для функции");

                try
                {
                    Console.Write("От: ");
                    double a = double.Parse(Console.ReadLine());
                    Console.Write("До: ");
                    double b = double.Parse(Console.ReadLine());
                    SaveFunc(funcs[userInput - 1], fileName, a, b, 1);
                    double[] numbers = Load(fileName, out double min);

                    foreach (double d in numbers)
                    {
                        Console.Write($"{d}|");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Минимум функции: " + min);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }
        }

        public static double F(double x) => x * x - 50 * x + 10;

        public delegate double Func(double x);

        public static void SaveFunc(Func f, string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;

            while (x <= b)
            {
                bw.Write(f(x));
                x += h;
            }

            bw.Close();
            fs.Close();
        }

        public static double[] Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            min = double.MaxValue;
            double[] values = new double[fs.Length / sizeof(double)];

            for (int i = 0; i < values.Length; i++)
            {
                values[i] = bw.ReadDouble();

                if (values[i] < min)
                {
                    min = values[i];
                }
            }

            bw.Close();
            fs.Close();
            return values;
        }

        #endregion
    }
}
