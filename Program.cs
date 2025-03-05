using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using ProjectManagement.Repositories;
using ProjectManagement.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<ProjectRepository>();
builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<ServiceRepository>();


builder.Services.AddScoped<ProjectService>();  
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<ServiceService>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


