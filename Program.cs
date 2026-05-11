using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CoolEStore.Data;
using CoolEStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CoolEStore.DTOs;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("AppDbContext") 
        ?? 
        throw new InvalidOperationException("Connection string 'AppDbContext' not found.")
));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Authentication
builder.Services.AddAuthentication();

// Add Identity APIs
builder.Services
    .AddIdentityApiEndpoints<ApplicationUserModel>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seed Database
using (var appDbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>())
{
    appDbContext.Database.EnsureCreated();
}

if(app.Environment.IsDevelopment())
{
    app.UseSwagger().UseSwaggerUI();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.MapPost("/register", async (
    UserManager<ApplicationUserModel> userManager,
    [FromBody] CustomRegisterRequest request) =>
{
    var user = new ApplicationUserModel
    {
        UserName = request.UserName,
        Email = request.Email,
        PhoneNumber = request.PhoneNumber,
        Address = request.Address,
        CAP = request.CAP,
        StreetNumber = request.StreetNumber
    };

    var result = await userManager.CreateAsync(user, request.Password);

    return result.Succeeded
        ? Results.Ok(new { Message = "User created" })
        : Results.BadRequest(result.Errors);
});

app.MapGroup("/identity-api").MapIdentityApi<ApplicationUserModel>();

app.Run();
