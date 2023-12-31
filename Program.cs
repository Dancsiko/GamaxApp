using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GamaxApp.Data;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<GamaxAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GamaxAppContext") ?? throw new InvalidOperationException("Connection string 'GamaxAppContext' not found.")));

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
app.UseAuthorization();
app.MapRazorPages();



app.Run();
