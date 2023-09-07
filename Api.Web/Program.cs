using Api.BLL.Service;
using Api.DAL.DataContext;
using Api.DAL.Repository;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conexion SQL
builder.Services.AddDbContext<WebApiContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSql"));
});

// inyeccion de dependencias
builder.Services.AddScoped<IGenericRepository<Empleado>, EmpleadoRepository>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();


// Modificar Swagger
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1",
        new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "Sistema de Empleado API",
            Description = "La API de Sistema de Empleados es una interfaz diseñada " +
            "para gestionar de manera eficiente la información de los empleados en una organización. Esta API permite " +
            "realizar operaciones CRUD (Crear, Leer, Actualizar y Eliminar) sobre los registros de empleados almacenados " +
            "en una base de datos. Facilita la automatización de tareas relacionadas con la gestión de recursos humanos y " +
            "proporciona una forma segura y escalable de acceder a los datos de los empleados.",
            Version = "v1"
        });

    var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
    opt.IncludeXmlComments(filePath);
});

var app = builder.Build();

// Code First
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<WebApiContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
