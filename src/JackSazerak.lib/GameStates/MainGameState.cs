using JackSazerak.lib.GameObjects;
using JackSazerak.lib.GameObjects.Aircraft;
using JackSazerak.lib.GameStates.Base;

namespace JackSazerak.lib.GameStates
{
    public class MainGameState : BaseState
    {
        public MainGameState()
        {
            AddObject(new PlayerObject(new F18(true)));

            MousePositionChanged += MainGameState_MousePositionChanged;
        }

        private void MainGameState_MousePositionChanged(object sender, Objects.Point e)
        {
            GetStateObject(typeof(PlayerObject)).UpdatePosition(e, _windowWidth, _windowHeight);
        }
    }
}