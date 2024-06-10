using Proyecto_App_AlmaFria.MVVM.Models;
using Proyecto_App_AlmaFria.MVVM.ViewModels;

namespace Proyecto_App_AlmaFria.Views;

[QueryProperty(nameof(Product), "Product")]
public partial class ProductDetailPage : ContentPage
{
	private ProductModel _product;
	public ProductModel Product
	{
		get => _product;
		set
		{
			_product = value;
			BindingContext = new ProductDetailViewModel(_product);
		}
	}

	public ProductDetailPage()
	{
		InitializeComponent();
	}
}