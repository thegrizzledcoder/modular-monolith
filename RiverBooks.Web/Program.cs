using System.Reflection;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using RiverBooks.Books.Application;
using RiverBooks.Users.Application;
using Serilog;

var logger = Log.Logger = new LoggerConfiguration()
  .Enrich.FromLogContext()
  .WriteTo.Console()
  .CreateLogger();

logger.Information("Starting web host");
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddFastEndpoints()
  .AddJWTBearerAuth(builder.Configuration["Auth:JwtSecret"]!)
  .AddAuthorization()
  .SwaggerDocument();

// Add Module Services
List<Assembly> mediatRAssemblies = [typeof(Program).Assembly];
builder.Services.AddBookService(builder.Configuration, logger, mediatRAssemblies);
builder.Services.AddUserModuleServices(builder.Configuration, logger, mediatRAssemblies);

// Set up MediatR
builder.Services.AddMediatR(cfg =>
  cfg.RegisterServicesFromAssemblies(mediatRAssemblies.ToArray()));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthentication()
  .UseAuthorization();

app.UseFastEndpoints()
  .UseSwaggerGen();

app.Run();

// Needed for testing
public partial class Program { };
