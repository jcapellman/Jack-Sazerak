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