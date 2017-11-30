using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Managers;
using JackSazerak.UWP.Objects;
using JackSazerak.UWP.Objects.Containers;

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

        private GameWrapper GameWrapper => new GameWrapper
        {
            ContentManager = Content,
            Window_Height = Window.ClientBounds.Height,
            Window_Width = Window.ClientBounds.Width
        };
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            currentLevel = LevelManager.LoadLevel(GameWrapper);
        }

        protected override void UnloadContent()
        {
            Content.Unload();
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
                        EventManager.FireEvent(ACTION.PLAYER_MOVE_RIGHT);                      
                        break;
                    case Keys.Left:
                        EventManager.FireEvent(ACTION.PLAYER_MOVE_LEFT);
                        break;
                    case Keys.Up:
                        EventManager.FireEvent(ACTION.PLAYER_MOVE_UP);
                        break;
                    case Keys.Down:
                        EventManager.FireEvent(ACTION.PLAYER_MOVE_DOWN);
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