using Microsoft.EntityFrameworkCore;

namespace BootCamp.FirstWebApi.Data;
public class ApplicationDbContext : DbContext  // IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


    
}