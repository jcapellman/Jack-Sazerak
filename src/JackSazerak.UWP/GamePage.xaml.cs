using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace JackSazerak.UWP
{
    public sealed partial class GamePage : Page
    {
		public GamePage()
        {
            InitializeComponent();
            
            MonoGame.Framework.XamlGame<MainGame>.Create(string.Empty, Window.Current.CoreWindow, swapChainPanel);
        }
    }
}