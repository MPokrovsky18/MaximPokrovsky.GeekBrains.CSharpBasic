using System;


namespace MP.Utils
{
    public class QNumber
    {
        private int _m;
        private int _n;

        public int M
        {
            get
            {
                return _m;
            }
            set
            {
                _m = value;
            }
        }
        public int N
        {
            get
            {
                return _n;
            }
            set
            {
                try
                {
                    if (value == 0)
                    {
                        throw new ArgumentException("Делить на ноль нельзя! Знаменателю будет присвоено значение 1");
                    }

                    _n = value;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                    _n = 1;
                }
            }
        }
        public int IntegerPart
        {
            get
            {
                return _m / _n;
            }
        }
        public QNumber FractionalPart
        {
            get
            {
                if (IntegerPart == 0)
                {
                    return this;
                }

                return new QNumber(Math.Abs(_m - (IntegerPart * _n)), _n);
            }
        }
        public double Decimal
        {
            get
            {
                return (double)_m / _n;
            }
        }

        public QNumber(int m, int n = 1)
        {
            if (n < 0)
            {
                m *= -1;
                n *= -1;
            }

            N = n;
            _m = m;
        }

        public QNumber()
        {
            _m = 1;
            _n = 1;
        }

        public QNumber Plus(QNumber number)
        {
            int commonDenominator = N * number.N;
            int resultNumerator = (M * number.N) + (number.M * N);
            return new QNumber(resultNumerator, commonDenominator);
        }

        public QNumber Plus(int number)
        {
            return Plus(new QNumber(number));
        }

        public QNumber Minus(QNumber number)
        {
            int commonDenominator = N * number.N;
            int resultNumerator = (M * number.N) - (number.M * N);
            return new QNumber(resultNumerator, commonDenominator);
        }

        public QNumber Minus(int number)
        {
            return Minus(new QNumber(number));
        }

        public QNumber Multi(QNumber number)
        {
            return new QNumber(M * number.M, N * number.N);
        }

        public QNumber Multi(int number)
        {
            return Multi(new QNumber(number));
        }

        public QNumber Divide(QNumber number)
        {
            return new QNumber(M * number.N, N * number.M);
        }

        public QNumber Divide(int number)
        {
            return Divide(new QNumber(number));
        }

        public bool Simplify()
        {
            int divisor = MathHelper.GetMaxCommonDivisor(_m, _n);

            if (divisor > 1)
            {
                _m /= divisor;
                _n /= divisor;
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            if (_m == 0)
            {
                return "0";
            }
            else if (_m % _n == 0)
            {
                return $"{_m / _n}";
            }
            else if (_n % 10 == 0)
            {
                return Decimal.ToString();
            }
            else if (IntegerPart != 0)
            {
                return $"{IntegerPart}({FractionalPart})";
            }

            return $"{_m}/{_n}";
        }
    }
}
