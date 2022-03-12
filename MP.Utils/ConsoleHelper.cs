using System;


namespace MP.Utils
{
    public class ConsoleHelper
    {
        public static void PrintOnPosition(string message, int cursorPositionX, int cursorPositionY)
        {
            Console.SetCursorPosition(cursorPositionX, cursorPositionY);
            Console.WriteLine(message);
        }

        public static void Pause()
        {
            Console.WriteLine("\nНажмите ENTER для продолжения . . .");
            Console.ReadLine();
        }

        public static void StartSettings(string title)
        {
            Console.Title = title;
            Console.Clear();
        }
    }
}
