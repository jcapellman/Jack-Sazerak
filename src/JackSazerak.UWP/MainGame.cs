using JackSazerak.UWP.Managers;
using JackSazerak.UWP.Objects;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
            var state = Keyboard.GetState();

            var pressedKeys = state.GetPressedKeys();

            foreach (var keyPressed in pressedKeys)
            {
                switch (keyPressed)
                {
                    case Keys.Right:
                        currentLevel.CurrentPlayer.UpdatePosition(10, 0);
                        break;
                    case Keys.Left:
                        currentLevel.CurrentPlayer.UpdatePosition(-10, 0);
                        break;
                    case Keys.Up:
                        currentLevel.CurrentPlayer.UpdatePosition(0, -10);
                        break;
                    case Keys.Down:
                        currentLevel.CurrentPlayer.UpdatePosition(0, 10);
                        break;

                }
            }

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            foreach (var tile in currentLevel.Tiles)
            {
                tile.Render(spriteBatch);
            }

            currentLevel.CurrentPlayer.Render(spriteBatch);
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}