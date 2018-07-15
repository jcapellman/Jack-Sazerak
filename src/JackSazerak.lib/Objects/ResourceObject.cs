using JackSazerak.lib.Enums;

namespace JackSazerak.lib.Objects
{
    public class ResourceObject
    {
        public ResourceTypes ResourceType { get; private set; }

        public object Resource { get; set; }

        public string FileName { get; private set; }

        public ResourceObject(string fileName, ResourceTypes resourceType)
        {
            FileName = fileName;
            ResourceType = resourceType;
        }
    }
}