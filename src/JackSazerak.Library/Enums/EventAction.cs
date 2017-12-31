using System.ComponentModel;

namespace JackSazerak.Library.Enums
{
    public enum EventAction
    {
        PLAYER_MOVE_RIGHT,
        PLAYER_MOVE_LEFT,
        PLAYER_MOVE_UP,
        PLAYER_MOVE_DOWN,
        ERROR_WARNING,
        ERROR_CRITICAL,
        ERROR_INFO,
        [Description("Load Game - Get Games")]
        LOADGAME_GETGAMES,
        [Description("Load Game - Read Game")]
        LOADGAME_READINGGAME,
        SAVEGAME,
        HUMAN_MOVEMENT
    }
}