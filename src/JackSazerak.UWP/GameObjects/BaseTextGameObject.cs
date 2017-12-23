using System;

using JackSazerak.UWP.Common;
using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Objects;
using JackSazerak.UWP.Objects.Containers;

using Microsoft.Xna.Framework;

namespace JackSazerak.UWP.GameObjects
{
    public abstract class BaseTextGameObject : Text
    {
        protected BaseTextGameObject(string str, Color color, FONT_NAME fontName, HORIZONTAL_ALIGNMENT hAlignment, VERTICAL_ALIGNMENT vAlignment, GameWrapper wrapper, Vector2? position = null) : base(str, color, position, fontName, wrapper.ContentManager)
        {
            if (hAlignment == HORIZONTAL_ALIGNMENT.NONE && vAlignment == VERTICAL_ALIGNMENT.NONE && position.HasValue)
            {
                UpdatePosition(position.Value);
                return;
            }

            var actualPosition = new Vector2();

            switch (hAlignment)
            {
                case HORIZONTAL_ALIGNMENT.NONE:
                    break;
                case HORIZONTAL_ALIGNMENT.LEFT:
                    actualPosition.X = 0;
                    break;
                case HORIZONTAL_ALIGNMENT.CENTER:
                    actualPosition.X = (Constants.TARGET_RESOLUTION_WIDTH - Width) / 2.0f;
                    break;
                case HORIZONTAL_ALIGNMENT.RIGHT:
                    actualPosition.X = (Constants.TARGET_RESOLUTION_WIDTH - Width);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(hAlignment), hAlignment, null);
            }

            switch (vAlignment)
            {
                case VERTICAL_ALIGNMENT.NONE:
                    break;
                case VERTICAL_ALIGNMENT.TOP:
                    actualPosition.Y = 0;
                    break;
                case VERTICAL_ALIGNMENT.CENTER:
                    actualPosition.Y = (Constants.TARGET_RESOLUTION_HEIGHT - Height) / 2.0f;
                    break;
                case VERTICAL_ALIGNMENT.BOTTOM:
                    actualPosition.Y = Constants.TARGET_RESOLUTION_HEIGHT;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(vAlignment), vAlignment, null);
            }

            UpdatePosition(actualPosition);
        }
    }
}