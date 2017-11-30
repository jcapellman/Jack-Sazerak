using System;

namespace JackSazerak.UWP.Managers
{
    public static class EventManager
    {
        public static event EventHandler<Enums.ACTION> EventOccurred;

        private static void OnEventOccurred(Enums.ACTION action)
        {
            EventOccurred?.Invoke(null, action);
        }

        public static void FireEvent(Enums.ACTION actionTaken, object argument = null)
        {
            OnEventOccurred(actionTaken);
        }
    }
}