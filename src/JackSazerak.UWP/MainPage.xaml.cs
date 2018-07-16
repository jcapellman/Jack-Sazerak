// Copyright (c) 2018 Jarred Capellman
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

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

            _currentState?.UpdateWindowBounds(e.Size.Width, e.Size.Height);
        }

        async Task LoadResourcesForStateAsync(CanvasControl resourceCreator, BaseState state)
        {
            foreach (var item in state.ResourceRenderables)
            {
                var canvasBitmap = await CanvasBitmap.LoadAsync(resourceCreator, new Uri($"ms-appx:///Assets/Resources/{item.RenderObject.ResourceType}/{item.RenderObject.ResouceFileName}"));

                item.RenderObject.ResouceWidth = canvasBitmap.Size.Width;
                item.RenderObject.ResourceHeight = canvasBitmap.Size.Height;
                item.RenderObject.Resource = canvasBitmap;
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