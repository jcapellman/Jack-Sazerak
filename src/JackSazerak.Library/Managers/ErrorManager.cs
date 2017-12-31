using System;

using JackSazerak.Library.Enums;
using JackSazerak.Library.PlatformInterfaces;
using static JackSazerak.Library.Managers.EventManager;

namespace JackSazerak.Library.Managers
{
    public class ErrorManager
    {
        private IUserInterface userInterface;

        public ErrorManager(IUserInterface userInterface)
        {
            this.userInterface = userInterface;

            EventOccurred += EventManager_EventOccurred;
        }

        private void EventManager_EventOccurred(object sender, EventWrapper eventWrapper)
        {
            // TODO Handle various levels to local storage, WebAPI upload and user notification
            switch (eventWrapper.ActionFired)
            {
                case EventAction.ERROR_CRITICAL:
                    break;
                case EventAction.ERROR_INFO:
                    break;
                case EventAction.ERROR_WARNING:
                    break;
                default:
                    return;
            }

            userInterface.ShowMessageBox(eventWrapper.SourceAction.GetDescription(), ((Exception)eventWrapper.Content).ToString());
        }
    }
}