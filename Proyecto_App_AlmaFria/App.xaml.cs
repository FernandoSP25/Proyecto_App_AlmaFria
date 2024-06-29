using Proyecto_App_AlmaFria.Services;
using Proyecto_App_AlmaFria.Views;


namespace Proyecto_App_AlmaFria
{
	public partial class App : Application
	{
		private readonly UserSessionService _userSessionService;
		public App(UserSessionService userSessionService)
		{
			InitializeComponent();

			MainPage = new AppShell();

			_userSessionService = userSessionService;
			_userSessionService.LoadUserFromPreferences();

			if (_userSessionService.IsUserLoggedIn)
			{
				MainPage = new MenuPage();
			}
		}
	}
}
