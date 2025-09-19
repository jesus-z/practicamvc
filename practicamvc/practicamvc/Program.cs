using Microsoft.EntityFrameworkCore;
using practicamvc.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuración del DbContext con cadena de conexión
builder.Services.AddDbContext<practicamvcContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("practicamvcContext")
        ?? throw new InvalidOperationException("Connection string 'practicamvcContext' not found.")
    ));

// Agregar servicios de controladores con vistas (MVC)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuración del pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configuración de las rutas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Ejecutar la aplicación
app.Run();
