using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Proyecto_App_AlmaFria.MVVM.Models;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

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

		public ObservableCollection<CategoriaModel> Categorias { get; }
		public ObservableCollection<ProductModel> ProductosPopulares { get; }

		public ICommand ProductSelectedCommand { get; }

		public HomeViewModel()
		{
			// Inicializa con datos de ejemplo
			NombreUsuario = "name";

			Categorias = new ObservableCollection<CategoriaModel>
			{
				new CategoriaModel { NombreCategoria = "Helados", Icon = "helado_ico.png" },
				new CategoriaModel { NombreCategoria = "Paletas", Icon = "paleta_ico.png" },
				new CategoriaModel { NombreCategoria = "Postres", Icon = "ico_p_relleno.png"},
				new CategoriaModel { NombreCategoria = "Pasteles", Icon = "helado_ico.png" }
                // Agrega más categorías según lo necesites
            };

			ProductosPopulares = new ObservableCollection<ProductModel>
			{
				new ProductModel { ProductName = "Helado de Chocolate", Image = "pcr_chocolate.jpg" },
				new ProductModel { ProductName = "Paleta de Fresa", Image = "fresa_paleta.jpg" },
				new ProductModel { ProductName = "Pastel de Chocolate", Image = "frutti_bite.jpg" }
                // Agrega más productos según lo necesites
            };

			ProductSelectedCommand = new AsyncRelayCommand<ProductModel>(ProductSelected);
		}

		private async Task ProductSelected(ProductModel selectedProduct)
		{
			if (selectedProduct != null)
			{
				var navigationParameter = new Dictionary<string, object>
				{
					{ "Product", selectedProduct }
				};
				await Shell.Current.GoToAsync("//ProductDetailPage", navigationParameter);
			}
		}
	}
}
