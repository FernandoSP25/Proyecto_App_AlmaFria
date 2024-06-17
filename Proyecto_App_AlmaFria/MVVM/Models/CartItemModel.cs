using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_App_AlmaFria.MVVM.Models
{
	public class CartItem : ObservableObject
	{
		private int _id;
		public int Id
		{
			get => _id;
			set => SetProperty(ref _id, value);
		}

		private string _productName;
		public string ProductName
		{
			get => _productName;
			set => SetProperty(ref _productName, value);
		}

		private string _description;
		public string Description
		{
			get => _description;
			set => SetProperty(ref _description, value);
		}

		private decimal _price;
		public decimal Price
		{
			get => _price;
			set => SetProperty(ref _price, value);
		}

		private string _image;
		public string Image
		{
			get => _image;
			set => SetProperty(ref _image, value);
		}

		private int _quantity;
		public int Quantity
		{
			get => _quantity;
			set => SetProperty(ref _quantity, value);
		}
	}
}
