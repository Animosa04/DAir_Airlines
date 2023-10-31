using Microsoft.EntityFrameworkCore;
using Infrastructure.Database;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using System.Text.Json;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks()
    .AddDbContextCheck<DAirDatabaseContext>("Database");
builder.Services.AddDbContext<DAirDatabaseContext>(options => options.UseSqlServer("Server=localhost;Database=YourDatabaseName;User Id=DAir;Password=DAirAirlines123!;Trusted_Connection=False;Encrypt=False;"));
//builder.Services.AddDbContext<DAirDatabaseContext>(options => options.UseSqlServer("Server=localhost;Database=YourDatabaseName;User Id=dd;Password=dd;Trusted_Connection=False;Encrypt=False;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHealthChecks("/health", new HealthCheckOptions
{
    Predicate = (check) => check.Tags.Contains("ready"),
    ResponseWriter = async (context, report) =>
    {
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(JsonSerializer.Serialize(report));
    }
});

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DAirDatabaseContext>();
    dbContext.Database.EnsureCreated();
    DatabaseSeeder.Seed(dbContext);
}

app.Run();

