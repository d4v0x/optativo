using FluentValidation;
using FluentValidation.AspNetCore;
using Repository.Datos;
using Services.Logica;
using Services.Validators;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Registrar Swagger

// Configurar el contexto de la base de datos
var connectionString = builder.Configuration.GetConnectionString("postgres");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<ICliente, ClienteRepository>();
builder.Services.AddScoped<IFactura, FacturaRepository>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<FacturaService>();

builder.Services.AddTransient<IValidator<ClienteModel>, ClienteValidator>();
builder.Services.AddTransient<IValidator<FacturaModel>, FacturaValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger(); // Habilitar Swagger
    app.UseSwaggerUI(); // Habilitar Swagger UI
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
