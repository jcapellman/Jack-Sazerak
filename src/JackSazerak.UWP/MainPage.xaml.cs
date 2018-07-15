using System;
using System.Threading.Tasks;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using JackSazerak.lib.GameStates;
using JackSazerak.lib.GameStates.Base;
using JackSazerak.lib.IoC;

using Microsoft.Graphics.Canvas.UI.Xaml;
using Microsoft.Graphics.Canvas;

namespace JackSazerak.UWP
{
    public sealed partial class MainPage : Page
    {
        private BaseState _currentState;
        private BaseState _nextState = null;

        Task stateLoadTask;

        public MainPage()
        {
            InitializeComponent();

            _nextState = new MainGameState();

            Window.Current.SizeChanged += Current_SizeChanged;
        }

        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            IOCContainer.GfxRenderer.UpdateScale();
        }

        async Task LoadResourcesForStateAsync(CanvasControl resourceCreator, BaseState state)
        {
            foreach (var item in state.ResourceRenderables)
            {
                item.Resource = await CanvasBitmap.LoadAsync(resourceCreator, new Uri($"ms-appx:///Assets/Resources/{item.ResourceType}/{item.ResouceFileName}"));
            }
            
            _currentState = state;
        }

        public void LoadState(BaseState state)
        {
            _nextState = state;

            stateLoadTask = LoadResourcesForStateAsync(cControl, _nextState);
        }

        void CanvasControl_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            _currentState?.Render(args.DrawingSession);

            cControl.Invalidate();
        }

        async Task CreateResourcesAsync(CanvasControl sender)
        {
            if (stateLoadTask != null)
            {
                stateLoadTask.AsAsyncAction().Cancel();

                try { await stateLoadTask; } catch { }

                stateLoadTask = null;
            }

            if (_nextState != null)
            {
                LoadState(_nextState);
            }
        }
        
        private void cControl_CreateResources(CanvasControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args)
        {
            args.TrackAsyncAction(CreateResourcesAsync(sender).AsAsyncAction());
        }
    }
}