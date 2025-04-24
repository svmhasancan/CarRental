using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Core.DependencyResolvers;
using System.Diagnostics;
using Core.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<ICarService, CarManager>();
//builder.Services.AddSingleton<ICarDal, EfCarDal>();

//builder.Services.AddSingleton<IBrandService, BrandManager>();
//builder.Services.AddSingleton<IBrandDal, EfBrandDal>();

//builder.Services.AddSingleton<IColorService, ColorManager>();
//builder.Services.AddSingleton<IColorDal, EfColorDal>();

//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(options =>
{
    options.RegisterModule(new AutofacBusinessModule());
});


var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();


builder.Services.AddCors();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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

        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine($"JWT Authentication Failed: {context.Exception.Message}");
                Debug.WriteLine(context.Exception.Message.ToString());
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureCustomExceptionMiddleware();

app.UseCors(builder => 
    builder.WithOrigins("http://localhost:4200/")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin()
);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
