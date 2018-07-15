using System;

using JackSazerak.lib.Enums;

namespace JackSazerak.lib.Objects
{
    public class ResourceObject
    {
        public Guid GUID { get; private set; }

        public ResourceTypes ResourceType { get; set; }

        public Object Resource { get; set; }

        public string FileName { get; set; }

        public ResourceObject(string fileName, ResourceTypes resourceType)
        {
            GUID = Guid.NewGuid();

            FileName = fileName;
            ResourceType = resourceType;
        }
    }
}