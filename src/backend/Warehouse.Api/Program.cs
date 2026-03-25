using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Warehouse.Api;

const string AUTH = "Bearer";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = AUTH
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddAuthentication(AUTH).AddJwtBearer(AUTH, options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["ApiSettings:Issuer"],
        ValidAudience = builder.Configuration["ApiSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["ApiSettings:Secret"]!))
    };
});

builder.Services.AddAuthorization();
builder.Services.AddScoped<TokenService>();

builder.Services.AddControllers();
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

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
//app.MapSwagger().RequireAuthorization();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
