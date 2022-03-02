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
    }
}
