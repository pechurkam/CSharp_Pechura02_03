using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using CSharp_Pechura02_03.Tools.Exceptions;

namespace CSharp_Pechura02_03
{
    class Person : INotifyPropertyChanged
    {
        #region Fields

        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDate;

        #endregion

        #region Properties

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string BirthdayString
        {
            get { return _birthDate.ToShortDateString(); }
        }

        public DateTime Birthday
        {
            get { return _birthDate; }
            set
            {
                _birthDate = Convert.ToDateTime(value);
                OnPropertyChanged();
                OnPropertyChanged("IsAdult");
                OnPropertyChanged("IsBirthday");
                OnPropertyChanged("BirthdayString");
                OnPropertyChanged("SunSign");
                OnPropertyChanged("ChineseSign");
            }
        }

        #endregion

        #region Constructors

        public Person(string name, string surname, string email, DateTime birthDate)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _birthDate = birthDate;
        }

        public Person(string name, string surname, string email)
        {
            _name = name;
            _surname = surname;
            _email = email;
        }

        public Person(string name, string surname, DateTime
            birthDate)
        {
            _name = name;
            _surname = surname;
            _birthDate = birthDate;
        }

        #endregion

        #region ReadOnlyProps

        private int Age
        {
            get
            {
                int age = (DateTime.Today - Convert.ToDateTime(_birthDate)).Days / 365;
                return age;
            }
        }

        public bool IsAdult
        {
            get { return Age >= 18; }
        }

        public string SunSign
        {
            get
            {
                string zodiac = "";
                string[] zodiacSigns =
                {
                    "Овен", "Телець", "Близнюки", "Paк", "Лев", "Діва", "Терези", "Скорпіон", "Стрілець", "Козоріг",
                    "Водолій", "Риби"
                };
                if ((_birthDate.Month == 3 && _birthDate.Day >= 21) || (_birthDate.Month == 4 && _birthDate.Day <= 20))
                {
                    zodiac = zodiacSigns[0];
                }
                else if ((_birthDate.Month == 4 && _birthDate.Day >= 21) ||
                         (_birthDate.Month == 5 && _birthDate.Day <= 20))
                {
                    zodiac = zodiacSigns[1];
                }
                else if ((_birthDate.Month == 5 && _birthDate.Day >= 21) ||
                         (_birthDate.Month == 6 && _birthDate.Day <= 21))
                {
                    zodiac = zodiacSigns[2];
                }
                else if ((_birthDate.Month == 6 && _birthDate.Day >= 22) ||
                         (_birthDate.Month == 7 && _birthDate.Day <= 22))
                {
                    zodiac = zodiacSigns[3];
                }
                else if ((_birthDate.Month == 7 && _birthDate.Day >= 23) ||
                         (_birthDate.Month == 8 && _birthDate.Day <= 23))
                {
                    zodiac = zodiacSigns[4];
                }
                else if ((_birthDate.Month == 8 && _birthDate.Day >= 24) ||
                         (_birthDate.Month == 9 && _birthDate.Day <= 22))
                {
                    zodiac = zodiacSigns[5];
                }
                else if ((_birthDate.Month == 9 && _birthDate.Day >= 23) ||
                         (_birthDate.Month == 10 && _birthDate.Day <= 23))
                {
                    zodiac = zodiacSigns[6];
                }
                else if ((_birthDate.Month == 10 && _birthDate.Day >= 24) ||
                         (_birthDate.Month == 11 && _birthDate.Day <= 22))
                {
                    zodiac = zodiacSigns[7];
                }
                else if ((_birthDate.Month == 11 && _birthDate.Day >= 23) ||
                         (_birthDate.Month == 12 && _birthDate.Day <= 21))
                {
                    zodiac = zodiacSigns[8];
                }
                else if ((_birthDate.Month == 12 && _birthDate.Day >= 22) ||
                         (_birthDate.Month == 1 && _birthDate.Day <= 20))
                {
                    zodiac = zodiacSigns[9];
                }
                else if ((_birthDate.Month == 1 && _birthDate.Day >= 21) ||
                         (_birthDate.Month == 2 && _birthDate.Day <= 20))
                {
                    zodiac = zodiacSigns[10];
                }
                else if ((_birthDate.Month == 2 && _birthDate.Day >= 21) ||
                         (_birthDate.Month == 3 && _birthDate.Day <= 20))
                {
                    zodiac = zodiacSigns[11];
                }

                return zodiac;
            }
        }

        public string ChineseSign
        {
            get
            {
                string[] zodiacSigns =
                {
                    "Криса", "Бик", "Тигр", "Кролик", "Дракон", "Змія", "Кінь", "Коза", "Мавпа", "Півень", "Собака",
                    "Свиня"
                };
                return zodiacSigns[(_birthDate.Year - 4) % 12];
            }
        }

        public bool IsBirthday
        {
            get { return (_birthDate.Day == DateTime.Today.Day) && (_birthDate.Month == DateTime.Today.Month); }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public void Validate()
        {
            if (Age < 0)
            {
                throw new NotBornException();
            }

            if (Age > 135)
            {
                throw new DeadPersonException();
            }

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!regex.IsMatch(_email))
            {
                throw new EmailException(_email);
            }

        }
    }
}
