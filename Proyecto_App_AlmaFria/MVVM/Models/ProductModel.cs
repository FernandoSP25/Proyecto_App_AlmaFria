using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Proyecto_App_AlmaFria.MVVM.Models
{
	public class ProductModel
	{
        public int IdProductos { get; set; }

        public string NombreProducto { get; set; } = null!;

        public int Categoria { get; set; }

        public int Proveedor { get; set; }

        public decimal PrecioCosto { get; set; }

        public decimal PrecioVenta { get; set; }

        public bool Promocion { get; set; }

        public decimal? PrecioPromocion { get; set; }

        public int UnidadMedida { get; set; }

        public int StockActual { get; set; }

        public int StockMinimo { get; set; }

        public string? ActivoProducto { get; set; }

        public string? Imageurl { get; set; }

        //public virtual Categoria CategoriaNavigation { get; set; } = null!;

        //public virtual ICollection<DetallePreparacion> DetallePreparacions { get; set; } = new List<DetallePreparacion>();

        //public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; } = new List<DetallesPedido>();

        //public virtual Proveedore ProveedorNavigation { get; set; } = null!;

        //public virtual UnidadesMedidum UnidadMedidaNavigation { get; set; } = null!;

    }
}
