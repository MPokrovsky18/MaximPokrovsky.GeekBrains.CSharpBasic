using System;
using System.Text;
using System.Text.RegularExpressions;


namespace MP.Utils
{
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
