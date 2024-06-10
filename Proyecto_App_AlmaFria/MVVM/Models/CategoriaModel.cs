﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_App_AlmaFria.MVVM.Models
{
    public class CategoriaModel
    {
		public int idCategoria { get; set; }
		public required string nombreCategoria { get; set; }
		public required string icon { get; set; }
	}
}