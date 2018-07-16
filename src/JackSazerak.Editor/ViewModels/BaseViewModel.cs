using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace JackSazerak.Editor.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region MVVM Boilerplate code
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}