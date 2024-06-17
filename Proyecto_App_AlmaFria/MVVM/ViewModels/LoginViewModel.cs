using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto_App_AlmaFria.Services;
using System.Windows.Input;
using Proyecto_App_AlmaFria.GoogleAuth;

namespace Proyecto_App_AlmaFria.MVVM.ViewModels
{

	public partial class LoginViewModel : ObservableObject
	{
	
		private readonly IGoogleAuthService _googleAuthService = new GoogleAuthService();


		public ICommand SigninCommand { get; }
		public ICommand SignupCommand { get; }

		public ICommand SigninGoogleCommand { get; }


		public LoginViewModel()
		{
			//_authService = authService;
			SigninCommand = new AsyncRelayCommand(Login);
			SignupCommand = new AsyncRelayCommand(Signup);
			SigninGoogleCommand = new AsyncRelayCommand(Login);
		}


		private async Task Login()
		{
			//var client = await _authService.Login(Email, Password);
			//if (client != null)
			//{
				//ErrorMessage = string.Empty; // Limpia cualquier mensaje de error previo
				await Shell.Current.GoToAsync("//MenuPage");
			//}
			//else
			//{
			//	// Manejar el fallo de login
			//	ErrorMessage = "Invalid email or password. Please try again.";
			//}
		}

		private async Task Signup()
		{
			await Shell.Current.GoToAsync("//CreateAccountPage");
		}

		private async Task LoginGoogle()
		{
			var loggedUser = await _googleAuthService.GetCurrentUserAsync();

		}
	}
}
