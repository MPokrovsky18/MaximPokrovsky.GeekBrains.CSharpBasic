using System;


namespace MP.Utils
{
    public class Complex
    {
        private double _im;
        private double _re;

        public double Im
        {
            get
            {
                return _im;
            }
            set
            {
                if (value != 0)
                {
                    _im = value;
                }
            }
        }
        public double Re
        {
            get
            {
                return _re;
            }
            set
            {
                _re = value;
            }
        }

        public Complex()
        {
            _im = 0;
            _re = 0;
        }

        public Complex(double im, double re)
        {
            _im = im;
            _re = re;
        }

        public Complex Plus(Complex x)
        {
            double im = x.Im + _im;
            double re = x.Re + _re;
            return new Complex(im, re);
        }

        public Complex Minus(Complex x)
        {
            double im = _im - x.Im;
            double re = _re - x.Re;
            return new Complex(im, re);
        }

        public Complex Multi(Complex x)
        {
            double im = _re * x.Im + _im * x.Re;
            double re = _re * x.Re - _im * x.Im;
            return new Complex(im, re);
        }

        public Complex Divide(Complex x)
        {
            double denominator = Math.Pow(x.Re, 2) + Math.Pow(x.Im, 2);
            double im = (x.Re * _im - _re * x.Im) / denominator;
            double re = (_re * x.Re + _im * x.Im) / denominator;
            return new Complex(im, re);
        }

        public override string ToString()
        {
            if (_im == 0 && _re == 0)
            {
                return "0";
            }
            if (_im == 0)
            {
                return $"{_re}";
            }
            else if (_re == 0)
            {
                return _im + "i";
            }
            else
            {
                return (_im < 0) ? _re + " - " + Math.Abs(_im) + "i" : _re + " + " + _im + "i";
            }
        }
    }
}
