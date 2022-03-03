using System;


namespace HomeWork
{
    //author: Maxim Pokrovsky
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
        }

        #region Task 01

        /*
            Написать программу «Анкета». 
        Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). 
        В результате вся информация выводится в одну строчку:
            а) используя  склеивание;
	        б) используя форматированный вывод;
	        в) используя вывод со знаком $.
         */

        static void Task1()
        {
            Console.Title = "Анкета";
            Console.Clear();
            Console.Write("Введите Ваше имя: ");
            string firstName = Console.ReadLine();
            Console.Write("Введите Вашу фамилию: ");
            string lastName = Console.ReadLine();
            Console.Write("Введите Ваш возраст: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Введите Ваш рост(см): ");
            int hight = int.Parse(Console.ReadLine());
            Console.Write("Введите Ваш вес(кг): ");
            double weight = double.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("а) " + firstName + " " + lastName + " - полных лет: " + age + ", рост: " + hight + " см, вес: " + weight + " кг;");
            Console.WriteLine("б) {0} {1} - полных лет: {2}, рост: {3} см, вес: {4} кг;", firstName, lastName, age, hight, weight);
            Console.WriteLine($"в) {firstName} {lastName} - полных лет: {age}, рост: {hight} см, вес: {weight} кг;");
            Console.WriteLine("\nНажмите ENTER для продолжения . . .");
            Console.ReadLine();
        }

        #endregion

        #region Task 02

        /*
            Ввести вес и рост человека. 
        Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); 
        где m — масса тела в килограммах, h — рост в метрах.
         */

        static void Task2()
        {
            Console.Title = "Расчет ИМТ";
            Console.Clear();
            Console.Write("Введите Ваш вес(кг): ");
            double mass = double.Parse(Console.ReadLine());
            Console.Write("Введите Ваш рост(см): ");
            double hight = double.Parse(Console.ReadLine()) / 100;
            double bodyMassIndex = mass / (hight * hight);
            Console.WriteLine($"Индекс массы тела равен {bodyMassIndex:F1}.");
            Console.WriteLine("\nНажмите ENTER для продолжения . . .");
            Console.ReadLine();
        }

        #endregion

        #region Task 03

        /*
            а) Написать программу, которая подсчитывает расстояние между точками
        с координатами x1, y1 и x2,y2 
        по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). 
        Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой);
            б) *Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.
         */

        static void Task3()
        {
            Console.Title = "Расстояние между точками";
            Console.Clear();
            Console.WriteLine("Введите координаты первой точки:");
            Console.Write("x1 - ");
            double x1 = double.Parse(Console.ReadLine());
            Console.Write("y1 - ");
            double y1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите координаты второй точки:");
            Console.Write("x2 - ");
            double x2 = double.Parse(Console.ReadLine());
            Console.Write("y2 - ");
            double y2 = double.Parse(Console.ReadLine());
            double distance = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
            Console.WriteLine("======================================");
            Console.WriteLine($"а) Расстояние между точками А({x1};{y1}) и В({x2};{y2}): {distance:f2}");
            distance = GetDistance(x1, y1, x2, y2);
            Console.WriteLine($"б) Расстояние между точками А({x1};{y1}) и В({x2};{y2}): {distance:f2}");
            Console.WriteLine("\nНажмите ENTER для продолжения . . .");
            Console.ReadLine();
        }

        static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }

        #endregion

        #region Task 04

        /*
            Написать программу обмена значениями двух переменных:
                а) с использованием третьей переменной;
	            б) *без использования третьей переменной.
         */

        static void Task4()
        {
            Console.Title = "Обмен значениями";
            Console.Clear();
            Console.Write("Введите первое число: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int secondNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("До обмена значениями:");
            Console.WriteLine($"\tпервое число - {firstNumber}\n\tвторое число - {secondNumber}");
            Console.WriteLine("Обмен с использованием третьей переменной: ");
            int tempNumber = firstNumber;
            firstNumber = secondNumber;
            secondNumber = tempNumber;
            Console.WriteLine($"\tпервое число - {firstNumber}\n\tвторое число - {secondNumber}");
            Console.WriteLine("Обмен без использования третьей переменной: ");
            firstNumber ^= secondNumber;
            secondNumber ^= firstNumber;
            firstNumber ^= secondNumber;
            Console.WriteLine($"\tпервое число - {firstNumber}\n\tвторое число - {secondNumber}");
            Console.WriteLine("\nНажмите ENTER для продолжения . . .");
            Console.ReadLine();
        }

        #endregion

        #region Task 05

        /*
                а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
                б) *Сделать задание, только вывод организовать в центре экрана.
                в) **Сделать задание б с использованием собственных методов(например, Print(string ms, int x, int y).
        */

        static void Task5()
        {
            Console.Title = "Вывод информации";
            Console.Clear();
            Console.Write("Введите Ваше имя: ");
            string firstName = Console.ReadLine();
            Console.Write("Введите Вашу фамилию: ");
            string lastName = Console.ReadLine();
            Console.Write("Введите Ваш город проживания: ");
            string cityName = Console.ReadLine();
            Console.WriteLine("======================================");
            SubtaskA(firstName, lastName, cityName);
            SubtaskB(firstName, lastName, cityName);
            SubtaskV(firstName, lastName, cityName);
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.WriteLine("\nНажмите ENTER для продолжения . . .");
            Console.ReadLine();
        }

        static void SubtaskA(string firstName, string lastName, string cityName)
        {
            Console.WriteLine($"а) {firstName} {lastName} - город {cityName}.");
        }

        static void SubtaskB(string firstName, string lastName, string cityName)
        {
            string info = $"б) {firstName} {lastName} - город {cityName}.";
            int consoleCentrePointX = Console.WindowWidth / 2;
            int consoleCentrePointY = Console.WindowHeight / 2;
            int startTextPosition = consoleCentrePointX - info.Length / 2;
            Console.SetCursorPosition(startTextPosition, consoleCentrePointY);
            Console.WriteLine(info);
        }

        static void SubtaskV(string firstName, string lastName, string cityName)
        {
            string info = GetInfoText(firstName, lastName, cityName);
            Print(info, 20, 10);
        }

        static string GetInfoText(string firstName, string lastName, string cityName)
        {
            return $"в) {firstName} {lastName} - город {cityName}.";
        }

        static void Print(string message, int cursorPositionX, int cursorPositionY)
        {
            Console.SetCursorPosition(cursorPositionX, cursorPositionY);
            Console.WriteLine(message);
        }

        #endregion
    }
}
