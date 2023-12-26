using Assignment_4.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    // Route for the About page
    endpoints.MapControllerRoute(
        name: "about",
        pattern: "Home/About",
        defaults: new { controller = "Home", action = "About" });
    
    // Route for the Work page
    endpoints.MapControllerRoute(
        name: "work",
        pattern: "Home/Work",
        defaults: new { controller = "Home", action = "Work" });
    
    // Route for the Category page
    endpoints.MapControllerRoute(
        name: "category",
        pattern: "Home/Category",
        defaults: new { controller = "Home", action = "Category" });
    
    
    // Route for the Sinup page
    endpoints.MapControllerRoute(
        name: "Signup",
        pattern: "Home/Signup",
        defaults: new { controller = "Home", action = "Signup" });
    
    // Route for the Login page
    endpoints.MapControllerRoute(
        name: "Login",
        pattern: "Home/Login",
        defaults: new { controller = "Home", action = "Login" });

    // Default route
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.Run();
