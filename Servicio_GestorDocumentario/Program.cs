using Application.Services;
using Domain.Interfaces;
using Domain.Models;
using Infraestructure.Data;
using Infraestructure.Repository;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Servicio_GestorDocumentario.Custom;
using System;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using Application.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Gestor2Context>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<Utilitarios>();
builder.Services.AddMapster();
MasterConfig.RegisterMappings();
//builder.Services.AddSingleton(TypeAdapterConfig.GlobalSettings);
//builder.Services.AddScoped<IMapper, ServiceMapper>();
builder.Services.AddAuthentication(config => {
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]!))
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// Agrega servicios y controladores
builder.Services.AddAuthorization();
//Usuarios
builder.Services.AddScoped<IGestorUsuariosService, GestorUsuariosService>();
builder.Services.AddScoped<IGestorUsuariosRepository, GestorUsuariosRepository>();


//Proveedor
builder.Services.AddScoped<IGestorProveedorService, GestorProveedorService>();
builder.Services.AddScoped<IGestorProveedorRepository, GestorProveedorRepository>();

//Colaboradores
builder.Services.AddScoped<IColaboradoresService, ColaboradoresService>();
builder.Services.AddScoped<IColaboradoresRepository, ColaboradoresRepository>();

//Vehiculos
builder.Services.AddScoped<IGestorVehiculosService, GestorVehiculosService>();
builder.Services.AddScoped<IGestorVehiculosRepository, GestorVehiculosRepository>();

//Trabajos

builder.Services.AddScoped<IGestorTrabajosService, GestorTrabajosService>();
builder.Services.AddScoped<IGestorTrabajosRepository, GestorTrabajosRepository>();
//builder.Services.AddAut(typeof(Startup));
builder.Services.AddControllers()
       .AddJsonOptions(options =>
       {
           options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
       });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    
    app.UseSwaggerUI();
    //app.UseSwagger(c =>
    //{
    //    c.("v1", new OpenApiInfo
    //    {
    //        Version = "v1",
    //        Title = "API de Colaboradores",
    //        Description = "Documentación de la API de Colaboradores"
    //    });

    //    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //    c.IncludeXmlComments(xmlPath);
    //});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
