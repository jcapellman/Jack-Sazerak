using System;
using JackSazerak.Library.Common;
using JackSazerak.Library.Enums;
using JackSazerak.Library.Objects;

using JackSazerak.Library.Objects.Containers;

using Microsoft.Xna.Framework;

namespace JackSazerak.Library.GameObjects
{
    public abstract class BaseGameObject : Tile
    {
        protected BaseGameObject(string textureName, TileType tileType, GameWrapper wrapper, Vector2? size = null, Vector2? position = null, HorizontalAlignment? hAlignment = null, VerticalAlignment? vAlignment = null) : base(textureName, tileType, wrapper, size, position)
        {
            var actualPosition = new Vector2();

            if (hAlignment.HasValue)
            {
                switch (hAlignment.Value)
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
        }
    }
}