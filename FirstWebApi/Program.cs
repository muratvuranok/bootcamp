using BootCamp.FirstWebApi.Validations;
using BootCamp.SeedData;
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




builder.Services.AddAutoMapper(typeof(Program));






// string fName = builder.Configuration["Educatior:FirstName"];
// string lName = builder.Configuration["Educatior:LasatName"];



// Validation

builder.Services.AddScoped<IValidator<CategoryCreateInput>, CategoryCreateInputValidator>();


builder.Services.AddTransient(typeof(IService<,>), typeof(Service<,>));
builder.Services.AddTransient<IShipperService, ShipperService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();


// builder.Services.AddTransient<ICategoryService, CategoryService>();
// Database, Validation, AutoMapper, FulentMapping , Redis, RabbitMQ vs.... 

var app = builder.Build();
// eklenecek olan konfigurasyonlar bu alanda yer alacak

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    CustomerSeedData.Initialize(services);
}

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


/*
 select * from Customers

delete from Customers where Mail in (

'charles.wilson@example.com',
'sarah.brown@example.com',
'william.rodriguez@example.com',
'robert.smith@example.com',
'susan.smith@example.com',
'mary.jackson@example.com'

)


select top 10  'new() { Id = Guid.Parse("'+CAST(Id as nvarchar(100))+'"), FirstName = "'+FirstName+'", LastName = "'+LastName+'", Mail ="'+Mail+'", Phone = "'+Phone+'" },' from Customers

truncate table Customers



 
 */