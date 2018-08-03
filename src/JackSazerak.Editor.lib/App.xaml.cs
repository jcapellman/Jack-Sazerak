using JackSazerak.Editor.lib.PlatformInterfaces;
using JackSazerak.Editor.lib.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace JackSazerak.Editor.lib
{
	public partial class App : Application
	{
	    private static void InitializeLocalization()
	    {
	        var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();

	        Resx.AppResources.Culture = ci;
	        DependencyService.Get<ILocalize>().SetLocale(ci);
	    }

        public App ()
		{
			InitializeComponent();

            InitializeLocalization();

			MainPage = new MainPage();
		}
	}
}