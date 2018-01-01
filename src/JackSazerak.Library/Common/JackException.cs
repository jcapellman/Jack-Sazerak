using JackSazerak.Library.Enums;
using System;

namespace JackSazerak.Library.Common
{
    public class JackException : Exception
    {
        public ExceptionTypes ExceptionType { get; set; }

        public string ExceptionTitle { get; set; }

        public string ExceptionMessage { get; set; }
        
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