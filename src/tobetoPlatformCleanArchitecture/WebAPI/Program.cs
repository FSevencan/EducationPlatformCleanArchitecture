using Application;


using Core.Security;
using Core.Security.Encryption;
using Core.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistence;
using Swashbuckle.AspNetCore.SwaggerUI;
using WebAPI;
using Microsoft.Extensions.DependencyInjection;
using Core.CrossCuttingConcerns.Exceptions.Types;
using System.Text.Json;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddSecurityServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();


const string tokenOptionsConfigurationSection = "TokenOptions";
TokenOptions tokenOptions = builder.Configuration.GetSection(tokenOptionsConfigurationSection).Get<TokenOptions>()
    ?? throw new InvalidOperationException($"\"{tokenOptionsConfigurationSection}\" section cannot found in configuration.");

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

builder.Services.AddDistributedMemoryCache(); // InMemory

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        opt.DocExpansion(DocExpansion.None);
    });
    app.UseDeveloperExceptionPage();
}
else
{

    app.UseExceptionHandler(appError =>
    {
        appError.Run(async context =>
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
            if (contextFeature != null)
            {
                Console.WriteLine($"Something went wrong: {contextFeature.Error}");

                var message = "Internal Server Error. Please try again later.";
                var statusCode = context.Response.StatusCode;

                if (contextFeature.Error is BusinessException businessException)
                {
                    message = businessException.Message;
                    statusCode = StatusCodes.Status400BadRequest;
                    context.Response.StatusCode = statusCode;
                }

                await context.Response.WriteAsync(JsonSerializer.Serialize(new
                {
                    StatusCode = statusCode,
                    Message = message
                }));
            }
        });
    });
}
app.UseHttpsRedirection();

app.UseRouting();


app.UseCors(policy =>
    policy.WithOrigins("http://localhost:3000", "https://tobeto.fatihsevencan.com" )
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
