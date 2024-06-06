using Proyecto_App_AlmaFria.Services;
using Proyecto_App_AlmaFria.Views;

namespace Proyecto_App_AlmaFria
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			DependencyService.Register<INavigationService, NavigationService>();
			MainPage = new NavigationPage(new LoginPage());

		}
	}
}
