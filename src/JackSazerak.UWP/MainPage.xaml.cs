using Windows.UI.Xaml.Controls;

using JackSazerak.lib.GameStates;
using JackSazerak.lib.GameStates.Base;

using Microsoft.Graphics.Canvas.UI.Xaml;

namespace JackSazerak.UWP
{
    public sealed partial class MainPage : Page
    {
        private BaseState _currentState;

        public MainPage()
        {
            InitializeComponent();

            _currentState = new MainGameState();
        }

        void CanvasControl_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            _currentState.Render(args.DrawingSession);
        }
    }
}