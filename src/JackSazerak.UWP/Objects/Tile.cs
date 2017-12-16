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
        public Tile(string textureName, TILE_TYPE tileType, GameWrapper wrapper)
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
                    Rect = new Rectangle(0, 0, Width, Height);

                    UpdatePosition(PositionX, PositionY);
                    break;
                case TILE_TYPE.SPRITES:
                    Rect = new Rectangle(0, 0, Texture.Width, Texture.Height);

                    UpdatePosition(0, wrapper.Window_Height - Texture.Height);
                    break;
            }
        }

        protected int Width { get; set; }

        protected int Height { get; set; }

        protected int PositionX { get; set; }

        protected int PositionY { get; set; }

        private void EventManager_EventOccurred(object sender, ACTION e)
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
            if (absolute)
            {
                TilePosition = new Vector2(x, y);
            } else
            {
                TilePosition = new Vector2(TilePosition.X + x, TilePosition.Y + y);
            }
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