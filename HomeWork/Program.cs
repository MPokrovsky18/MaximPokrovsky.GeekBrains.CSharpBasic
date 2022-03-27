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
            ConsoleHelper.StartSettings("Начало программы");
            ShowMenu();
            Console.Clear();
            Console.WriteLine("Программа завершена.");
            ConsoleHelper.Pause();
        }

        #region Menu

        static void ShowMenu()
        {
            string nameTask1 = "Пары в массиве";
            string nameTask2 = "Статический класс для работы с массивом";
            string nameTask3 = "Класс для работы с одномерным массивом";
            string nameTask4 = "Авторизация";


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
                        Task3(nameTask3);
                        break;
                    case "4":
                        Task4(nameTask4);
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

        #region Task 03

        /*
         
            а) Дописать класс для работы с одномерным массивом. 
                    Реализовать конструктор, создающий массив определенного размера 
                        и заполняющий массив числами от начального значения с заданным шагом. .
            Создать свойство Sum, которое возвращает сумму элементов массива, 
                метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива 
                    (старый массив, остается без изменений), 
                метод Multi, умножающий каждый элемент массива на определённое число, 
                свойство MaxCount, возвращающее количество максимальных элементов.
            б)** Создать библиотеку содержащую класс для работы с массивом. 
                    Продемонстрировать работу библиотеки
            в) *** Подсчитать частоту вхождения каждого элемента в массив (коллекция Dictionary<int,int>)
         
         */

        static void Task3(string taskName)
        {
            ConsoleHelper.StartSettings(taskName);
            MyArray arr1, arr2;
            arr1 = new MyArray(20);
            arr2 = new MyArray(20, 5, 3);
            Console.WriteLine($"Созданы массивы: {nameof(arr1)} и {nameof(arr2)}");
            Console.WriteLine();
            Console.WriteLine(nameof(arr1) + ": " + arr1);
            Console.WriteLine(nameof(arr2) + ": " + arr2);
            Console.WriteLine();
            Console.WriteLine($"В {nameof(arr1)} максимальное число {arr1.Max} встречается в количестве: {arr1.MaxCount}");
            Console.WriteLine($"Сумма всех элементов: {arr1.Sum}");
            Console.WriteLine($"В {nameof(arr2)} максимальное число {arr2.Max} встречается в количестве: {arr2.MaxCount}");
            Console.WriteLine($"Сумма всех элементов: {arr2.Sum}");
            Console.WriteLine();
            StaticClass.PrintArray(arr1.Inverse(), "Инверсия массива " + nameof(arr1) + ":");
            Console.WriteLine();
            Console.WriteLine($"Умножим массив {nameof(arr2)} на 5: ");
            arr2.Multi(5);
            Console.WriteLine(arr2);
            Console.WriteLine();

            Console.WriteLine("Частота вхождения каждого элемента в массиве " + nameof(arr1));
            arr1.ShowCountRepeatingElements();
            Console.WriteLine();
            Console.WriteLine("Частота вхождения каждого элемента в массиве " + nameof(arr2));
            arr2.ShowCountRepeatingElements();
            Console.WriteLine();
        }

        #endregion

        #region Task 04

        /*
                
                Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив. 
                Создайте структуру Account, содержащую Login и Password.
         
         */

        static void Task4(string taskName)
        {
            ConsoleHelper.StartSettings(taskName);

            Console.WriteLine("1. Авторизоваться\n2. Создать новый аккаунт\n3. Выход\nОтвет: ");

            switch (Console.ReadLine())
            {
                case "1":
                    if (CheckAuthorization() == true)
                    {
                        Console.WriteLine("Доступ к программе открыт.");
                    }
                    else
                    {
                        Console.WriteLine("Доступ к программе закрыт.");
                    }
                    break;
                case "2":
                    try
                    {
                        Console.Write("Введите логин: ");
                        string login = Console.ReadLine();
                        Console.Write("Введите пароль: ");
                        string password = Console.ReadLine();
                        Account newAccount = new Account() { Login = login, Password = password };
                        AddAccountData(newAccount);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }

                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("Некорректный ввод.");
                    break;
            }
        }

        static bool VerifyLoginAndPassword(string enteredLogin, string enteredPassword, out Account currentAccount)
        {
            Account[] accounts = GetAllAccounts();

            if (accounts != null)
            {
                foreach (Account account in accounts)
                {
                    if (account.Login == enteredLogin && account.Password == enteredPassword)
                    {
                        currentAccount = account;
                        return true;
                    }
                }
            }

            currentAccount = new Account();
            return false;
        }

        static Account[] GetAllAccounts()
        {
            string fileName = "accounts.dat";

            if (File.Exists(fileName) == false)
            {
                return null;
            }

            string[] data = File.ReadAllLines(fileName);

            if (data.Length == 0)
            {
                return null;
            }

            Account[] accounts = new Account[data.Length];

            for (int i = 0; i < accounts.Length; i++)
            {
                string[] accauntData = data[i].Split(' ');
                accounts[i].Login = accauntData[0];
                accounts[i].Password = accauntData[1];
            }

            return accounts;
        }

        static void AddAccountData(Account account)
        {
            string fileName = "accounts.dat";

            if (File.Exists(fileName) == false)
            {
                File.Create(fileName).Close();
            }

            Account[] accounts = GetAllAccounts();

            foreach(Account acc in accounts)
            {
                if(account.Login == acc.Login)
                {
                    Console.WriteLine("Такой пользователь уже зарегистрирован.");
                    return;
                }
            }

            StreamWriter sw = new StreamWriter(fileName);
            sw.WriteLine($"{account.Login} {account.Password}");
            sw.Close();
            Console.WriteLine("Аккаунт создан. Теперь вы можете авторизоваться.");
        }

        static bool CheckAuthorization()
        {
            int attemptsCount = 3;
            bool isCorrectInput = false;
            string userInputLogin;
            string userInputPassword;

            do
            {
                Console.Clear();
                Console.WriteLine($"Попыток авторизоваться: {attemptsCount}");
                Console.WriteLine("======================");
                Console.Write("Введите логин: ");
                userInputLogin = Console.ReadLine();
                Console.Write("Введите пароль: ");
                userInputPassword = Console.ReadLine();
                Console.WriteLine("======================");
                isCorrectInput = VerifyLoginAndPassword(userInputLogin, userInputPassword, out Account currentAccount);

                if (isCorrectInput)
                {
                    Console.WriteLine($"Авторизация выполнена успешно!\nТекущий пользователь: {currentAccount.Login}");
                    return true;
                }
                else
                {
                    Console.WriteLine("Неверный логин или пароль.");
                    attemptsCount--;
                    ConsoleHelper.Pause();
                }

            }
            while (attemptsCount > 0);

            Console.Clear();
            Console.WriteLine("Закончились попытки авторизации. Попробуйте позднее.");
            return false;
        }

        #endregion
    }

    internal struct Account
    {
        private string _login;
        private string _password;

        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Логин не может быть null или пустым");
                }

                value.Replace(" ", "");
                _login = value;
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Пароль не может быть null или пустым");
                }

                value.Replace(" ", "");
                _password = value;
            }
        }
    }
}
