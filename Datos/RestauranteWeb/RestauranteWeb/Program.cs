var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// ⭐⭐⭐ CRÍTICO: Inicializar la cadena de conexión ANTES de construir la app ⭐⭐⭐
var connectionString = builder.Configuration.GetConnectionString("RestauranteConnectionString");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException(
        "No se encontró la cadena de conexión 'RestauranteConnectionString' en appsettings.json. " +
        "Por favor, verifique que el archivo appsettings.json tenga la sección ConnectionStrings correctamente configurada.");
}

// Inicializar el manager de conexiones
Datos.ConnectionStringManager.Initialize(connectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();