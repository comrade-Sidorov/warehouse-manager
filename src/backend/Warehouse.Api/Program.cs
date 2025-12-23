using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Warehouse.BLL.Services.Impl;
using Warehouse.BLL.Services.Interfaces;
using Warehouse.DAL.Context;
using Warehouse.DAL.Entities;
using Warehouse.DAL.Repositories.Impl;
using Warehouse.DAL.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICommonRepository<Note>, CommonRepository<Note>>();
builder.Services.AddScoped<INoteService, NoteService>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

var connectionString = builder.Configuration.GetConnectionString("WarehouseConnection");
builder.Services.AddDbContext<WarehouseDbContext>(options => 
    options.UseNpgsql(connectionString).ConfigureWarnings(wc => wc.Ignore(RelationalEventId.PendingModelChangesWarning)));



// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddOpenApi();

var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    
// }

app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<WarehouseDbContext>();
        var pendingMigrations = context.Database.GetPendingMigrations();
        if(pendingMigrations.Any())
        {
            context.Database.Migrate(); // This applies any pending migrations
        }
        
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
        // Handle error appropriately, e.g., stop the application
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
