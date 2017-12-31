using System;

using JackSazerak.UWP.Enums;

namespace JackSazerak.UWP.Managers
{
    public static class EventManager
    {
        public class EventWrapper
        {
            public ACTION ActionFired { get; private set; }

            public object Content { get; private set; }

            public ACTION SourceAction { get; private set; }

            public EventWrapper(ACTION actionFired, ACTION sourceAction, object content = null)
            {
                ActionFired = actionFired;
                SourceAction = sourceAction;
                Content = content;
            }
        }

        public static event EventHandler<EventWrapper> EventOccurred;
        
        public static void FireEvent(Enums.ACTION actionTaken, ACTION sourceAction, object argument = null)
        {
            EventOccurred?.Invoke(null, new EventWrapper(actionTaken, sourceAction, argument));
        }
    }
}