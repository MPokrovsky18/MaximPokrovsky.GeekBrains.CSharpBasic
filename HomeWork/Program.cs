﻿using System;
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
            ConsoleHelper.Pause();
        }

        #region Menu

        static void ShowMenu()
        {
            string nameTask1 = "Комплексные числа";
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
                        Task1(nameTask1);
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
            ShowResultsOfOperations(xSt, ySt);
            Console.WriteLine("================================");
            ComplexCl xCl = new ComplexCl();
            ComplexCl yCl = new ComplexCl();
            xCl.Re = re1;
            xCl.Im = im1;
            yCl.Re = re2;
            yCl.Im = im2;
            ShowResultsOfOperations(xCl, yCl);
            ConsoleHelper.Pause();
            bool isRepit;

            do
            {
                Console.Clear();
                Console.WriteLine("Первое комплексное число_____________");
                ComplexCl x = GetComplexNumber();
                Console.WriteLine("Второе комплексное число_____________");
                ComplexCl y = GetComplexNumber();
                ExecuteOperations(x, y);
                Console.Clear();
                Console.Write("Ввести новые числа? (y/n): ");
                isRepit = Console.ReadLine().ToLower() == "y" ? true : false;
            }
            while (isRepit);

            Console.WriteLine("Приложение \"{0}\" завершено.", taskName);
        }

        static void ExecuteOperations(ComplexCl x, ComplexCl y)
        {
            bool isCompleted = false;

            while (isCompleted == false)
            {
                Console.Clear();
                Console.WriteLine("Комплексных числа: " + x.ToString() + " и " + y.ToString());
                Console.WriteLine("Выберите операцию: ");
                Console.Write("1. Сложение\n2. Вычетание\n3. Умножение\n4. Деление\n0. Завершить операции\nВведите номер операции: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Сумма чисел: {0}", x.Plus(y).ToString());
                        break;
                    case "2":
                        Console.WriteLine("Разность чисел: {0}", x.Minus(y).ToString());
                        break;
                    case "3":
                        Console.WriteLine("Произведение чисел: {0}", x.Multi(y).ToString());
                        break;
                    case "4":
                        Console.WriteLine("Частное чисел: {0}", x.Divide(y).ToString());
                        break;
                    case "0":
                        isCompleted = true;
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод!");
                        break;
                }

                ConsoleHelper.Pause();
            }
        }

        static ComplexCl GetComplexNumber()
        {
            double re, im;
            re = GetCorrectNumber(nameof(re));
            im = GetCorrectNumber(nameof(im));
            return new ComplexCl(im, re);
        }

        static double GetCorrectNumber(string name)
        {
            double number;
            bool isCorrectInput;

            do
            {
                Console.Write($"Введите {name}: ");
                isCorrectInput = double.TryParse(Console.ReadLine(), out number);
            }
            while (isCorrectInput == false);

            return number;
        }

        static void ShowResultsOfOperations(ComplexSt x, ComplexSt y)
        {
            Console.WriteLine("Структуры ComplexSt\n");
            Console.WriteLine("Первое комплексное число: " + x.ToString());
            Console.WriteLine("Второе комплексное число: " + y.ToString());
            Console.WriteLine("Сумма: {0}", x.Plus(y).ToString());
            Console.WriteLine("Разность: {0}", x.Minus(y).ToString());
            Console.WriteLine("Произведение: {0}", x.Multi(y).ToString());
            Console.WriteLine("Частное: {0}", x.Divide(y).ToString());
        }

        static void ShowResultsOfOperations(ComplexCl x, ComplexCl y)
        {
            Console.WriteLine("Экземпляры класса ComplexCl\n");
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
