using BootCamp.FirstWebApi.Models;
using BootCamp.FirstWebApi.Services;
using BootCamp.FirstWebApi.Validations;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);
// kendi yazdığımız servisler bu alan içerisinde yer alacak
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Validation

builder.Services.AddScoped<IValidator<CategoryCreateInput>, CategoryCreateInputValidator>();
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

app.MapControllers();
app.Run();
