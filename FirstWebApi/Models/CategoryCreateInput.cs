namespace BootCamp.FirstWebApi.Models;

public class CategoryCreateInput
{

    // [
    //     Required(ErrorMessage = "Kategori Adı, boş geçilemez"),
    //     MaxLength(10, ErrorMessage = "Kategori Adı, 10 karakterden fazla olamaz"),
    //     MinLength(3, ErrorMessage = "Kategori Adı, 3 karakterden az olamaz")
    // ]
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}



// AddTransient  -> her istek için yeni bir servis oluşturur
// AddScoped     -> tek bi alan içerisinde çalışır ve her kullanıcı için ayrı bir servis oluşturur
// AddSingleton  -> tek bir defa eklenir, ve her kullanıcı için aynı servisi teslim ederi