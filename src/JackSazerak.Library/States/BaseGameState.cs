using JackSazerak.Library.Enums;
using JackSazerak.Library.Objects.Containers;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JackSazerak.Library.States
{
    public class BaseGameState : BaseState
    {
        public override GameStates GameState => throw new System.NotImplementedException();
        
        public override void HandleInputs(KeyboardState state)
        {
            throw new System.NotImplementedException();
        }

        public override void InitState(GameWrapper gameWrapper)
        {
            throw new System.NotImplementedException();
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            throw new System.NotImplementedException();
        }
    }
}