using System;

namespace JackSazerak.UWP.Managers
{
    public static class EventManager
    {
        public static event EventHandler<(Enums.ACTION, object)> EventOccurred;
        
        public static void FireEvent(Enums.ACTION actionTaken, object argument = null)
        {
            EventOccurred?.Invoke(null, (actionTaken, argument));
        }
    }
}