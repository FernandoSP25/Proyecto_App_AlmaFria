using Proyecto_App_AlmaFria.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_App_AlmaFria.Services
{
	public interface INavigationService
	{
		Task NavigateToCreateAccountPage();
	}

	public class NavigationService : INavigationService
	{
		public async Task NavigateToCreateAccountPage()
		{
			await Application.Current.MainPage.Navigation.PushAsync(new CreateAccountPage());
		}
	}
}
