using System;


namespace HomeWork
{
    //author: Maxim Pokrovsky
    internal class Program
    {
        static void Main(string[] args)
        {

        }

    }

    internal static class Helper
    {
        public static void Print(string message, int cursorPositionX, int cursorPositionY)
        {
            Console.SetCursorPosition(cursorPositionX, cursorPositionY);
            Console.WriteLine(message);
        }

        public static void Pause()
        {
            Console.WriteLine("\nНажмите ENTER для продолжения . . .");
            Console.ReadLine();
        }

        public static void StartProgrammSetting(string title)
        {
            Console.Title = title;
            Console.Clear();
        }
    }

}
