using System.Globalization;

namespace JackSazerak.Editor.lib.PlatformInterfaces
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();

        void SetLocale(CultureInfo ci);
    }
}