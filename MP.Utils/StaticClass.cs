using System;
using System.IO;


namespace MP.Utils
{
    public class StaticClass
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
                foreach (int el in array)
                {
                    Console.Write("{0,4}", el);
                }

                Console.WriteLine();
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
            string[] lines;

            if (File.Exists(path))
            {
                lines = File.ReadAllLines(path);

                if (lines.Length == 0)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

            int[] array = new int[lines.Length];

            try
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = int.Parse(lines[i]);
                }

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

            for (int i = 0; i < array.Length; i++)
            {
                sw.WriteLine(array[i]);
            }

            sw.Close();
        }
    }
}
