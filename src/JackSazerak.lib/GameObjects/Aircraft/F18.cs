using JackSazerak.lib.GameObjects.Aircraft.Base;

namespace JackSazerak.lib.GameObjects.Aircraft
{
    public class F18 : BaseAircraft
    {
        public override void Render()
        {
            RenderObject.Render();
        }

        public F18(bool restrictToWindow) : base("F18.png", restrictToWindow)
        {
        }
    }
}