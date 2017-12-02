using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Managers;
using JackSazerak.UWP.Objects.Containers;
using JackSazerak.UWP.Objects.JSONObjects;

namespace JackSazerak.UWP.Objects
{
    public class Player : Tile
    {
        public Player(string spriteName, GameWrapper gameWrapper) : base(new LevelTile
        {
            TextureName = spriteName,
            TileType = TILE_TYPE.SPRITES
        }, gameWrapper)
        {
            EventManager.EventOccurred += EventManager_EventOccurred;
        }

        private void EventManager_EventOccurred(object sender, ACTION e)
        {
            switch (e)
            {
                case ACTION.PLAYER_MOVE_RIGHT:
                    UpdatePosition(30, 0);
                    break;
                case ACTION.PLAYER_MOVE_LEFT:
                    UpdatePosition(-30, 0);
                    break;
                case ACTION.PLAYER_MOVE_UP:
                    UpdatePosition(0, -30);
                    break;
                case ACTION.PLAYER_MOVE_DOWN:
                    UpdatePosition(0, 30);
                    break;
            }
        }
    }
}