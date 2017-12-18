using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace JackSazerak.UWP.Objects.Containers
{
    public class GameWrapper
    {
        public ContentManager ContentManager { get; set; }

        public int Window_Width { get; set; }

        public int Window_Height { get; set; }

        public GraphicsDevice GraphicsDevice { get; set; }
    }
}