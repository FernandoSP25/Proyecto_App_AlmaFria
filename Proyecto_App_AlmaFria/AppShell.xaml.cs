using Proyecto_App_AlmaFria.Views;

namespace Proyecto_App_AlmaFria
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{

			InitializeComponent();
			Routing.RegisterRoute("LoginPage/CreateAccountPage", typeof(CreateAccountPage));
		}
	}
}
