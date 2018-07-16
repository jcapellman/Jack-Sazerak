using System.Windows;

using JackSazerak.Editor.ViewModels;

namespace JackSazerak.Editor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
        }
    }
}