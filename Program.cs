using Microsoft.EntityFrameworkCore;
using TurismoApp.Data; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TurismoAppContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))); // ou InMemory

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
