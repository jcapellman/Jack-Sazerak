using JackSazerak.UWP.Managers;
using JackSazerak.UWP.Objects.Containers;
using JackSazerak.UWP.States;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JackSazerak.UWP
{
    public class MainGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SoundManager soundManager;

        BaseState currentState;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            soundManager = new SoundManager(GameWrapper);
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
            
            currentState = new LevelState("E1M1", GameWrapper);
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            var state = Keyboard.GetState();
            
            currentState.HandleInputs(state.GetPressedKeys());

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            currentState.Render(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}