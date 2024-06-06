namespace Proyecto_App_AlmaFria.Views;
using Microsoft.Maui.Storage;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	private  void btnLogin_Clicked(object sender, EventArgs e)
	{


	}

	private void btnCreateAccount_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new CreateAccountPage());
	}
}