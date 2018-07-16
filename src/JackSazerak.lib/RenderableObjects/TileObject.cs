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

using JackSazerak.lib.Enums;
using JackSazerak.lib.Objects;
using JackSazerak.lib.RenderableObjects.Base;

namespace JackSazerak.lib.RenderableObjects
{
    public class TileObject : BaseRenderableObject
    {
        private readonly float _scale;

        public TileObject(string resourceFileName, float xPosition, float yPosition, float scale)
        {
            UpdatePosition(new Point(xPosition, yPosition));

            _scale = scale;

            ResourceObject = new ResourceObject(resourceFileName, ResourceTypes.TILE);
        }

        public override void Render()
        {
            IoC.IOCContainer.GfxRenderer.DrawTexture(ResourceObject.Resource, _currentPosition.X, _currentPosition.Y, _scale);
        }
    }
}