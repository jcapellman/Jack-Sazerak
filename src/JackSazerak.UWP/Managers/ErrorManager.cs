using System;

using JackSazerak.Library.PlatformInterfaces;
using JackSazerak.UWP.Objects.Containers;
using static JackSazerak.UWP.Managers.EventManager;

namespace JackSazerak.UWP.Managers
{
    public class ErrorManager
    {
        private IUserInterface userInterface;

        public ErrorManager(GameWrapper gameWrapper)
        {
            userInterface = gameWrapper.UserInterface;

            EventOccurred += EventManager_EventOccurred;
        }

        private void EventManager_EventOccurred(object sender, EventWrapper eventWrapper)
        {
            // TODO Handle various levels to local storage, WebAPI upload and user notification
            switch (eventWrapper.ActionFired)
            {
                case Enums.ACTION.ERROR_CRITICAL:
                    break;
                case Enums.ACTION.ERROR_INFO:
                    break;
                case Enums.ACTION.ERROR_WARNING:
                    break;
                default:
                    return;
            }

            userInterface.ShowMessageBox(ExtensionMethods.GetDescription(eventWrapper.SourceAction), ((Exception)eventWrapper.Content).ToString());
        }
    }
}