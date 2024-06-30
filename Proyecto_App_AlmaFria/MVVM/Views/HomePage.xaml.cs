using Proyecto_App_AlmaFria.MVVM.Models;
using Proyecto_App_AlmaFria.MVVM.ViewModels;

namespace Proyecto_App_AlmaFria.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

	private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
	{
		if (BindingContext is HomeViewModel viewModel && e.Item is ProductModel tappedProduct)
		{
			viewModel.SelectedProduct = tappedProduct;
			//viewModel.ProductTappedCommand.Execute(null);
		}
	}
}