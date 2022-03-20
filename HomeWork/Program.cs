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
            Random random = new Random();

            double re1 = random.Next(1, 11);
            double re2 = random.Next(1, 11);
            double im1 = random.Next(1, 11);
            double im2 = random.Next(1, 11);

            ComplexSt xSt, ySt;
            xSt.re = re1;
            xSt.im = im1;
            ySt.re = re2;
            ySt.im = im2;
            Console.WriteLine("Структуры ComplexSt\n");
            Console.WriteLine("Первое комплексное число: " + xSt.ToString());
            Console.WriteLine("Второе комплексное число: " + ySt.ToString());
            Console.WriteLine("Сумма: {0}", xSt.Plus(ySt).ToString());
            Console.WriteLine("Разность: {0}", xSt.Minus(ySt).ToString());
            Console.WriteLine("Произведение: {0}", xSt.Multi(ySt).ToString());
            Console.WriteLine("Частное: {0}", xSt.Divide(ySt).ToString());
            Console.WriteLine("================================");
            Console.WriteLine("Экземпляры класса ComplexCl\n");
            ComplexCl xCl = new ComplexCl();
            ComplexCl yCl = new ComplexCl();
            xCl.Re = re1;
            xCl.Im = im1;
            yCl.Re = re2;
            yCl.Im = im2;
            Console.WriteLine("Первое комплексное число: " + xCl.ToString());
            Console.WriteLine("Второе комплексное число: " + yCl.ToString());
            Console.WriteLine("Сумма: {0}", xCl.Plus(yCl).ToString());
            Console.WriteLine("Разность: {0}", xCl.Minus(yCl).ToString());
            Console.WriteLine("Произведение: {0}", xCl.Multi(yCl).ToString());
            Console.WriteLine("Частное: {0}", xCl.Divide(yCl).ToString());
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
            if (im == 0 && re == 0)
            {
                return "0";
            }
            if (im == 0)
            {
                return $"{re}";
            }
            else if (re == 0)
            {
                return im + "i";
            }
            else
            {
                return (im < 0) ? re + " - " + Math.Abs(im) + "i" : re + " + " + im + "i";
            }
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

        public ComplexCl Plus(ComplexCl x)
        {
            double im = x.Im + _im;
            double re = x.Re + _re;
            return new ComplexCl(im, re);
        }

        public ComplexCl Minus(ComplexCl x)
        {
            double im = _im - x.Im;
            double re = _re - x.Re;
            return new ComplexCl(im, re);
        }

        public ComplexCl Multi(ComplexCl x)
        {
            double im = _re * x.Im + _im * x.Re;
            double re = _re * x.Re - _im * x.Im;
            return new ComplexCl(im, re);
        }

        public ComplexCl Divide(ComplexCl x)
        {
            double denominator = Math.Pow(x.Re, 2) + Math.Pow(x.Im, 2);
            double im = (x.Re * _im - _re * x.Im) / denominator;
            double re = (_re * x.Re + _im * x.Im) / denominator;
            return new ComplexCl(im, re);
        }

        public string ToString()
        {
            if (_im == 0 && _re == 0)
            {
                return "0";
            }
            if (_im == 0)
            {
                return $"{_re}";
            }
            else if (_re == 0)
            {
                return _im + "i";
            }
            else
            {
                return (_im < 0) ? _re + " - " + Math.Abs(_im) + "i" : _re + " + " + _im + "i";
            }
        }
    }
}
