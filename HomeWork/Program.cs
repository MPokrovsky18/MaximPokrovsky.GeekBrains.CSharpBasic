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
            ShowMenu();
            Console.Clear();
            Console.WriteLine("Программа завершена.");
            ConsoleHelper.Pause();
        }

        #region Menu

        static void ShowMenu()
        {
            string nameTask1 = "Комплексные числа";
            string nameTask2 = "Сумма нечетных чисел";
            string nameTask3 = "Дроби";

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
                        Task2(nameTask2);
                        break;
                    case "3":
                        Task3(nameTask3);
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
                Console.WriteLine("Комплексных числа: " + x + " и " + y);
                Console.WriteLine("Выберите операцию: ");
                Console.Write("1. Сложение\n2. Вычетание\n3. Умножение\n4. Деление\n0. Завершить операции\nВведите номер операции: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Сумма чисел: {0}", x.Plus(y));
                        break;
                    case "2":
                        Console.WriteLine("Разность чисел: {0}", x.Minus(y));
                        break;
                    case "3":
                        Console.WriteLine("Произведение чисел: {0}", x.Multi(y));
                        break;
                    case "4":
                        Console.WriteLine("Частное чисел: {0}", x.Divide(y));
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
            Console.WriteLine("Первое комплексное число: " + x);
            Console.WriteLine("Второе комплексное число: " + y);
            Console.WriteLine("Сумма: {0}", x.Plus(y));
            Console.WriteLine("Разность: {0}", x.Minus(y));
            Console.WriteLine("Произведение: {0}", x.Multi(y));
            Console.WriteLine("Частное: {0}", x.Divide(y));
        }

        static void ShowResultsOfOperations(ComplexCl x, ComplexCl y)
        {
            Console.WriteLine("Экземпляры класса ComplexCl\n");
            Console.WriteLine("Первое комплексное число: " + x);
            Console.WriteLine("Второе комплексное число: " + y);
            Console.WriteLine("Сумма: {0}", x.Plus(y));
            Console.WriteLine("Разность: {0}", x.Minus(y));
            Console.WriteLine("Произведение: {0}", x.Multi(y));
            Console.WriteLine("Частное: {0}", x.Divide(y));
        }

        #endregion

        #region Task 02

        /*
            а)  С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке).
                Требуется подсчитать сумму всех нечётных положительных чисел. 
                Сами числа и сумму вывести на экран, используя tryParse.
         */

        static void Task2(string taskName)
        {
            ConsoleHelper.StartSettings(taskName);
            Console.WriteLine("Старт программы. Для завершения введите 0.");
            int sum = 0;
            bool isCompleted = false;

            while (isCompleted == false)
            {
                Console.Write("Введите число: ");

                if (int.TryParse(Console.ReadLine(), out int userInput))
                {
                    if (MathHelper.CheckOddNumber(userInput) && userInput > 0)
                    {
                        sum += userInput;
                    }
                    else if (userInput == 0)
                    {
                        isCompleted = true;
                        Console.WriteLine("Ввод окончен.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод!");
                }
            }

            Console.WriteLine("Сумма нечетных положительных чисел: " + sum);
        }

        #endregion

        #region Task 03

        /*
         
        *   Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. 
            Предусмотреть методы сложения, вычитания, умножения и деления дробей. Написать программу, 
            демонстрирующую все разработанные элементы класса.

            Добавить свойства типа int для доступа к числителю и знаменателю;
            Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа; 

        **  Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0"); 
        
        *** Добавить упрощение дробей.
         
         */

        static void Task3(string taskName)
        {
            ConsoleHelper.StartSettings(taskName);
            QNumber n1 = new QNumber(3, 4);
            QNumber n2 = new QNumber(5, 7);
            QNumber n3 = new QNumber(6, 8);
            Console.WriteLine("Первое рациональное число: " + n1);
            Console.WriteLine("В десятичном виде: " + n1.Decimal);
            Console.WriteLine("Второе рациональное число: " + n2);
            Console.WriteLine("В десятичном виде: " + n2.Decimal);
            Console.WriteLine("Сумма: {0}", n1.Plus(n2));
            Console.WriteLine("Разность: {0}", n1.Minus(n2));
            Console.WriteLine("Произведение: {0}", n1.Multi(n2));
            Console.WriteLine("Частное: {0}", n1.Divide(n2));
            Console.WriteLine("Третье рациональное число: " + n3);
            Console.WriteLine("Попробуем сократить.");
            n3.Simplify();
            Console.WriteLine("Результат сокращения: {0}", n3);
        }

        #endregion
    }

    public class QNumber
    {
        private int _m;
        private int _n;

        public int M
        {
            get
            {
                return _m;
            }
            set
            {
                _m = value;
            }
        }
        public int N
        {
            get
            {
                return _n;
            }
            set
            {
                try
                {
                    if (value == 0)
                    {
                        throw new ArgumentException("Делить на ноль нельзя! Знаменателю будет присвоено значение 1");
                    }

                    _n = value;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                    _n = 1;
                }
            }
        }
        public int IntegerPart
        {
            get
            {
                return _m / _n;
            }
        }
        public QNumber FractionalPart
        {
            get
            {
                if (IntegerPart == 0)
                {
                    return this;
                }

                return new QNumber(Math.Abs(_m - (IntegerPart * _n)), _n);
            }
        }
        public double Decimal
        {
            get
            {
                return (double)_m / _n;
            }
        }

        public QNumber(int m, int n = 1)
        {
            if (n < 0)
            {
                m *= -1;
                n *= -1;
            }

            N = n;
            _m = m;
        }

        public QNumber()
        {
            _m = 1;
            _n = 1;
        }

        public QNumber Plus(QNumber number)
        {
            int commonDenominator = N * number.N;
            int resultNumerator = (M * number.N) + (number.M * N);
            return new QNumber(resultNumerator, commonDenominator);
        }

        public QNumber Plus(int number)
        {
            return Plus(new QNumber(number));
        }

        public QNumber Minus(QNumber number)
        {
            int commonDenominator = N * number.N;
            int resultNumerator = (M * number.N) - (number.M * N);
            return new QNumber(resultNumerator, commonDenominator);
        }

        public QNumber Minus(int number)
        {
            return Minus(new QNumber(number));
        }

        public QNumber Multi(QNumber number)
        {
            return new QNumber(M * number.M, N * number.N);
        }

        public QNumber Multi(int number)
        {
            return Multi(new QNumber(number));
        }

        public QNumber Divide(QNumber number)
        {
            return new QNumber(M * number.N, N * number.M);
        }

        public QNumber Divide(int number)
        {
            return Divide(new QNumber(number));
        }

        public bool Simplify()
        {
            int divisor = MathHelper.GetMaxCommonDivisor(_m, _n);

            if (divisor > 1)
            {
                _m /= divisor;
                _n /= divisor;
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            if (_m == 0)
            {
                return "0";
            }
            else if (_m % _n == 0)
            {
                return $"{_m / _n}";
            }
            else if (_n % 10 == 0)
            {
                return Decimal.ToString();
            }
            else if (IntegerPart != 0)
            {
                return $"{IntegerPart}({FractionalPart})";
            }

            return $"{_m}/{_n}";
        }
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

        public override string ToString()
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

        public override string ToString()
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
