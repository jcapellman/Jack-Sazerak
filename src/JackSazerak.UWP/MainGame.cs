﻿using System;

using JackSazerak.UWP.Common;
using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Managers;
using JackSazerak.UWP.Objects.Containers;
using JackSazerak.UWP.PlatformImplementations;
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

        // Platform Implementations
        FileStorage fileStorage;
        UserInterface userInterface;

        Matrix scale;

        public MainGame()
        {
            TargetElapsedTime = TimeSpan.FromTicks(Constants.GAME_UPDATE_TICKS);

            fileStorage = new FileStorage();
            userInterface = new UserInterface();

            InitGraphics();

            Content.RootDirectory = "Content";

            soundManager = new SoundManager(GameWrapper);
        }

        private void InitGraphics()
        {
            graphics = new GraphicsDeviceManager(this);

            graphics.IsFullScreen = true;

            graphics.PreparingDeviceSettings += Graphics_PreparingDeviceSettings;

            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            var scaleX = (float)graphics.PreferredBackBufferWidth / Constants.TARGET_RESOLUTION_WIDTH;
            var scaleY = (float)graphics.PreferredBackBufferHeight / Constants.TARGET_RESOLUTION_HEIGHT;

            scale = Matrix.CreateScale(new Vector3(scaleX, scaleY, 1));
        }

        private void Graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
        {
            e.GraphicsDeviceInformation.PresentationParameters.PresentationInterval = PresentInterval.One;
        }

        private GameWrapper GameWrapper => new GameWrapper
        {
            ContentManager = Content,
            Window_Height = graphics.PreferredBackBufferHeight,
            Window_Width = graphics.PreferredBackBufferWidth,
            GraphicsDevice = graphics.GraphicsDevice,
            FileStorage = fileStorage,
            UserInterface = userInterface
        };
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            stateManager = new StateManager(GameWrapper);

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

            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, scale);

            stateManager.RenderState(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}