using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using Proyecto_App_AlmaFria.MVVM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_App_AlmaFria.MVVM.ViewModels
{
	public class ProductDetailViewModel : ObservableObject
	{
		public ICommand AgregarCommand { get; }
		public ICommand SumarEventCommand { get; }
		public ICommand RestarEventCommand { get; }

		private ProductModel _product;
		private List<CartItem> _listaCarrito;
		private int _cantidad;

		public ProductModel Product
		{
			get => _product;
			set => SetProperty(ref _product, value);
		}

		public int Cantidad
		{
			get => _cantidad;
			set => SetProperty(ref _cantidad, value);
		}

		public ProductDetailViewModel(ProductModel product)
		{
			Product = product;
			_listaCarrito = CargarCarrito();
			AgregarCommand = new AsyncRelayCommand(Agregar);
			SumarEventCommand = new RelayCommand(SumarCantidad);
			RestarEventCommand = new RelayCommand(RestarCantidad);
			Cantidad = 1; // Initial quantity
		}

		private List<CartItem> CargarCarrito()
		{
			if (Preferences.Get("carrito", "") == "")
			{
				return new List<CartItem>();
			}
			else
			{
				string valor = Preferences.Get("carrito", "");
				return JsonConvert.DeserializeObject<List<CartItem>>(valor);
			}
		}

		private async Task Agregar()
		{
			int id = Product.IdProductos;
			if (_listaCarrito.Where(p => p.ID == id).Count() > 0)
			{
				await App.Current.MainPage.DisplayAlert("ADVERTENCIA", $"El producto {Product.NombreProducto} ya fue agregado.", "OK");
				return;
			}

			var item = new CartItem
			{
				ID = Product.IdProductos,
				Nombre = Product.NombreProducto,
				Precio = Product.PrecioVenta,
				Imageurl = Product.Imageurl,
				Cantidad = Cantidad,
				StockActual = Product.StockActual,
				Total = Cantidad * Product.PrecioVenta
			};
			_listaCarrito.Add(item);
			Preferences.Set("carrito", JsonConvert.SerializeObject(_listaCarrito));
			await App.Current.MainPage.DisplayAlert("AGREGADO", $"El producto {Product.NombreProducto} ha sido agregado.", "OK");
		}

		private void SumarCantidad()
		{
			Cantidad++;
		}

		private void RestarCantidad()
		{
			if (Cantidad > 1)
				Cantidad--;
		}
	}
}
