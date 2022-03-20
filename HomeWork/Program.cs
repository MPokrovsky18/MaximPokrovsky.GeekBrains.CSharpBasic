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
            //Console.WriteLine("Программа завершена.");
            Task1("Комплексные числа");
            ConsoleHelper.Pause();
        }

        #region Menu

        static void ShowMenu()
        {
            string nameTask1 = "";
            string nameTask2 = "";
            string nameTask3 = "";

            bool isExecute = true;

            while (isExecute)
            {
                ConsoleHelper.StartSettings("Меню");
                Console.WriteLine($"1. {nameTask1}\n2. {nameTask2}\n3. {nameTask3}\n\tДля выхода введите 0");
                Console.Write("Введите номер программы: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
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
            а)  Дописать структуру Complex, добавив метод вычитания комплексных чисел.
                Продемонстрировать работу структуры.
            б)  Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.
            в) Добавить диалог с использованием switch демонстрирующий работу класса.
         */

        static void Task1(string taskName)
        {
            ConsoleHelper.StartSettings(taskName);
            Complex x, y;
            Random random = new Random();
            x.re = random.Next(1, 11);
            x.im = random.Next(1, 11);
            y.re = random.Next(1, 11);
            y.im = random.Next(1, 11);
            Console.WriteLine("Первое комплексное число: " + x.ToString());
            Console.WriteLine("Второе комплексное число: " + y.ToString());
            Console.WriteLine("Сумма: {0}", x.Plus(y).ToString());
            Console.WriteLine("Разность: {0}", x.Minus(y).ToString());
            Console.WriteLine("Произведение: {0}", x.Multi(y).ToString());
            Console.WriteLine("Частное: {0}", x.Divide(y).ToString());
        }

        #endregion

    }

    public struct Complex
    {
        public double im;
        public double re;

        public Complex Plus(Complex x)
        {
            Complex y;
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
        }

        public Complex Multi(Complex x)
        {
            Complex y;
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
        }

        public Complex Minus(Complex x)
        {
            Complex y;
            y.im = im - x.im;
            y.re = re - x.re;
            return y;
        }

        public Complex Divide(Complex x)
        {
            Complex y;
            double denominator = Math.Pow(x.re, 2) + Math.Pow(x.im, 2);
            y.im = (x.re * im - re * x.im) / denominator;
            y.re = (re * x.re + im * x.im) / denominator;
            return y;
        }

        public string ToString()
        {
            return (im < 0) ? re + " - " + Math.Abs(im) + "i" : re + " + " + im + "i";
        }
    }

}
