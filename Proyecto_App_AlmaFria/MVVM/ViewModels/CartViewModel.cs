using Proyecto_App_AlmaFria.MVVM.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Proyecto_App_AlmaFria.MVVM.ViewModels
{
	public class CartViewModel : ObservableObject
	{
		private List<CartItem> _cartItems;
		public List<CartItem> CartItems
		{
			get => _cartItems;
			set => SetProperty(ref _cartItems, value);
		}

		public decimal Subtotal => CartItems.Sum(item => item.Price * item.Quantity);
		public decimal Total => Subtotal; // Asumiendo que no hay otros cargos

		public ICommand IncrementCommand { get; }
		public ICommand DecrementCommand { get; }

		public CartViewModel()
		{
			CartItems = new List<CartItem>
			{
				new CartItem { Id = 1, ProductName = "Dream Cone", Description = "Nutella, cocoa & salted caramel", Price = 12.60m, Quantity = 2, Image = "dream_cone.png" },
				new CartItem { Id = 2, ProductName = "Berry-Licious", Description = "Berry compote & raspberry coulis", Price = 14.60m, Quantity = 1, Image = "berry_licious.png" },
				new CartItem { Id = 3, ProductName = "The O.G.", Description = "Cinnamon sugar cone & strawberry", Price = 11.60m, Quantity = 1, Image = "the_og.png" }
			};

			IncrementCommand = new RelayCommand<CartItem>(IncrementQuantity);
			DecrementCommand = new RelayCommand<CartItem>(DecrementQuantity);
		}

		private void IncrementQuantity(CartItem item)
		{
			item.Quantity++;
			OnPropertyChanged(nameof(Subtotal));
			OnPropertyChanged(nameof(Total));
		}

		private void DecrementQuantity(CartItem item)
		{
			if (item.Quantity > 0)
			{
				item.Quantity--;
				OnPropertyChanged(nameof(Subtotal));
				OnPropertyChanged(nameof(Total));
			}
		}
	}
}
