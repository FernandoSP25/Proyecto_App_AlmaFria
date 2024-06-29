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
				if (value != null)
				{
					ProductSelectedCommand.Execute(value);
				}
			}
		}

		private List<CategoriaModel> _categorias;

		public List<CategoriaModel> Categorias
		{
			get => _categorias;
			set => SetProperty(ref _categorias, value);
		}


		public ICommand ProductSelectedCommand { get; }

		public HomeViewModel()
		{
			// Inicializa con datos de ejemplo
			NombreUsuario = "name";
			_ = listarCategorias();
			ProductSelectedCommand = new AsyncRelayCommand<ProductModel>(ProductSelected);
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

		private async Task ProductSelected(ProductModel selectedProduct)
		{
			if (selectedProduct != null)
			{
				var navigationParameter = new Dictionary<string, object>
				{
					{ "Product", selectedProduct }
				};
				await Shell.Current.GoToAsync("//MenuPage/SearchPage/ProductDetailPage", navigationParameter);
			}
		}
	}
}
