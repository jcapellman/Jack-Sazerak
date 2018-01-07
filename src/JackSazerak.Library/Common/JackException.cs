using System;

using JackSazerak.Library.Enums;

namespace JackSazerak.Library.Common
{
    public class JackException : Exception
    {
        public ExceptionTypes ExceptionType { get; set; }

        public string ExceptionTitle { get; set; }

        public string ExceptionMessage { get; set; }
        
        public JackException() { }

        public JackException(string message) : base(message) { }

        public JackException(string message, Exception inner) : base(message, inner) { }

        public JackException(ExceptionTypes exceptionType, Exception exception, string userExceptionMessage = null)
        {
            ExceptionType = exceptionType;

            ExceptionTitle = ExceptionType.GetDescription();

            if (string.IsNullOrEmpty(userExceptionMessage))
            {
                ExceptionMessage = exception.ToString();
            } else
            {
                ExceptionMessage = userExceptionMessage;
            }
        }
    }
}