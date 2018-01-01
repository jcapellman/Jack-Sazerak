namespace JackSazerak.Library.Common
{
    public class ReturnWrapper<T>
    {
        public T Object { get; private set; }

        public JackException ReturnException { get; private set; }

        public bool HasException { get { return ReturnException != null; } }

        public ReturnWrapper(T objectValue)
        {
            Object = objectValue;
        }

        public ReturnWrapper(JackException exception)
        {
            ReturnException = exception;
        }
    }
}