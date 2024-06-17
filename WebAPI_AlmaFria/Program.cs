using Microsoft.EntityFrameworkCore;
using WebAPI_AlmaFria.Filter;
using WebAPI_AlmaFria.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PaleteriaDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}



app.MapGet("/api/productos", async (PaleteriaDbContext bd) =>
{
	return await bd.Productos.ToListAsync();
});

app.MapGet("/api/productos/{id}", async (int id, PaleteriaDbContext bd) =>
{
	var producto = await bd.Productos.FindAsync(id);
	if (producto == null)
	{
		return Results.NotFound();
	}
	return Results.Ok(producto);
}).AddEndpointFilter<FilterNumber>();


app.MapGet("/productos/buscarnombre/{nombreproducto}", async (string nombreproducto, PaleteriaDbContext bd) =>
{
	var productos = await bd.Productos
						   .Where(p => p.NombreProducto.ToUpper().Contains(nombreproducto.ToUpper()) && p.ActivoProducto.Contains("Suficiente"))
						   .ToListAsync();

	if (!productos.Any())
	{
		return Results.NoContent();
	}
	return Results.Ok(productos);
}).AddEndpointFilter<FilterEmpty>().AddEndpointFilter<FilterString>();



app.UseHttpsRedirection();
app.Run();


