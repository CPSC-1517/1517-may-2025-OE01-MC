using WestWindApp.Components;

//Connect our Class Library
using WestWindSystem;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add our Database Connection String. This must be a connection string in appsettings.json.
var connectionString = builder.Configuration.GetConnectionString("WWDB");

//This passes our connection string to our services for use. Must be called before builder.Build();
builder.Services.WestWindExtensionServices(options => options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
