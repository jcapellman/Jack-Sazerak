using System;

using JackSazerak.UWP.Common;
using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Managers;
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
        SoundManager soundManager;
        StateManager stateManager;

        public MainGame()
        {
            TargetElapsedTime = TimeSpan.FromTicks(Constants.GAME_UPDATE_TICKS);

            graphics = new GraphicsDeviceManager(this);
            graphics.PreparingDeviceSettings += Graphics_PreparingDeviceSettings;

            Content.RootDirectory = "Content";

            soundManager = new SoundManager(GameWrapper);
        }

        private void Graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
        {
            e.GraphicsDeviceInformation.PresentationParameters.PresentationInterval = PresentInterval.One;
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
            
            stateManager = new StateManager();

            stateManager.SwitchState += StateManager_SwitchState;
            
            stateManager.OnSwitchState(GAME_STATES.MAIN_MENU);
        }

        private void StateManager_SwitchState(object sender, Enums.GAME_STATES e)
        {
            stateManager.SetState(e, GameWrapper);
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            stateManager.HandleInput(Keyboard.GetState());

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            stateManager.RenderState(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}