using System;

namespace JackSazerak.Library.Common
{
    public class JackException : Exception
    {
        public string ExceptionTitle { get; set; }

        public string ExceptionMessage { get; set; }
    }
}