using System;
using System.IO;
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
            string nameTask2 = "Статический класс для работы с массивом";
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
                        Task2(nameTask2);
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

        #region Task 02

        /*
         
            Реализуйте задачу 1 в виде статического класса StaticClass;
                а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
                б) Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;
                в)*Добавьте обработку ситуации отсутствия файла на диске.
         
         */

        static void Task2(string taskName)
        {
            ConsoleHelper.StartSettings(taskName);
            Random random = new Random();
            int min = -10000;
            int max = 10000;
            uint lenght = 20;
            int[] array = StaticClass.CreateAndFillArray(lenght, min, max);
            StaticClass.PrintArray(array, $"Создан массив {nameof(array)}:");
            int divider = 3;
            int countPair = StaticClass.GetCountPair(array, divider);
            Console.WriteLine($"\nКоличество пар, в которых только одно число делится на {divider}\nОтвет: {countPair}");
            int[] newArr = StaticClass.CreateAndFillArray(10);
            StaticClass.PrintArray(newArr, $"Создан массив {nameof(newArr)}: ");
            string fileName = "data.txt";
            Console.WriteLine("Запишем массив в файл => " + fileName);
            StaticClass.SetArrayToFile(newArr, fileName);
            StaticClass.PrintArray(StaticClass.GetArrayFromFile(fileName), $"В файле {fileName} записан массив:");
            Console.WriteLine($"Попробуем записать в файл {fileName} массив {nameof(array)}.");
            StaticClass.SetArrayToFile(array, fileName);
            StaticClass.PrintArray(StaticClass.GetArrayFromFile(fileName), $"В файле {fileName} записан следующий массив:");
        }

        #endregion
    }

    internal static class StaticClass
    {
        public static int[] CreateAndFillArray(uint length, int min = 0, int max = 100)
        {
            Random random = new Random();
            int[] array = new int[length];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(min, max + 1);
            }

            return array;
        }

        public static void PrintArray(int[] array)
        {
            if (array != null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write("|" + array[i]);
                }

                Console.WriteLine("|");
            }
        }

        public static void PrintArray(int[] array, string message)
        {
            if (array != null)
            {
                Console.WriteLine(message);
                PrintArray(array);
            }
        }

        public static int GetCountPair(int[] array, int divider)
        {
            int count = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] % divider == 0 ^ array[i + 1] % divider == 0)
                {
                    count++;
                }
            }

            return count;
        }

        public static int[] GetArrayFromFile(string path)
        {
            if (File.Exists(path) == false || File.ReadAllLines(path).Length == 0)
            {
                return null;
            }

            StreamReader sr = new StreamReader(path);

            try
            {
                int lenght = int.Parse(sr.ReadLine());
                int[] array = new int[lenght];

                for (int i = 0; i < lenght; i++)
                {
                    array[i] = int.Parse(sr.ReadLine());
                }

                sr.Close();
                return array;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            return null;
        }

        public static void SetArrayToFile(int[] array, string path)
        {
            if (array == null)
            {
                Console.WriteLine("Массив равен null");
                return;
            }

            if (File.Exists(path))
            {
                if (File.ReadAllLines(path).Length > 0)
                {
                    Console.Write("Файл не пуст. Перезаписать? (y/n): ");

                    if (Console.ReadLine().ToLower() != "y")
                    {
                        return;
                    }
                }
            }

            File.Create(path).Close();
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(array.Length);

            for (int i = 0; i < array.Length; i++)
            {
                sw.WriteLine(array[i]);
            }

            sw.Close();
        }
    }
}
