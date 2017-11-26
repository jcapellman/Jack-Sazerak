namespace JackSazerak.UWP.Objects
{
    public abstract class BaseObject<T, K>
    {
        public abstract K FromJSON(T jsonObject);
    }
}