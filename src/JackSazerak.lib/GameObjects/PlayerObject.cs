using JackSazerak.lib.GameObjects.Aircraft.Base;
using JackSazerak.lib.GameObjects.Base;

namespace JackSazerak.lib.GameObjects
{
    public class PlayerObject : BaseGameObject
    {
        private BaseAircraft _playerAircraft;

        public PlayerObject(BaseAircraft aircraft)
        {
            _playerAircraft = aircraft;

            RenderObject = _playerAircraft.RenderObject;
        }

        public override void Render()
        {
            _playerAircraft.Render();
        }
    }
}