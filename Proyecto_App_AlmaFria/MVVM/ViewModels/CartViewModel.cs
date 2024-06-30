using Proyecto_App_AlmaFria.MVVM.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Proyecto_App_AlmaFria.MVVM.ViewModels
{
	public class CartViewModel : ObservableObject
	{
		private ObservableCollection<CartItem> _cartItems;
		public ObservableCollection<CartItem> CartItems
		{
			get => _cartItems;
			set => SetProperty(ref _cartItems, value);
		}

		public decimal Subtotal => CartItems.Sum(item => item.Precio * item.Cantidad);
		public decimal Total => Subtotal; // Asumiendo que no hay otros cargos

		public ICommand IncrementCommand { get; }
		public ICommand DecrementCommand { get; }

		public CartViewModel()
		{
			CartItems = new ObservableCollection<CartItem>();
			IncrementCommand = new RelayCommand<CartItem>(IncrementQuantity);
			DecrementCommand = new RelayCommand<CartItem>(DecrementQuantity);
		}

		public async Task ObtenerCarrito()
		{
			var items = CargarCarrito().Select(product => new CartItem
			{
				ID = product.IdProductos,
				Nombre = product.NombreProducto,
				Precio = product.PrecioVenta,
				StockActual = product.StockActual,
				Imageurl = product.Imageurl,
				Cantidad = 1
			}).ToList();

			CartItems = new ObservableCollection<CartItem>(items);
		}

		private List<ProductModel> CargarCarrito()
		{
			if (Preferences.Get("carrito", "") == "")
			{
				return new List<ProductModel>();
			}
			else
			{
				string valor = Preferences.Get("carrito", "");
				return JsonConvert.DeserializeObject<List<ProductModel>>(valor);
			}
		}

		private void IncrementQuantity(CartItem item)
		{
			if (item.Cantidad < item.StockActual)
			{
				item.Cantidad++;
				OnPropertyChanged(nameof(Subtotal));
				OnPropertyChanged(nameof(Total));
			}
		}

		private void DecrementQuantity(CartItem item)
		{
			if (item.Cantidad > 0)
			{
				item.Cantidad--;
				OnPropertyChanged(nameof(Subtotal));
				OnPropertyChanged(nameof(Total));
			}
		}
	}
}
