using MegaReports.data;
using Microsoft.OpenApi.Models;

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
    var sqlServerConnection = sp.GetRequiredService<SqlServerConnections>();
    return new DatabaseManager(sqlServerConnection.getConnectionString());
});

builder.Services.AddScoped<storedProcedure>(sp =>
{
    var sqlServerConnection = sp.GetRequiredService<SqlServerConnections>();  // servicio de sp
    return new storedProcedure(sqlServerConnection.getConnectionString());
});

// Registrar SqlServerConnection como servicio.
builder.Services.AddSingleton<MegaReports.data.SqlServerConnections>();
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi API", Version = "v1" });
});

var app = builder.Build();

// Configurar la canalización HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API V1");
        c.RoutePrefix = string.Empty;
    });
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapControllers();

app.UseCors("AllowAngularClient");
app.Run();

