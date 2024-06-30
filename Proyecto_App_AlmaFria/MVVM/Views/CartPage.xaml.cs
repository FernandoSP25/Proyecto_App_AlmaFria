using Proyecto_App_AlmaFria.MVVM.ViewModels;

namespace Proyecto_App_AlmaFria.Views
{
	public partial class CartPage : ContentPage
	{
		private readonly CartViewModel _viewModel;

		public CartPage()
		{
			InitializeComponent();
			_viewModel = new CartViewModel();
			BindingContext = _viewModel;
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			await _viewModel.ObtenerCarrito(); // Recargar los datos del carrito
		}
	}
}
