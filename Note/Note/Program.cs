using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Note.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Подключение локальной базы MS SQL server
// строка для подключения к базе
var connection = "Server=localhost;Database=NoteDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True";
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection)); // подключаем нашу базу данных

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Note}/{action=Index}");// при первом заходе будет загружаться эта страница
app.Run();