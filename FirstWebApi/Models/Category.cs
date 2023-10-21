namespace BootCamp.FirstWebApi.Models;
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}


public class CategoryCreateInput
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}


public class CategoryEditInput
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}



// AddTransient  -> her istek için yeni bir servis oluşturur
// AddScoped     -> tek bi alan içerisinde çalışır ve her kullanıcı için ayrı bir servis oluşturur
// AddSingleton  -> tek bir defa eklenir, ve her kullanıcı için aynı servisi teslim ederi