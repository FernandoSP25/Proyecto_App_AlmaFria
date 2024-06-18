using Proyecto_App_AlmaFria.Views;
using System.Globalization;

namespace Proyecto_App_AlmaFria
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			MainPage = new AppShell();
		}
	}
}
