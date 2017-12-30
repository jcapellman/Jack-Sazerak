using System;

using JackSazerak.Library.PlatformInterfaces;
using JackSazerak.UWP.Objects.Containers;

namespace JackSazerak.UWP.Managers
{
    public class ErrorManager
    {
        private IUserInterface userInterface;

        public ErrorManager(GameWrapper gameWrapper)
        {
            userInterface = gameWrapper.UserInterface;

            EventManager.EventOccurred += EventManager_EventOccurred;
        }

        private void EventManager_EventOccurred(object sender, (Enums.ACTION eventType, object argument) param)
        {
            // TODO Handle various levels to local storage, WebAPI upload and user notification
            switch (param.eventType)
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

            userInterface.ShowMessageBox(Common.Constants.GAME_NAME, ((Exception)param.argument).ToString());
        }
    }
}