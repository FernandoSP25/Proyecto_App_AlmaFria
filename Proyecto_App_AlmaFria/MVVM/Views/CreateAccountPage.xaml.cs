using Proyecto_App_AlmaFria.MVVM.ViewModels;
namespace Proyecto_App_AlmaFria.Views;

public partial class CreateAccountPage : ContentPage
{
	public CreateAccountPage()
	{
		InitializeComponent();
		BindingContext = new CreateAccountViewModel();
	}

}