using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using RepositoryLayer.Context;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;

var logger = NLog.LogManager.Setup().LoadConfigurationFromFile("nlog.config").GetCurrentClassLogger();

try
{
    logger.Info("Starting application...");

    var builder = WebApplication.CreateBuilder(args);

    // Retrieve the database connection string
    var connectionString = builder.Configuration.GetConnectionString("SqlConnection");

    // Configure the application's DbContext to use SQL Server
    builder.Services.AddDbContext<HelloAppContext>(options =>
        options.UseSqlServer(connectionString));

    // Register services for dependency injection
    builder.Services.AddScoped<IRegisterHelloBL, RegisterHelloBL>();
    builder.Services.AddScoped<IRegisterHelloRL, RegisterHelloRL>();

    // Add controllers
    builder.Services.AddControllers();

    // Register Swagger for API documentation
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    var app = builder.Build();

    // Configure the HTTP request pipeline
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Application stopped due to an exception");
    throw;
}
finally
{
    LogManager.Shutdown(); 
}
