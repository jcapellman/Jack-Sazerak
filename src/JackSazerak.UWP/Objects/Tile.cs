using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Managers;
using JackSazerak.UWP.Objects.Containers;
using JackSazerak.UWP.Objects.JSONObjects;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JackSazerak.UWP.Objects
{
    public abstract class Tile : BaseObject<LevelTile, Tile>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="textureName"></param>
        /// <param name="tileType"></param>
        /// <param name="wrapper"></param>
        /// <param name="size">If not used the Texture Size is used</param>
        /// <param name="position">If not used 0,0 is used</param>
        public Tile(string textureName, TILE_TYPE tileType, GameWrapper wrapper, Vector2? size = null, Vector2? position = null)
        {
            Color = Color.White;
            
            Texture = wrapper.ContentManager.Load<Texture2D>($"{tileType}/{textureName}");

            TileType = tileType;

            EventManager.EventOccurred += EventManager_EventOccurred;

            switch (tileType)
            {
                case TILE_TYPE.BACKGROUNDS:
                    Rect = new Rectangle(0, 0, Texture.Width, Texture.Height);
                    break;
                case TILE_TYPE.TILES:
                case TILE_TYPE.REGULAR:
                    Rect = new Rectangle(0, 0, (int) (size?.X ?? Texture.Width), (int)(size?.Y ?? Texture.Height));

                    UpdatePosition((int)(position?.X ?? 0), (int)(position?.Y ?? 0));
                    break;
                case TILE_TYPE.SPRITES:
                    Rect = new Rectangle(0, 0, Texture.Width, Texture.Height);

                    UpdatePosition(0, wrapper.Window_Height - Texture.Height);
                    break;
            }
        }
        
        private void EventManager_EventOccurred(object sender, (ACTION eventType, object argument) param)
        {
            if (TileType == TILE_TYPE.SPRITES)
            {
            }
        }

        private Vector2 TilePosition { get; set; }

        private Texture2D Texture { get; set; }

        private Rectangle Rect { get; set; }

        private Color Color { get; set; }

        public void UpdatePosition(int x = 0, int y = 0, bool absolute = false)
        {
            TilePosition = absolute ? new Vector2(x, y) : new Vector2(TilePosition.X + x, TilePosition.Y + y);
        }

        public void Render(SpriteBatch spriteBatch)
        {
            switch (TileType)
            {
                case TILE_TYPE.TILES:
                    UpdatePosition(0, 5);
                    break;
            }

            spriteBatch.Draw(Texture, TilePosition, Rect, Color);
        }
    }
}