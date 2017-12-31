using System;

using JackSazerak.Library.Common;
using JackSazerak.Library.Enums;

using JackSazerak.UWP.Objects;
using JackSazerak.UWP.Objects.Containers;

using Microsoft.Xna.Framework;

namespace JackSazerak.UWP.GameObjects
{
    public abstract class BaseTextGameObject : Text
    {
        protected BaseTextGameObject(string str, Color color, FontName fontName, HorizontalAlignment hAlignment, VerticalAlignment vAlignment, GameWrapper wrapper, Vector2? position = null, float? offsetX = null, float? offsetY = null) : base(str, color, position, fontName, wrapper.ContentManager)
        {
            if (hAlignment == HorizontalAlignment.NONE && vAlignment == VerticalAlignment.NONE && position.HasValue)
            {
                UpdatePosition(position.Value);
                return;
            }

            var actualPosition = new Vector2();

            switch (hAlignment)
            {
                case HorizontalAlignment.NONE:
                    break;
                case HorizontalAlignment.LEFT:
                    actualPosition.X = 0;
                    break;
                case HorizontalAlignment.CENTER:
                    actualPosition.X = (Constants.TARGET_RESOLUTION_WIDTH - Width) / 2.0f;
                    break;
                case HorizontalAlignment.RIGHT:
                    actualPosition.X = (Constants.TARGET_RESOLUTION_WIDTH - Width);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(hAlignment), hAlignment, null);
            }

            switch (vAlignment)
            {
                case VerticalAlignment.NONE:
                    break;
                case VerticalAlignment.TOP:
                    actualPosition.Y = 0;
                    break;
                case VerticalAlignment.CENTER:
                    actualPosition.Y = (Constants.TARGET_RESOLUTION_HEIGHT - Height) / 2.0f;
                    break;
                case VerticalAlignment.BOTTOM:
                    actualPosition.Y = Constants.TARGET_RESOLUTION_HEIGHT;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(vAlignment), vAlignment, null);
            }

            if (offsetX.HasValue)
            {
                actualPosition.X += offsetX.Value;
            }

            if (offsetY.HasValue)
            {
                actualPosition.Y += offsetY.Value;
            }

            UpdatePosition(actualPosition);
        }
    }
}