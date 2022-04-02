using System;
using System.Text.RegularExpressions;
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
            Task1("Проверка логина");
            Console.WriteLine("Программа завершена.");
            ConsoleHelper.Pause();
        }

        #region Menu

        static void ShowMenu()
        {
            string nameTask1 = "Проверка логина";
            string nameTask2 = "";
            string nameTask3 = "";
            string nameTask4 = "";


            bool isExecute = true;

            while (isExecute)
            {
                ConsoleHelper.StartSettings("Меню");
                Console.WriteLine($"1. {nameTask1}\n2. {nameTask2}\n3. {nameTask3}\n4. {nameTask4}\n\tДля выхода введите 0");
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
                    case "4":
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
         
                Создать программу, которая будет проверять корректность ввода логина. 
                Корректным логином будет строка от 2 до 10 символов, 
                содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
                    а) без использования регулярных выражений;
                    б) **с использованием регулярных выражений.
         
         */

        static void Task1(string taskName)
        {
            ConsoleHelper.StartSettings(taskName);
            bool isCorrectLogin;

            do
            {
                Console.Write("Введите логин: ");
                isCorrectLogin = CheckLoginIsCorrectWithoutRegex(Console.ReadLine());

                if (isCorrectLogin == false)
                {
                    Console.WriteLine("Корректный логин:\n 1) от 2 до 10 символов\n 2) только буквы латинского алфавита или цифры\n 3) цифра не может быть первой\n");
                }
                else
                {
                    Console.WriteLine("Логин введен корректно.");
                }
            }
            while (isCorrectLogin == false);

            Console.WriteLine("==================");
            Console.WriteLine("Проверка логина с использованием регулярных выражений.");

            do
            {
                Console.Write("Введите логин: ");
                isCorrectLogin = CheckLoginIsCorrectWithRegex(Console.ReadLine());

                if (isCorrectLogin == false)
                {
                    Console.WriteLine("Корректный логин:\n 1) от 2 до 10 символов\n 2) только буквы латинского алфавита или цифры\n 3) цифра не может быть первой\n");
                }
                else
                {
                    Console.WriteLine("Логин введен корректно.");
                }
            }
            while (isCorrectLogin == false);

        }

        static bool CheckLoginIsCorrectWithoutRegex(string login)
        {
            if (login.Length < 2 || login.Length > 10)
            {
                return false;
            }

            if (char.IsDigit(login[0]))
            {
                return false;
            }

            foreach (char c in login)
            {
                if (char.IsLetterOrDigit(c) == false || c > 'z')
                {
                    return false;
                }
            }

            return true;
        }

        static bool CheckLoginIsCorrectWithRegex(string login)
        {
            Regex regLogin = new Regex(@"^[A-Za-z]\w{1,9}$", RegexOptions.IgnoreCase);
            return regLogin.IsMatch(login);
        }

        #endregion

    }
}
