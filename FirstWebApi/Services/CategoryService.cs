namespace BootCamp.FirstWebApi.Services;

public class CategoryService : Service<Category, int>, ICategoryService
{
    public CategoryService(ApplicationDbContext context) : base(context) { }
}
