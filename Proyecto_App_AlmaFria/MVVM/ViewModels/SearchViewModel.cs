using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

		private ObservableCollection<ProductModel> _products;
		public ObservableCollection<ProductModel> Products
		{
			get => _products;
			set
			{
				SetProperty(ref _products, value);
			}
		}

		public ICommand SearchCommand { get; }
		public ICommand ProductTappedCommand { get; }

		public SearchViewModel()
		{
			// Crear algunos productos de prueba
			Products = new ObservableCollection<ProductModel>
			{
				new ProductModel { Id = 1, ProductName = "Producto 1", Description = "Descripción 1", Price = 10.0m },
				new ProductModel { Id = 2, ProductName = "Producto 2", Description = "Descripción 2", Price = 20.0m },
				new ProductModel { Id = 3, ProductName = "Producto 3", Description = "Descripción 3", Price = 30.0m },
                // Agrega más productos según lo necesites
            };
			SearchCommand = new RelayCommand(SearchProducts);
			ProductTappedCommand = new AsyncRelayCommand(ProductTapped);
		}

		private void SearchProducts()
		{
			if (string.IsNullOrWhiteSpace(_searchText))
			{
				// Restaurar la lista completa de productos si el texto de búsqueda está vacío
				Products = new ObservableCollection<ProductModel>
				{
					new ProductModel { Id = 1, ProductName = "Producto 1", Description = "Descripción 1", Price = 10.0m },
					new ProductModel { Id = 2, ProductName = "Producto 2", Description = "Descripción 2", Price = 20.0m },
					new ProductModel { Id = 3, ProductName = "Producto 3", Description = "Descripción 3", Price = 30.0m },
                    // Agrega más productos según lo necesites
                };
			}
			else
			{
				var filteredProducts = _products.Where(p => p.ProductName.ToUpper().Contains(_searchText.ToUpper())).ToList();
				Products = new ObservableCollection<ProductModel>(filteredProducts);
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
				await Shell.Current.GoToAsync("//ProductDetailPage", navigationParameter);
			}
		}
	}
}
