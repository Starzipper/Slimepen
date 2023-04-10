using Slimepen.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews(); // Use AddControllersWithViews() instead of AddControllers()
builder.Services.AddSingleton<ISlimeRepository, SlimeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles(); // Add this line to serve static files like CSS and JavaScript

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=SlimePen}/{action=Index}/{id?}");
    endpoints.MapRazorPages(); // Add this line for Razor Pages
});

app.Run();
