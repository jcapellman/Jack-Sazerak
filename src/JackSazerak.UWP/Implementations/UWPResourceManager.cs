using System;

using JackSazerak.lib.BaseImplementations;
using JackSazerak.lib.Enums;

namespace JackSazerak.UWP.Implementations
{
    public class UWPResourceManager : BaseResourceManager
    {
        public event EventHandler<string> OnTextureLoadRequest;

        public void LoadTexture(string textureName, ResourceTypes resourceType)
        {
            OnTextureLoadRequest?.Invoke(null, textureName);
        } 
    }
}