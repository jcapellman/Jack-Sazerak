using System;
using System.Threading.Tasks;

using Windows.UI.Xaml.Controls;

using JackSazerak.lib.GameStates;
using JackSazerak.lib.GameStates.Base;

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
        }
        
        async Task LoadResourcesForStateAsync(CanvasControl resourceCreator, BaseState state)
        {
            foreach (var item in state.Renderables)
            {
                item.Resource = await CanvasBitmap.LoadAsync(resourceCreator, item.ResouceFileName);
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