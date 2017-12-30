using System;

using JackSazerak.Library.PlatformInterfaces;

using Windows.UI.Popups;

namespace JackSazerak.UWP.PlatformImplementations
{
    public class UserInterface : IUserInterface
    {
        public async void ShowMessageBox(string title, string content)
        {
            var dialog = new MessageDialog(content);

            await dialog.ShowAsync();
        }
    }
}