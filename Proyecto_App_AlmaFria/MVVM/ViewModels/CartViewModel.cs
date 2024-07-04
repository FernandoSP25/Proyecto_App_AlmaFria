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

		//public decimal Subtotal => CartItems.Sum(item => item.Precio * item.Cantidad);
		//public decimal IGV => Subtotal * 0.18m; // Assuming 18% IGV
		public decimal Total => CartItems.Sum(item => item.Precio * item.Cantidad);

		public ICommand IncrementCommand { get; }
		public ICommand DecrementCommand { get; }
		public ICommand EliminarEventCommand { get; }
		public ICommand CheckoutCommand { get; }

		public CartViewModel()
		{
			CartItems = new ObservableCollection<CartItem>();
			IncrementCommand = new RelayCommand<CartItem>(IncrementQuantity);
			DecrementCommand = new RelayCommand<CartItem>(DecrementQuantity);
			EliminarEventCommand = new RelayCommand<CartItem>(EliminarItem);
			InitializeAsync().ConfigureAwait(false);
			CheckoutCommand = new AsyncRelayCommand(Checkout);
		}

		public async Task InitializeAsync()
		{
			await ObtenerCarrito();
			OnPropertyChanged(nameof(Total));
		}

		public async Task ObtenerCarrito()
		{
			var items = CargarCarrito().Select(product => new CartItem
			{
				ID = product.ID,
				Nombre = product.Nombre,
				Precio = product.Precio,
				StockActual = product.StockActual,
				Imageurl = product.Imageurl,
				Cantidad = product.Cantidad,
				Total = product.Total
			}).ToList();

			CartItems = new ObservableCollection<CartItem>(items);
			OnPropertyChanged(nameof(Total));
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

		private void IncrementQuantity(CartItem item)
		{
			if (item.Cantidad < item.StockActual)
			{
				item.Cantidad++;
				GuardarCarrito();
				OnPropertyChanged(nameof(Total));
			}
		}

		private void DecrementQuantity(CartItem item)
		{
			if (item.Cantidad > 0)
			{
				item.Cantidad--;
				GuardarCarrito();

				OnPropertyChanged(nameof(Total));
			}
		}

		private void EliminarItem(CartItem item)
		{
			CartItems.Remove(item);
			GuardarCarrito();
			//OnPropertyChanged(nameof(Subtotal));
			//OnPropertyChanged(nameof(IGV));
			OnPropertyChanged(nameof(Total));
		}

		private void GuardarCarrito()
		{
			Preferences.Set("carrito", JsonConvert.SerializeObject(CartItems.ToList()));
		}

		private async Task Checkout()
		{
			await Shell.Current.GoToAsync("//MenuPage/CheckoutPage");
		}
	}

}
