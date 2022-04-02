using System;
using System.Text;
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
            Task2("Класс Message");
            Console.WriteLine("Программа завершена.");
            ConsoleHelper.Pause();
        }

        #region Menu

        static void ShowMenu()
        {
            string nameTask1 = "Проверка логина";
            string nameTask2 = "Класс Message";
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
                        Task2(nameTask2);
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

        #region Task 02

        /*
         
                 Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
                    а) Вывести только те слова сообщения, которые содержат не более n букв.
                    б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
                    в) Найти самое длинное слово сообщения.
                    г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
         
         */

        static void Task2(string taskName)
        {
            string s = @"Сосны обступали тропу плотно, и, 
хотя истыканное их верхушками небо светилось голубым, в лесу было сумрачно. 
По тропинке вперёд бежали муравьи, большие, красные, по своим каким-то муравьиным делам.
– Смотри, пап, им с нами по пути! – сказала Таня. – Наверное, они тоже на пляж собрались!
Папа улыбнулся ей сверху.";

            Console.WriteLine("Получен текст:");
            Console.WriteLine(s);
            Console.WriteLine("----------------------------------------------------");
            s = Message.DeleteWords(s, 'е');
            Console.WriteLine("В тексте удалили слова, которые заканчиваются на букву Е.");
            Console.WriteLine(s);
            Console.WriteLine("----------------------------------------------------");
            Console.Write("Самое длинное слово в тексте: ");
            Console.WriteLine(Message.GetLongestWord(s));
            Console.WriteLine("Самые длинные слова в тексте:");
            Console.WriteLine(Message.GetLongestWordsList(s));

        }

        #endregion
    }

    public static class Message
    {
        private static string[] _separators = { ",", ".", "!", "?", ";", ":", " ", "-" };

        public static void PrintWords(string message, uint maxLength)
        {
            string[] words = message.Split(_separators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length <= maxLength)
                {
                    Console.WriteLine(words[i]);
                }
            }
        }

        public static string DeleteWords(string message, char endSymbol)
        {
            return new Regex($@"\b\w*{endSymbol}\b", RegexOptions.IgnoreCase).Replace(message, "");
        }

        public static string GetLongestWord(string message)
        {
            string[] words = message.Split(_separators, StringSplitOptions.RemoveEmptyEntries);
            int indexMaxWord = 0;

            for (int i = 1; i < words.Length; i++)
            {
                if (words[i].Length > words[indexMaxWord].Length)
                {
                    indexMaxWord = i;
                }
            }

            return words[indexMaxWord];
        }

        public static string GetLongestWordsList(string message)
        {
            StringBuilder longestWords = new StringBuilder();
            Regex regex = new Regex(@"\w{8,}", RegexOptions.IgnoreCase);

            foreach (Match match in regex.Matches(message))
            {
                longestWords.AppendLine(match.ToString() + ";");
            }

            return longestWords.ToString();
        }
    }
}
