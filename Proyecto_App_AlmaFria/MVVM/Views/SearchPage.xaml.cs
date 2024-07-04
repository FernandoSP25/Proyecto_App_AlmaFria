using Proyecto_App_AlmaFria.MVVM.Models;
using Proyecto_App_AlmaFria.MVVM.ViewModels;
namespace Proyecto_App_AlmaFria.Views;

public partial class SearchPage : ContentPage
{
	public SearchPage()
	{
		InitializeComponent();
	}

	private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
	{
		if (BindingContext is SearchViewModel viewModel && e.Item is ProductModel tappedProduct)
		{
			viewModel.SelectedProduct = tappedProduct;
			viewModel.ProductTappedCommand.Execute(null);
		}
	}
}