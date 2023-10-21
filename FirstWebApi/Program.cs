using BootCamp.FirstWebApi.Services;

var builder = WebApplication.CreateBuilder(args);
// kendi yazdığımız servisler bu alan içerisinde yer alacak
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
