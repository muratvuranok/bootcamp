using BootCamp.FirstWebApi.Data;
using BootCamp.FirstWebApi.Models;
using BootCamp.FirstWebApi.Services;
using BootCamp.FirstWebApi.Validations;
using FluentValidation;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);
// kendi yazdığımız servisler bu alan içerisinde yer alacak


var allowedOrigins = "_bootcampOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedOrigins, policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5500");  // www.deneme.com
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
.AddDbContext<ApplicationDbContext>(options => options
    .UseSqlServer(builder.Configuration
        .GetConnectionString("default")));


// string fName = builder.Configuration["Educatior:FirstName"];
// string lName = builder.Configuration["Educatior:LasatName"];



// Validation

builder.Services.AddScoped<IValidator<CategoryCreateInput>, CategoryCreateInputValidator>();
builder.Services.AddTransient<IShipperService, ShipperService>();


// builder.Services.AddTransient<ICategoryService, CategoryService>();
// Database, Validation, AutoMapper, FulentMapping , Redis, RabbitMQ vs.... 

var app = builder.Build();
// eklenecek olan konfigurasyonlar bu alanda yer alacak
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
// app.UseAuthorization(); 
app.UseCors(allowedOrigins);
app.MapControllers();
app.Run();
