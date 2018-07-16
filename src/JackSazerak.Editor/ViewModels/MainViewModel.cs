using JackSazerak.Editor.Common;

using System.Windows.Input;

namespace JackSazerak.Editor.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ICommand exitMenuCommand;

        public ICommand ExitMenuCommand => exitMenuCommand ?? (exitMenuCommand = new CommandHandler(ExitEditor));

        public void ExitEditor()
        {
            App.Current.Shutdown();
        }
    }
}