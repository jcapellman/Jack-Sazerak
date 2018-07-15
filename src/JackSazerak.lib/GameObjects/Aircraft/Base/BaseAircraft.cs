using JackSazerak.lib.GameObjects.Base;
using JackSazerak.lib.RenderableObjects;

namespace JackSazerak.lib.GameObjects.Aircraft.Base
{
    public abstract class BaseAircraft : BaseGameObject
    {
        protected BaseAircraft(string spriteFileName, bool restrictToWindow = false)
        {
            RenderObject = new SpriteObject(spriteFileName, 0, 0, 1.0f, restrictToWindow);
        }
    }
}