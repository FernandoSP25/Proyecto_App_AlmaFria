using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto_App_AlmaFria.Generic;
using Proyecto_App_AlmaFria.MVVM.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_App_AlmaFria.MVVM.ViewModels
{
	public class SearchViewModel : ObservableObject
	{
		private string _searchText;
		public string SearchText
		{
			get => _searchText;
			set
			{
				SetProperty(ref _searchText, value);
				SearchCommand.Execute(null); // Ejecuta el comando cuando cambia el texto
			}
		}

		private ProductModel _selectedProduct;
		public ProductModel SelectedProduct
		{
			get => _selectedProduct;
			set
			{
				SetProperty(ref _selectedProduct, value);
			}
		}

        private List<ProductModel> _products;

        public List<ProductModel> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }


        public ICommand SearchCommand { get; }
		public ICommand ProductTappedCommand { get; }

		public SearchViewModel()
		{
			_ = listarProductos();
			SearchCommand = new RelayCommand(SearchProducts);
			ProductTappedCommand = new AsyncRelayCommand(ProductTapped);

		}

		private async Task listarProductos()
		{
			try
			{
                var productos = await Http.GetAll<ProductModel>("https://almafriaproyect.azurewebsites.net/api/productos");
                Products = productos.Where(p => p.Categoria != 4).OrderBy(p => p.NombreProducto).ToList();

            }
            catch (Exception ex)
			{
				Console.WriteLine($"Error al listar productos: {ex.Message}");
			}
		}

		private void SearchProducts()
		{
			if (string.IsNullOrWhiteSpace(_searchText))
			{
				_ = listarProductos();
			}
			else
			{
				var filteredProducts = _products.Where(p => p.NombreProducto.ToUpper().Contains(_searchText.ToUpper())).ToList();
				Products = filteredProducts;
			}
		}

		private async Task ProductTapped()
		{
			if (SelectedProduct != null)
			{
				var navigationParameter = new Dictionary<string, object>
				{
					{ "Product", SelectedProduct }
				};
				await Shell.Current.GoToAsync("//MenuPage/SearchPage/ProductDetailPage", navigationParameter);
			}
		}
	}
}
