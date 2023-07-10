using Microsoft.EntityFrameworkCore;
using UBGWebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string dbConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];
builder.Services.AddDbContext<TestContext>(options =>
    options.UseSqlServer(dbConnectionString));


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{ 
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<TestContext>();
    TestDatabaseCommands.Test(context);
}

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
    }
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
