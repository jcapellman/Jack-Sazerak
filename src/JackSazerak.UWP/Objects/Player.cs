namespace JackSazerak.UWP.Objects
{
    public class Player : Tile
    {
        public Player(Tile tile)
        {
            Texture = tile.Texture;
            Rect = tile.Rect;
            Color = tile.Color;
        }

        
    }
}