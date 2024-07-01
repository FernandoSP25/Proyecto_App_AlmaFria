using Proyecto_App_AlmaFria.MVVM.Views;

namespace Proyecto_App_AlmaFria.Views;

public partial class MenuPage : Shell
{
	public MenuPage()
	{
		InitializeComponent();

		Routing.RegisterRoute("ProductDetailPage", typeof(ProductDetailPage));
		Routing.RegisterRoute("CheckoutPage", typeof(CheckoutPage));
	}
}