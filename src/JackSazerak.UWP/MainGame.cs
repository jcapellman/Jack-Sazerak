using JackSazerak.UWP.Managers;
using JackSazerak.UWP.Objects;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JackSazerak.UWP
{
    public class MainGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        LevelContainer currentLevel;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            currentLevel = LevelManager.LoadLevel(this.Content);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            foreach (var tile in currentLevel.Tiles)
            {
                spriteBatch.Draw(tile.Texture, tile.Rect, tile.Color);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}