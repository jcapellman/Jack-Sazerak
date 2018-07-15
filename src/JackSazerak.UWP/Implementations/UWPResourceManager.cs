using System;
using System.Threading.Tasks;
using Microsoft.Graphics.Canvas;

using JackSazerak.lib.BaseImplementations;

namespace JackSazerak.UWP.Implementations
{
    public class UWPResourceManager : BaseResourceManager
    {
        public class Texture
        {
            public byte[] arr;
        }

        public enum ResourceType
        {
            SPRITE,
            TEXTURE,
            SOUND
        }

        public async Task<Texture> LoadTextureAsync(string textureName, ResourceType resourceType)
        {
            var result = await CanvasBitmap.LoadAsync(null, new Uri($"ms-appx:///Assets/{resourceType}/{textureName}"));
            
            return new Texture();
        } 
    }
}