namespace BootCamp.FirstWebApi.Services; 
public class CustomerService : Service<Customer, Guid>, ICustomerService
{
    public CustomerService(ApplicationDbContext context) : base(context) { }
}