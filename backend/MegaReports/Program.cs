using MegaReports.data;
using ServerAsp.Data;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor de dependencias.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularClient",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddTransient<DatabaseManager>(sp =>  //Servicio de database manager 
{
    var sqlServerConnection = sp.GetRequiredService<SqlServerConnection>();
    return new DatabaseManager(sqlServerConnection.getConnectionString());
});

builder.Services.AddScoped<storedProcedure>(sp =>
{
    var sqlServerConnection = sp.GetRequiredService<SqlServerConnection>();  // servicio de sp
    return new storedProcedure(sqlServerConnection.getConnectionString());
});

// Registrar SqlServerConnection como servicio.
builder.Services.AddSingleton<MegaReports.data.SqlServerConnection>();
builder.Services.AddControllers();

var app = builder.Build();

// Configurar la canalización HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapControllers();

app.UseCors("AllowAngularClient");
app.Run();

