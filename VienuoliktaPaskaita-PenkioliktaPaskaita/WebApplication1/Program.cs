using _1PirmaUzduotis_AutomobiliuNuomaValdymasSuDB.Interfaces;
using _1PirmaUzduotis_AutomobiliuNuomaValdymasSuDB.Repositories;
using _1PirmaUzduotis_AutomobiliuNuomaValdymasSuDB.Services;
using _1PirmaUzduotis_AutomobiliuNuomaValdymasSuDB.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IDatabaseRepository, DatabaseRepository>(_ => new DatabaseRepository("Data Source=DESKTOP-6FFNPQ7;Initial Catalog=automobiliuNuoma;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"));
builder.Services.AddTransient<INuomaService, NuomaService>();
builder.Services.AddSwaggerGen();
var app = builder.Build();

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
