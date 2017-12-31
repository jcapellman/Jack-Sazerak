using System;

using JackSazerak.Library.Enums;

namespace JackSazerak.UWP.Managers
{
    public static class EventManager
    {
        public class EventWrapper
        {
            public EventAction ActionFired { get; private set; }

            public object Content { get; private set; }

            public EventAction SourceAction { get; private set; }

            public EventWrapper(EventAction actionFired, EventAction sourceAction, object content = null)
            {
                ActionFired = actionFired;
                SourceAction = sourceAction;
                Content = content;
            }
        }

        public static event EventHandler<EventWrapper> EventOccurred;
        
        public static void FireEvent(EventAction actionTaken, EventAction sourceAction, object argument = null)
        {
            EventOccurred?.Invoke(null, new EventWrapper(actionTaken, sourceAction, argument));
        }
    }
}