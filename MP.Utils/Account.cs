using System;


namespace MP.Utils
{
    public struct Account
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
