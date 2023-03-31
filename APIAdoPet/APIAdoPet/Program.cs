using APIAdoPet.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
#region Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
         options.JsonSerializerOptions
            .ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();

//Informações Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "REST API ADOPET",
            Version = "v1",
            Description = "Adote seu pet de forma responsável",
            Contact = new OpenApiContact
            {
                Name = "Jucimario",
                Url = new Uri("https://github.com/jucimario")
            }
        });
});

//Inicio - conexão banco de dados MYSQL
string mySqlConnection = builder.Configuration["ConnectionStrings:MySQLConnectionString"];

builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseMySql(mySqlConnection,
                    ServerVersion.AutoDetect(mySqlConnection)));

//Fim - conexão banco de dados MYSQL

//Inicio - Configuracao AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// - Configuracao AutoMapper

#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
#region Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

#endregion

app.Run();

