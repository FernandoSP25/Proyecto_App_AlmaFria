using Proyecto_App_AlmaFria.Views;

namespace Proyecto_App_AlmaFria
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new LoginPage());

		}
	}
}
