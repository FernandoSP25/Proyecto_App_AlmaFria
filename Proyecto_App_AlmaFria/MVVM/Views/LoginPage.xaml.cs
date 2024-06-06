namespace Proyecto_App_AlmaFria.Views;
using Proyecto_App_AlmaFria.MVVM.ViewModels;
using Microsoft.Maui.Storage;
using System.Windows.Input;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new LoginViewModel();
	}

   
	private void btnCreateAccount_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new CreateAccountPage());
	}
}