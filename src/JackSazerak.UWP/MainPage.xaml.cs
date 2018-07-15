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

        Task _stateLoadTask;

        public MainPage()
        {
            InitializeComponent();

            _nextState = new MainGameState();

            Window.Current.SizeChanged += Current_SizeChanged;
            Window.Current.CoreWindow.PointerMoved += CoreWindow_PointerMoved;
        }

        private void CoreWindow_PointerMoved(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.PointerEventArgs args)
        {
            _currentState?.UpdateMousePosition(args.CurrentPoint.Position.X, args.CurrentPoint.Position.Y);
        }

        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            IOCContainer.GfxRenderer.UpdateScale();
        }

        async Task LoadResourcesForStateAsync(CanvasControl resourceCreator, BaseState state)
        {
            foreach (var item in state.ResourceRenderables)
            {
                item.RenderObject.Resource = await CanvasBitmap.LoadAsync(resourceCreator, new Uri($"ms-appx:///Assets/Resources/{item.RenderObject.ResourceType}/{item.RenderObject.ResouceFileName}"));
            }
            
            _currentState = state;
        }

        public void LoadState(BaseState state)
        {
            _nextState = state;

            _stateLoadTask = LoadResourcesForStateAsync(cControl, _nextState);
        }

        void CanvasControl_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            _currentState?.Render(args.DrawingSession);

            cControl.Invalidate();
        }

        async Task CreateResourcesAsync(CanvasControl sender)
        {
            if (_stateLoadTask != null)
            {
                _stateLoadTask.AsAsyncAction().Cancel();

                try { await _stateLoadTask; } catch { }

                _stateLoadTask = null;
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