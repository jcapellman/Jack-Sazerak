using System.Linq;

using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Objects;
using JackSazerak.UWP.Objects.Containers;
using JackSazerak.UWP.Objects.JSONObjects;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JackSazerak.UWP.States
{
    public class MainMenuState : BaseState
    {
        private readonly Tile background;

        public MainMenuState(GameWrapper gameWrapper)
        {
            background = new Tile(new LevelTile { TextureName = "mainmenu", TileType = TILE_TYPE.BACKGROUNDS}, gameWrapper);    
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            background.Render(spriteBatch);
        }

        public override void HandleInputs(Keys[] keysPressed)
        {
            if (keysPressed.Any(a => a == Keys.Enter))
            {
                OnSwitchState(GAME_STATES.LEVEL);
            }
        }
    }
}