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


//PRODUCTOS 
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

//CATEGORIA
app.MapGet("/api/categoria", async (PaleteriaDbContext bd) =>
{
	return await bd.Categorias.ToListAsync();
});


//LOGIN

app.MapGet("/api/auth/login", async (string email, string password, PaleteriaDbContext bd) =>
{
	var user = await bd.Clientes
		.FirstOrDefaultAsync(u => u.CorreoElectronico == email && u.Contrasenia == password);

	if (user == null)
	{
		return Results.NotFound();
	}

	return Results.Ok(user);
});

app.MapPost("/api/auth/loginrecord", async (Login loginRecord, PaleteriaDbContext bd) =>
{
	// Verificar si el usuario ya tiene una sesión activa
	var activeSession = await bd.Logins
		.FirstOrDefaultAsync(l => l.UserId == loginRecord.UserId && l.IsConnected);

	if (activeSession != null)
	{
		return Results.Conflict(new { message = "User already logged in on another device." });
	}

	bd.Logins.Add(loginRecord);
	await bd.SaveChangesAsync();
	return Results.Ok(loginRecord.LoginId);
});


//REGISTRO
app.MapPost("/api/auth/register", async (Cliente user, PaleteriaDbContext bd) =>
{
	bd.Clientes.Add(user);
	await bd.SaveChangesAsync();
	return Results.Ok(user.IdCliente);
});


//Logout
app.MapPut("/api/auth/logout", async (int id, PaleteriaDbContext bd) =>
{
	var loginRecord = await bd.Logins
		.FirstOrDefaultAsync(l => l.UserId == id && l.IsConnected);
	if (loginRecord == null)
	{
		return Results.NotFound(new { message = "No active session found for the given LoginID." });
	}
	loginRecord.LogoutTimestamp = DateTime.Now;
	loginRecord.IsConnected = false;
	await bd.SaveChangesAsync();
	return Results.Ok(loginRecord.LoginId);
}); 


app.UseHttpsRedirection();
app.Run();


