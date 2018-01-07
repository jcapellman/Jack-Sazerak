using System.ComponentModel;

namespace JackSazerak.Library.Enums
{
    public enum ExceptionTypes
    {
        [Description("GameSaveManager::GetSavedGamesAsync - GetFilesAsync")]
        GAMESAVEMANAGER_LOADGAMES,
        [Description("GameSaveManager::GetSavedGamesAsync - ReadTextFileAsync")]
        GAMESAVEMANAGER_READGAME,
        [Description("GameSaveManager::SaveGameAsync - FileExistsAsync")]
        GAMESAVEMANAGER_SAVEGAME_ALREADY_EXISTS
    }
}