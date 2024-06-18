using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_AlmaFria.Models;

public partial class PaleteriaDbContext : DbContext
{
    public PaleteriaDbContext()
    {
    }

    public PaleteriaDbContext(DbContextOptions<PaleteriaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Boletum> Boleta { get; set; }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Colaboradore> Colaboradores { get; set; }

    public virtual DbSet<ComprarInsumo> ComprarInsumos { get; set; }

    public virtual DbSet<DetalleIngrediente> DetalleIngredientes { get; set; }

    public virtual DbSet<DetallePreparacion> DetallePreparacions { get; set; }

    public virtual DbSet<DetallesPedido> DetallesPedidos { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Insumo> Insumos { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<MetodosPago> MetodosPagos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<UnidadesMedidum> UnidadesMedida { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Boletum>(entity =>
        {
            entity.HasKey(e => e.IdBoleta);

            entity.Property(e => e.IdBoleta)
                .ValueGeneratedNever()
                .HasColumnName("ID_Boleta");
            entity.Property(e => e.Dni)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DNI");
            entity.Property(e => e.FechaEmision).HasColumnName("Fecha_Emision");
            entity.Property(e => e.Hora)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IdPedido).HasColumnName("ID_Pedido");
            entity.Property(e => e.Igv).HasColumnName("IGV");
            entity.Property(e => e.NumeroCorrelativo)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Serie)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SubTotal).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(8, 2)");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.Boleta)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Boleta_Pedidos");
        });

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.IdCargo).HasName("PK__Cargo__8D69B95F908A4B14");

            entity.ToTable("Cargo");

            entity.Property(e => e.IdCargo).HasColumnName("ID_Cargo");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__02AA07851334C456");

            entity.Property(e => e.IdCategoria).HasColumnName("ID_Categoria");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__E005FBFFD4E2A82A");

            entity.Property(e => e.IdCliente).HasColumnName("ID_Cliente");
            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Ciudad).HasMaxLength(50);
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(10)
                .HasColumnName("Codigo_Postal");
            entity.Property(e => e.Contrasenia).HasMaxLength(50);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(50)
                .HasColumnName("Correo_Electronico");
            entity.Property(e => e.Direccion).HasMaxLength(100);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaNacimiento).HasColumnName("Fecha_Nacimiento");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(20)
                .HasColumnName("Numero_Documento");
            entity.Property(e => e.Sexo).HasMaxLength(20);
            entity.Property(e => e.Telefono).HasMaxLength(15);
            entity.Property(e => e.TipoDocumento).HasColumnName("Tipo_Documento");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.TipoDocumentoNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.TipoDocumento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Clientes__Tipo_D__160F4887");
        });

        modelBuilder.Entity<Colaboradore>(entity =>
        {
            entity.HasKey(e => e.IdColaborador).HasName("PK__Colabora__B5F19B9F0D313E23");

            entity.Property(e => e.IdColaborador).HasColumnName("ID_Colaborador");
            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Contrasenia).HasMaxLength(50);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(50)
                .HasColumnName("Correo_Electronico");
            entity.Property(e => e.FechaIngreso).HasColumnName("Fecha_Ingreso");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(20)
                .HasColumnName("Numero_Documento");
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.TipoDocumento).HasColumnName("Tipo_Documento");

            entity.HasOne(d => d.CargoNavigation).WithMany(p => p.Colaboradores)
                .HasForeignKey(d => d.Cargo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Colaborad__Cargo__17F790F9");

            entity.HasOne(d => d.TipoDocumentoNavigation).WithMany(p => p.Colaboradores)
                .HasForeignKey(d => d.TipoDocumento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Colaborad__Tipo___17036CC0");
        });

        modelBuilder.Entity<ComprarInsumo>(entity =>
        {
            entity.HasKey(e => e.IdCompraInsumos);

            entity.ToTable("Comprar_Insumos");

            entity.Property(e => e.IdCompraInsumos)
                .ValueGeneratedNever()
                .HasColumnName("ID_Compra_Insumos");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Estatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Hora)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IdInsumo).HasColumnName("ID_Insumo");
            entity.Property(e => e.IdProveedor).HasColumnName("ID_Proveedor");
            entity.Property(e => e.Total).HasColumnType("decimal(8, 2)");

            entity.HasOne(d => d.IdInsumoNavigation).WithMany(p => p.ComprarInsumos)
                .HasForeignKey(d => d.IdInsumo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comprar_Insumos_Insumos");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.ComprarInsumos)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comprar_Insumos_Proveedores");
        });

        modelBuilder.Entity<DetalleIngrediente>(entity =>
        {
            entity.HasKey(e => e.IdDetallesIngredientes);

            entity.ToTable("Detalle_Ingredientes");

            entity.Property(e => e.IdDetallesIngredientes)
                .ValueGeneratedNever()
                .HasColumnName("ID_Detalles_Ingredientes");
            entity.Property(e => e.Detalles).HasMaxLength(200);
            entity.Property(e => e.IdDetallePreparacion).HasColumnName("ID_Detalle_Preparacion");
            entity.Property(e => e.IdInsumo).HasColumnName("ID_Insumo");

            entity.HasOne(d => d.IdDetallePreparacionNavigation).WithMany(p => p.DetalleIngredientes)
                .HasForeignKey(d => d.IdDetallePreparacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Detalle_Ingredientes_Detalle_Ingredientes");

            entity.HasOne(d => d.IdInsumoNavigation).WithMany(p => p.DetalleIngredientes)
                .HasForeignKey(d => d.IdInsumo)
                .HasConstraintName("FK_Detalle_Ingredientes_Insumos");
        });

        modelBuilder.Entity<DetallePreparacion>(entity =>
        {
            entity.HasKey(e => e.IdDetallePreparacion);

            entity.ToTable("Detalle_Preparacion");

            entity.Property(e => e.IdDetallePreparacion)
                .ValueGeneratedNever()
                .HasColumnName("ID_Detalle_Preparacion");
            entity.Property(e => e.Detalles).HasMaxLength(100);
            entity.Property(e => e.IdProducto).HasColumnName("ID_Producto");
            entity.Property(e => e.TiempoDuracion).HasColumnName("Tiempo_duracion");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetallePreparacions)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Detalle_Preparacion_Productos");
        });

        modelBuilder.Entity<DetallesPedido>(entity =>
        {
            entity.HasKey(e => e.IdDetallesPedidos).HasName("PK__Detalles__84239FB06E0CFBC1");

            entity.ToTable("Detalles_pedidos");

            entity.Property(e => e.IdDetallesPedidos).HasColumnName("ID_Detalles_pedidos");
            entity.Property(e => e.IdPedido).HasColumnName("ID_Pedido");
            entity.Property(e => e.IdProducto).HasColumnName("ID_Producto");
            entity.Property(e => e.Observaciones).HasMaxLength(255);

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.DetallesPedidos)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalles___ID_Pe__151B244E");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetallesPedidos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalles___ID_Pr__14270015");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura);

            entity.ToTable("Factura");

            entity.Property(e => e.IdFactura)
                .ValueGeneratedNever()
                .HasColumnName("ID_Factura");
            entity.Property(e => e.DireccionFiscalEmisor)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DireccionFiscal_Emisor");
            entity.Property(e => e.FechaEmision).HasColumnName("Fecha_Emision");
            entity.Property(e => e.Hora)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IdPedidos).HasColumnName("ID_Pedidos");
            entity.Property(e => e.Igv).HasColumnName("IGV");
            entity.Property(e => e.NumeroCorrelativo)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.RazonSocialEmisor)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("RazonSocial_Emisor");
            entity.Property(e => e.RazonSocialReceptor)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("RazonSocial_Receptor");
            entity.Property(e => e.RucEmisor)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("RUC_Emisor");
            entity.Property(e => e.RucReceptor)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("RUC_Receptor");
            entity.Property(e => e.Serie)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SubTotal).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(8, 2)");

            entity.HasOne(d => d.IdPedidosNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdPedidos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_Pedidos");
        });

        modelBuilder.Entity<Insumo>(entity =>
        {
            entity.HasKey(e => e.IdInsumo).HasName("PK__Insumos__2C6ADA0740715BE0");

            entity.Property(e => e.IdInsumo).HasColumnName("ID_Insumo");
            entity.Property(e => e.Estado)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.NombreInsumo)
                .HasMaxLength(50)
                .HasColumnName("Nombre_insumo");
            entity.Property(e => e.PrecioCosto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Precio_Costo");
            entity.Property(e => e.StockActual).HasColumnName("Stock_Actual");
            entity.Property(e => e.StockMinimo).HasColumnName("Stock_Minimo");
            entity.Property(e => e.UnidadMedida).HasColumnName("Unidad_medida");

            entity.HasOne(d => d.UnidadMedidaNavigation).WithMany(p => p.Insumos)
                .HasForeignKey(d => d.UnidadMedida)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Insumos__Unidad___05D8E0BE");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.LoginId).HasName("PK__Login__4DDA2838A70D9468");

            entity.ToTable("Login");

            entity.Property(e => e.LoginId).HasColumnName("LoginID");
            entity.Property(e => e.DeviceInfo).HasMaxLength(256);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(45)
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsConnected).HasDefaultValue(true);
            entity.Property(e => e.LoginTimestamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LogoutTimestamp).HasColumnType("datetime");
            entity.Property(e => e.SessionToken).HasMaxLength(256);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Logins)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Login__UserID__06CD04F7");
        });

        modelBuilder.Entity<MetodosPago>(entity =>
        {
            entity.HasKey(e => e.IdMetodosPago).HasName("PK__Metodos___644E88AE9EFF9A2E");

            entity.ToTable("Metodos_pago");

            entity.Property(e => e.IdMetodosPago).HasColumnName("ID_Metodos_pago");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedidos).HasName("PK__Pedidos__5F47B6DF9BF951E2");

            entity.Property(e => e.IdPedidos).HasColumnName("ID_Pedidos");
            entity.Property(e => e.EstatusPedido)
                .HasMaxLength(50)
                .HasDefaultValue("proceso")
                .HasColumnName("Estatus_pedido");
            entity.Property(e => e.FechaHora)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_hora");
            entity.Property(e => e.MetodoPago).HasColumnName("Metodo_pago");

            entity.HasOne(d => d.ClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.Cliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pedidos__Cliente__0C85DE4D");

            entity.HasOne(d => d.MetodoPagoNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.MetodoPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pedidos__Metodo___0D7A0286");

            entity.HasOne(d => d.VendedorNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.Vendedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pedidos__Vendedo__0B91BA14");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProductos).HasName("PK__Producto__0CBA5DE9EC6E71FB");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("trg_InsertProductStatus");
                    tb.HasTrigger("trg_UpdateProductStatus");
                });

            entity.Property(e => e.IdProductos).HasColumnName("ID_Productos");
            entity.Property(e => e.ActivoProducto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(50)
                .HasColumnName("Nombre_producto");
            entity.Property(e => e.PrecioCosto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Precio_costo");
            entity.Property(e => e.PrecioPromocion)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Precio_promocion");
            entity.Property(e => e.PrecioVenta)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Precio_venta");
            entity.Property(e => e.StockActual).HasColumnName("Stock_actual");
            entity.Property(e => e.StockMinimo).HasColumnName("Stock_minimo");
            entity.Property(e => e.UnidadMedida).HasColumnName("Unidad_medida");

            entity.HasOne(d => d.CategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Categoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__Categ__10566F31");

            entity.HasOne(d => d.ProveedorNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Proveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__Prove__123EB7A3");

            entity.HasOne(d => d.UnidadMedidaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.UnidadMedida)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__Unida__114A936A");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK__Proveedo__7D65272FC5386782");

            entity.Property(e => e.IdProveedor).HasColumnName("ID_Proveedor");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(50)
                .HasColumnName("Correo_Electronico");
            entity.Property(e => e.Direccion).HasMaxLength(100);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(15);
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.IdTipoDocumento).HasName("PK__Tipo_Doc__AA551347A84751BD");

            entity.ToTable("Tipo_Documento");

            entity.Property(e => e.IdTipoDocumento).HasColumnName("ID_Tipo_Documento");
            entity.Property(e => e.Nombre).HasMaxLength(20);
        });

        modelBuilder.Entity<UnidadesMedidum>(entity =>
        {
            entity.HasKey(e => e.IdUnidadMedida).HasName("PK__Unidades__BDFE6A3DC3BFDE34");

            entity.ToTable("Unidades_Medida");

            entity.HasIndex(e => e.Simbolo, "UQ__Unidades__090D9EAC0257FBA1").IsUnique();

            entity.HasIndex(e => e.NombreUnidad, "UQ__Unidades__5CD4F3E4E1B3A372").IsUnique();

            entity.Property(e => e.IdUnidadMedida).HasColumnName("ID_Unidad_Medida");
            entity.Property(e => e.NombreUnidad)
                .HasMaxLength(50)
                .HasColumnName("Nombre_Unidad");
            entity.Property(e => e.Simbolo).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
