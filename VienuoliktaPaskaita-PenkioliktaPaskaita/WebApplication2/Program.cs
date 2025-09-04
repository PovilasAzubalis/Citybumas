using _1PirmaUzduotis_AutomobiliuNuomaValdymasSuDB.Interfaces;
using _1PirmaUzduotis_AutomobiliuNuomaValdymasSuDB.Repositories;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IDatabaseRepository, DatabaseRepository>(_ => new DatabaseRepository("Data Source=DESKTOP-6FFNPQ7;Initial Catalog=automobiliuNuoma;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
