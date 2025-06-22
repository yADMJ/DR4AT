using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TurismoApp.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TurismoAppContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login"; // Página padrão para login
    });

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Reservas");
    options.Conventions.AuthorizePage("/Index");      
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.Run();
