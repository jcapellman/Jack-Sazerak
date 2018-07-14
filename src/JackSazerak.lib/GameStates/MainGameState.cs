using System.Drawing;

using JackSazerak.lib.GameStates.Base;
using JackSazerak.lib.RenderableObjects;

namespace JackSazerak.lib.GameStates
{
    public class MainGameState : BaseState
    {
        public MainGameState()
        {
            AddObject(new TextObject("Jack Sazerak", 100, 100, Color.Black));
        }
    }
}