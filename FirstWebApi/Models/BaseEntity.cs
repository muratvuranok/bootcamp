namespace BootCamp.FirstWebApi.Models;

public class BaseEntity { }


// AddTransient  -> her istek için yeni bir servis oluşturur
// AddScoped     -> tek bi alan içerisinde çalışır ve her kullanıcı için ayrı bir servis oluşturur
// AddSingleton  -> tek bir defa eklenir, ve her kullanıcı için aynı servisi teslim ederi