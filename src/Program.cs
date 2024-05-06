using System;

using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;

using Microsoft.EntityFrameworkCore;
using OdontoSchedule.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<DBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
        options.AccessDeniedPath = "/Home/AccessDenied/";
        options.LoginPath = "/Paciente/Login/";
    });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


if(!File.Exists("config.txt"))
{
    using (FileStream fs = File.Create("config.txt"))
    {
        Random rand = new Random();
        char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
        int senhaTamanho = 15;
        string senhaSecretaria = "";
        string senhaAdmin = "";
        byte[] conteudo;

        for(int i = 0; i < senhaTamanho; i++)
        {
            senhaSecretaria += chars[rand.Next(chars.Length)];
            senhaAdmin += chars[rand.Next(chars.Length)];
        }

        conteudo = new UTF8Encoding().GetBytes("admin=" + senhaAdmin + ";secretaria=" + senhaSecretaria);

        fs.Write(conteudo);

        Console.WriteLine("Administrador: admin\nSenha: " + senhaAdmin);
        Console.WriteLine("\nSecretaria: secretaria\nSenha: " + senhaSecretaria);
    }
}

app.Run();
