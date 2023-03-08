using Domain.Interfaces;
using Infrastructure.DataAccess;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using AutoMapper;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Domain.Application;
using Infrastructure;
using Application.Middlewares;
using Domain.Application.Common.Mappings;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true
        };
    });

builder.Services.AddMvc();

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IApplicationDbContext).Assembly));
});

builder.Services.AddSingleton<IPasswordService, PasswordService>();
builder.Services.AddSingleton<ITokenService, TokenService>();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "OWC API",
        Description = "Online Web Constructions"
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseCustomExceptionHandler();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
