using Microsoft.EntityFrameworkCore;
using Supabase;
using TaskManagerTest.Services; // Ensure this namespace is included

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure Supabase Client as Singleton
builder.Services.AddSingleton<Supabase.Client>(sp =>
{
    var supabaseUrl = builder.Configuration["Supabase:Url"];
    var supabaseKey = builder.Configuration["Supabase:Key"];

    var client = new Supabase.Client(supabaseUrl, supabaseKey);
    Task.Run(async () => await client.InitializeAsync()).Wait();
    return client;
});

// Register SupabaseService
builder.Services.AddSingleton<SupabaseService>();  // Ensure this line is present

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();  // Configure HSTS for production
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Map the default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
