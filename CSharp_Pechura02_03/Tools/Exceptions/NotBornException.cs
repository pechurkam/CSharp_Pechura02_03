using System;

namespace CSharp_Pechura02_03.Tools.Exceptions
{
    class NotBornException : Exception
    {
        public NotBornException() : base("Людина ще не народилась!")
        {
        }
    }
}
