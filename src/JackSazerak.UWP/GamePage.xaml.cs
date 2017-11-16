using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace JackSazerak.UWP
{
    public sealed partial class GamePage : Page
    {
		readonly MainGame _game;

		public GamePage()
        {
            this.InitializeComponent();
            
			var launchArguments = string.Empty;
            _game = MonoGame.Framework.XamlGame<MainGame>.Create(launchArguments, Window.Current.CoreWindow, swapChainPanel);
        }
    }
}