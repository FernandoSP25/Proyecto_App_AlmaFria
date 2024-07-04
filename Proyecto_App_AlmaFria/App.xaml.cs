
using Proyecto_App_AlmaFria.Views;


namespace Proyecto_App_AlmaFria
{
	public partial class App : Application
	{

		public App()
		{
			InitializeComponent();

			bool valor= Preferences.ContainsKey("usuario");

			if (valor)
			{
				MainPage = new MenuPage(); // Reemplaza MenuPage con tu página de menú
			}
			else
			{
				MainPage = new AppShell(); // Reemplaza LoginPage con tu página de inicio de sesión
			}

		}
	}
}
