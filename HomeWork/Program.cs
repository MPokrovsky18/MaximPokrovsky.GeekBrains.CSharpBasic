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
    }
}
