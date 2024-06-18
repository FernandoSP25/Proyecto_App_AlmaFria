using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto_App_AlmaFria.Services;
using System.Windows.Input;


namespace Proyecto_App_AlmaFria.MVVM.ViewModels
{

	public partial class LoginViewModel : ObservableObject
	{
	

		public ICommand SigninCommand { get; }
		public ICommand SignupCommand { get; }



		public LoginViewModel()
		{
			SigninCommand = new AsyncRelayCommand(Login);
			SignupCommand = new AsyncRelayCommand(Signup);

		}


		private async Task Login()
		{
				await Shell.Current.GoToAsync("//MenuPage");
		}

		private async Task Signup()
		{
			await Shell.Current.GoToAsync("//CreateAccountPage");
		}

	}
}
