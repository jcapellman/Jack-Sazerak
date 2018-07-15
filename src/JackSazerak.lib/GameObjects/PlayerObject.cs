using JackSazerak.lib.GameObjects.Base;

namespace JackSazerak.lib.GameObjects
{
    public class PlayerObject : BaseGameObject
    {
        public PlayerObject(BaseGameObject aircraft)
        {
            RenderObject = aircraft.RenderObject;
        }

        public override void Render()
        {
            RenderObject.Render();
        }
    }
}