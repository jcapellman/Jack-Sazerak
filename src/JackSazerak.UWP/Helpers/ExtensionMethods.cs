using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace JackSazerak.UWP
{
    public static class ExtensionMethods
    {
        public static string GetDescription<T>(this T enumerationValue) where T : struct => 
            typeof(T).GetMember(enumerationValue.ToString())
                .SelectMany(a => a.GetCustomAttributes<DescriptionAttribute>(false), (a, b) => b.Description)
                .FirstOrDefault() ?? enumerationValue.ToString();
    }
}