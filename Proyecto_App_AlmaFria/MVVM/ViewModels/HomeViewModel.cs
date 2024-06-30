using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Proyecto_App_AlmaFria.MVVM.Models;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Proyecto_App_AlmaFria.Generic;

namespace Proyecto_App_AlmaFria.MVVM.ViewModels
{
	public class HomeViewModel : ObservableObject
	{
		private string _nombreUsuario;
		public string NombreUsuario
		{
			get => _nombreUsuario;
			set => SetProperty(ref _nombreUsuario, value);
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

		private List<CategoriaModel> _categorias;

		public List<CategoriaModel> Categorias
		{
			get => _categorias;
			set => SetProperty(ref _categorias, value);
		}


		public ICommand ProductTappedCommand { get; }

		public HomeViewModel()
		{
			// Inicializa con datos de ejemplo
			NombreUsuario = "name";
			_ = listarCategorias();
			_= listarProductos();
			ProductTappedCommand = new AsyncRelayCommand(ProductTapped);
		}

		private async Task listarCategorias()
		{
			try
			{
				var categorias = await Http.GetAll<CategoriaModel>("https://almafriaproyect.azurewebsites.net/api/categoria");
				Categorias = categorias;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
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
