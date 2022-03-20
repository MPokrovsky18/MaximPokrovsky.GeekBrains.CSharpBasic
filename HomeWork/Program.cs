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
            ComplexSt x, y;
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

    public struct ComplexSt
    {
        public double im;
        public double re;

        public ComplexSt Plus(ComplexSt x)
        {
            ComplexSt y;
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
        }

        public ComplexSt Multi(ComplexSt x)
        {
            ComplexSt y;
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
        }

        public ComplexSt Minus(ComplexSt x)
        {
            ComplexSt y;
            y.im = im - x.im;
            y.re = re - x.re;
            return y;
        }

        public ComplexSt Divide(ComplexSt x)
        {
            ComplexSt y;
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

    public class ComplexCl
    {
        private double _im;
        private double _re;

        public double Im
        {
            get
            {
                return _im;
            }
            set
            {
                if (value != 0)
                {
                    _im = value;
                }
            }
        }
        public double Re
        {
            get
            {
                return _re;
            }
            set
            {
                _re = value;
            }
        }

        public ComplexCl()
        {
            _im = 0;
            _re = 0;
        }

        public ComplexCl(double im, double re)
        {
            _im = im;
            _re = re;
        }

        public ComplexCl Plus(ComplexCl x2)
        {
            double im = x2.Im + _im;
            double re = x2.Re + _re;
            return new ComplexCl(im, re);
        }


        public string ToString()
        {
            return _re + "+" + _im + "i";
        }
    }


}
