using Proyecto_App_AlmaFria.MVVM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_App_AlmaFria.MVVM.ViewModels
{
    public class CategoriaViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private List<CategoriaModel> _lista;

		public List<CategoriaModel> Lista
		{
			get
			{
				return _lista;
			}
			set
			{
				//SetValue(ref _lista, value);
			}
		}
	}
}
