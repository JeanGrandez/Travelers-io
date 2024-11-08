using Microsoft.EntityFrameworkCore;
using TravelersIO.Shared.Domain.Repositories;
using TravelersIO.Shared.Infrastructure.Interfaces.ASP.Configuration;
using TravelersIO.Shared.Infrastructure.Persistence.EFC.Configuration;
using TravelersIO.Shared.Infrastructure.Persistence.EFC.Repositories;
using TravelersIO.Subscriptions.Application.Internal.CommandServices;
using TravelersIO.Subscriptions.Application.Internal.QueryServices;
using TravelersIO.Subscriptions.Domain.Repositories;
using TravelersIO.Subscriptions.Domain.Services;
using TravelersIO.Subscriptions.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Configure Lower Case URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Kebab Case Route Naming Convention

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());


// Add Database Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString is null)
    throw new Exception("Database connection string is not set.");

if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    });
else if (builder.Environment.IsProduction())
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseMySQL(connectionString);
    });


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPlansRepository, PlansRepository>();
builder.Services.AddScoped<IPlansCommandService, PlansCommandService>();
builder.Services.AddScoped<IPlansQueryService, PlansQueryService>();

//Igual

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();