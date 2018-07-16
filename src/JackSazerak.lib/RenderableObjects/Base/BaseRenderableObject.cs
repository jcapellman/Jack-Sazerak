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

using JackSazerak.lib.Common;
using JackSazerak.lib.Enums;
using JackSazerak.lib.Objects;

namespace JackSazerak.lib.RenderableObjects.Base
{
    public abstract class BaseRenderableObject
    {
        protected Point _currentPosition;

        public abstract void Render();

        protected ResourceObject ResourceObject;

        public string ResouceFileName => ResourceObject?.FileName;

        public ResourceTypes ResourceType => ResourceObject.ResourceType;

        public object Resource {
            get => ResourceObject.Resource;

            set => ResourceObject.Resource = value;
        }

        public double ResouceWidth { get; set; }

        public double ResourceHeight { get; set; }

        protected BaseRenderableObject()
        {
            _currentPosition = new Point(0.0f, 0.0f);
        }

        public void UpdatePosition(Point point, double windowWidth = 0.0, double windowHeight = 0.0)
        {
            if (ResourceObject != null && !ResourceObject.RestrictedToWindow)
            {
                _currentPosition = point;

                return;
            }

            if (ResourceObject == null || !ResourceObject.RestrictedToWindow)
            {
                _currentPosition = point;

                return;
            }

            // Right Hand Collision
            if (point.X + ResouceWidth + Constants.WINDOW_WIDTH_COLLISION_BUFFER > windowWidth)
            {
                return;
            }

            // Left Hand Collision
            if (Math.Abs(point.X - ResouceWidth) < 0)
            {
                return;
            }

            // Top Collision
            if (Math.Abs(ResourceHeight - point.Y) < 0)
            {
                return;
            }

            // Bottom Collision
            if (point.Y + ResourceHeight + Constants.WINDOW_HEIGHT_COLLISION_BUFFER > windowHeight)
            {
                return;
            }

            _currentPosition = point;
        }
    }
}