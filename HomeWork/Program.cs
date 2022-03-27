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
            Console.WriteLine("Программа завершена.");
            ConsoleHelper.Pause();
        }

        #region Menu

        static void ShowMenu()
        {
            string nameTask1 = "Пары в массиве";
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
         
                Дан целочисленный массив из 20 элементов. 
                Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно. 
                Заполнить случайными числами. 

                Написать программу, позволяющую найти и вывести количество пар элементов массива, 
                в которых только одно число делится на 3. 
                В данной задаче под парой подразумевается два подряд идущих элемента массива.
                Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2. 

         */

        static void Task1(string taskName)
        {
            ConsoleHelper.StartSettings(taskName);
            Random random = new Random();
            int min = -10000;
            int max = 10000;
            int lenght = 20;
            int[] array = new int[lenght];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(min, max + 1);
            }

            Console.WriteLine("Создан массив:");
            ShowArray(array);
            int count = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] % 3 == 0 ^ array[i + 1] % 3 == 0)
                {
                    count++;
                }
            }

            Console.WriteLine($"\nКоличество пар, в которых только одно число делится на 3\nОтвет: {count}");
        }

        static void ShowArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("|" + array[i]);
            }

            Console.WriteLine("|");
        }

        #endregion

    }
}
