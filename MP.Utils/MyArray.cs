using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace MP.Utils
{
    public class MyArray
    {
        Random random = new Random();
        private int[] _array;

        public int Max
        {
            get
            {
                return _array.Max();
            }
        }
        public int Sum
        {
            get
            {
                return _array.Sum();
            }
        }
        public int MaxCount
        {
            get
            {
                int count = 0;
                int max = Max;

                foreach (int el in _array)
                {
                    if (el == max)
                    {
                        count++;
                    }
                }

                return count;
            }
        }

        public int this[int i]
        {
            get
            {
                return _array[i];
            }
            set
            {
                _array[i] = value;
            }
        }

        public MyArray(int length)
        {
            _array = new int[length];

            for (int i = 0; i < length; i++)
            {
                _array[i] = random.Next(1, 101);
            }
        }

        public MyArray(string filename)
        {
            if (File.Exists(filename))
            {
                string[] ss = File.ReadAllLines(filename);
                _array = new int[ss.Length];

                for (int i = 0; i < ss.Length; i++)
                {
                    _array[i] = int.Parse(ss[i]);
                }
            }
            else
            {
                Console.WriteLine("Error load file");
            }
        }

        public MyArray(int length, int startValue, int step)
        {
            _array = new int[length];

            for (int i = 0; i < length; i++)
            {
                _array[i] = startValue;
                startValue += step;
            }
        }

        public int[] Inverse()
        {
            int[] inverseArray = new int[_array.Length];

            for (int i = 0; i < inverseArray.Length; i++)
            {
                inverseArray[i] = -_array[i];
            }

            return inverseArray;
        }

        public void Multi(int multiplier)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] *= multiplier;
            }
        }

        public void ShowCountRepeatingElements()
        {
            Dictionary<int, int> counter = new Dictionary<int, int>();

            foreach (int el in _array)
            {
                if (counter.ContainsKey(el))
                {
                    counter[el]++;
                }
                else
                {
                    counter.Add(el, 1);
                }
            }

            foreach (KeyValuePair<int, int> i in counter)
            {
                Console.WriteLine($"\"{i.Key}\" - {i.Value} шт.");
            }
        }

        public override string ToString()
        {
            string s = "";

            foreach (int el in _array)
            {
                s += $"{el,6}";
            }

            return s;
        }
    }
}
