namespace BootCamp.FirstWebApi.Models;

public class Product : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public short UnitsInStock { get; set; }
    public decimal UnitPrice { get; set; }

    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
}


// AddTransient  -> her istek için yeni bir servis oluşturur
// AddScoped     -> tek bi alan içerisinde çalışır ve her kullanıcı için ayrı bir servis oluşturur
// AddSingleton  -> tek bir defa eklenir, ve her kullanıcı için aynı servisi teslim ederi