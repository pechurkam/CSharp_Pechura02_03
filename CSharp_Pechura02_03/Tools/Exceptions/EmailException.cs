using System;

namespace CSharp_Pechura02_03.Tools.Exceptions
{
    internal class EmailException : Exception
    {
        public EmailException(string email)
            : base($"Неправильна адреса: {email}")

        {
        }
    }
}
