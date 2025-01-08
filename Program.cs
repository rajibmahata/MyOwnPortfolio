using Microsoft.AspNetCore.Components.Web;
using MyOwnPortfolio.Components;
using MyOwnPortfolio.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddScoped<LayoutService>();
builder.Services.AddHttpClient<ApiService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7044/");
});

builder.Services.AddScoped<CustomAuthenticationStateProvider>();

builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.SetMinimumLevel(LogLevel.Debug);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.MapBlazorHub();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
