using MyOwnPortfolio.ApiService.Services.Interface;
using MyOwnPortfolio.ApiService.Services;
using MyOwnPortfolio.ApiService.Utility;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MyOwnPortfolio.ApiService;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.OpenApi.Models;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();
builder.Services.AddServiceDiscoveryCore();

// Add services to the container.
builder.Services.AddProblemDetails();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "MyOwnPortfolio API",
        Description = "An ASP.NET Core Web API for managing MyOwnPortfolio",
    });
    // Register the ExamplesOperationFilter
    // c.OperationFilter<ExamplesOperationFilter>();
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); // This line

    // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    // c.IncludeXmlComments(xmlPath);

    // Enable Swagger examples
    c.EnableAnnotations();
    c.ExampleFilters();
});

// Register Swashbuckle Filters
builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetExecutingAssembly());

// Global Exception Handling
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddScoped(typeof(IPortfolioService<>), typeof(PortfolioService<>));

builder.Services.AddDbContext<MyPortfolioDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyPortfolioSQLContext"))
           .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));

builder.Services.AddScoped<Utility>();
// Register AutoMapper
builder.Services.AddAutoMapper(typeof(MapperConfig).Assembly);


var app = builder.Build();

// Ensure the database is created
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MyPortfolioDbContext>();
    dbContext.Database.EnsureCreated();
    // dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseExceptionHandler();

app.MapDefaultEndpoints();
app.MapControllers();
app.Run();
