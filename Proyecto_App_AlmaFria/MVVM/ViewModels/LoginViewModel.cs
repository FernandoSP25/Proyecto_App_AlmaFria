using Proyecto_App_AlmaFria.MVVM.Models;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto_App_AlmaFria.Views;




namespace Proyecto_App_AlmaFria.MVVM.ViewModels
{

	public partial class LoginViewModel : ObservableObject
	{

		public LoginViewModel()
		{

		}

		[RelayCommand]
		async Task Signin() => await Shell.Current.GoToAsync("//MenuPage");
		 //void Signin() => Application.Current.MainPage = new MenuPage();


		[RelayCommand]
		 async Task Signup() => await Shell.Current.GoToAsync("//CreateAccountPage");

	}
}
