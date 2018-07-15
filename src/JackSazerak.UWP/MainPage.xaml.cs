using System;
using System.Collections.Generic;

using Windows.UI.Xaml.Controls;

using JackSazerak.lib.GameStates;
using JackSazerak.lib.GameStates.Base;
using JackSazerak.lib.IoC;
using JackSazerak.UWP.Implementations;

using Microsoft.Graphics.Canvas.UI.Xaml;
using Microsoft.Graphics.Canvas;
using System.Threading.Tasks;

namespace JackSazerak.UWP
{
    public sealed partial class MainPage : Page
    {
        private BaseState _currentState;

        private UWPResourceManager _resourceManager = new UWPResourceManager();

        private Queue<string> _resourceQueue;

        public MainPage()
        {
            InitializeComponent();
            
            _resourceQueue = new Queue<string>();
            _resourceManager.OnTextureLoadRequest += _resourceManager_OnTextureLoadRequest;

            IOCContainer.Initialize(new Win2DGraphicsRenderer(_resourceManager));
            
            _currentState = new MainGameState();
        }

        private void _resourceManager_OnTextureLoadRequest(object sender, string e)
        {
           var result = CanvasBitmap.LoadAsync(cControl, e);

            var temp = result;
        }

        void CanvasControl_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            _currentState.Render(args.DrawingSession);
        }

        async Task CreateResourcesAsync(CanvasControl sender)
        {
            for (var x = 0; x < _resourceQueue.Count; x++) {
                var textureFileName = _resourceQueue.Dequeue();

                var result = await CanvasBitmap.LoadAsync(sender, textureFileName);
            }
        }

        private void cControl_CreateResources(CanvasControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args)
        {
            args.TrackAsyncAction(CreateResourcesAsync(sender).AsAsyncAction());
        }
    }
}