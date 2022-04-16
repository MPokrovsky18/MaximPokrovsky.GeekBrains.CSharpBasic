using System;
using System.Reflection;
using MP.Utils;

namespace HomeWork
{
    //author: Maxim Pokrovsky
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.StartSettings("Начало программы");
            //ShowMenu();
            //Console.Clear();
            Task1("Рефлексируем");
            Console.WriteLine("Программа завершена.");
            ConsoleHelper.Pause();
        }

        #region Menu

        static void ShowMenu()
        {
            string nameTask1 = "";
            string nameTask2 = "";
            bool isExecute = true;

            while (isExecute)
            {
                ConsoleHelper.StartSettings("Меню");
                Console.WriteLine($"1. {nameTask1}\n2. {nameTask2}\n\tДля выхода введите 0");
                Console.Write("Введите номер программы: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        break;
                    case "2":
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
         
                С помощью рефлексии выведите все свойства структуры DateTime.
         
         */

        static void Task1(string taskName)
        {
            ConsoleHelper.StartSettings(taskName);
            Type dtType = typeof(DateTime);

            Console.WriteLine($"Свойства структуры {dtType.Name}:");

            foreach(PropertyInfo property in dtType.GetProperties())
            {
                Console.WriteLine($" - {property.Name};");
            }

            Console.WriteLine("===============================");
        }

        #endregion
    }
}
