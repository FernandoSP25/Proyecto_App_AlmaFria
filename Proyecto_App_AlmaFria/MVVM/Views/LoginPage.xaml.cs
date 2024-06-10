namespace Proyecto_App_AlmaFria.Views;
using Proyecto_App_AlmaFria.MVVM.ViewModels;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new LoginViewModel();
	}
}