using Microsoft.EntityFrameworkCore;

namespace BootCamp.SeedData;

public static class CustomerSeedData
{

    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {

            // Admin, User, Moderator, vs  -> 10 adet sabit role
            // admin@xyc.com 



            //if (context.Customers.Any())  // db içerisinde eğer müşteri var ise, return anahtar kelimesi metot içerisinden çıkmasını sağlayacak, yok ise, altta yer alan kod blukları çalışacak
            //{
            //    return;
            //}

            #region Eski Metot
            //string[] firstNames = { "James", "Mary", "John", "Patricia", "Robert", "Jennifer", "Michael", "Linda", "William", "Elizabeth", "David", "Barbara", "Richard", "Susan", "Joseph", "Jessica", "Thomas", "Sarah", "Charles", "Karen" };
            //string[] lastNames = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez", "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin" };

            //List<Customer> customers = new();
            //Random rnd = new Random();

            //customers.Add(new()
            //{
            //    FirstName = "James",
            //    LastName = "Smith",
            //    Mail = "james.smith@example.com",
            //    Phone = "+90(555)4445522"
            //});


            //for (int i = 0; i < 100; i++)
            //{
            //    var customer = new Customer();
            //    customer.FirstName = firstNames[rnd.Next(firstNames.Length)];
            //    customer.LastName = lastNames[rnd.Next(lastNames.Length)];
            //    customer.Phone = $"({rnd.Next(100, 999)}) {rnd.Next(100, 999)}-{rnd.Next(1000, 9999)}";
            //    customer.Mail = $"{customer.FirstName.ToLower()}.{customer.LastName.ToLower()}@example.com";

            //    customers.Add(customer);
            //} 
            #endregion


            var customers = new List<Customer>
            {
                new() { Id = Guid.Parse("8B5ACC77-DD5D-4A1A-A69A-03C7E1031A4A"), FirstName = "Charles", LastName = "Wilson",    Mail ="charles.wilson@example.com",    Phone = "(362) 868-4179" },
                new() { Id = Guid.Parse("92C1B81C-D850-4D91-9B97-189F8DC294E5"), FirstName = "Robert",  LastName = "Rodriguez", Mail ="robert.rodriguez@example.com",  Phone = "(463) 914-6267" },
                new() { Id = Guid.Parse("B69CBF69-1398-4490-A87A-1A4BD238960C"), FirstName = "William", LastName = "Rodriguez", Mail ="william.rodriguez@example.com", Phone = "(982) 951-3347" },
                new() { Id = Guid.Parse("635CB5CC-04B1-4A50-BAC7-3322364F3B8C"), FirstName = "Mary",    LastName = "Jackson",   Mail ="mary.jackson@example.com",      Phone = "(976) 808-5676" },
                new() { Id = Guid.Parse("840499A2-1823-4BEF-859A-4B2AA261482D"), FirstName = "Robert",  LastName = "Martinez",  Mail ="robert.martinez@example.com",   Phone = "(724) 240-8389" },
                new() { Id = Guid.Parse("5D2704DF-659A-4E72-9467-77B45B5B1A6A"), FirstName = "Thomas",  LastName = "Williams",  Mail ="thomas.williams@example.com",   Phone = "(651) 274-5670" },
                new() { Id = Guid.Parse("9B977504-4DAE-4D27-A18C-831293F55763"), FirstName = "James",   LastName = "Martin",    Mail ="james.martin@example.com",      Phone = "(568) 385-6132" },
                new() { Id = Guid.Parse("8453D833-FAF3-4E13-BA47-A7E7437D3F13"), FirstName = "Susan",   LastName = "Smith",     Mail ="susan.smith@example.com",       Phone = "(454) 269-8248" },
                new() { Id = Guid.Parse("08F121D2-683A-4295-B32E-CB7C8457E80C"), FirstName = "Robert",  LastName = "Smith",     Mail ="robert.smith@example.com",      Phone = "(915) 896-4350" },
                new() { Id = Guid.Parse("FF10FA89-7841-455C-A861-DDB3662CD009"), FirstName = "Sarah",   LastName = "Brown",     Mail ="sarah.brown@example.com",       Phone = "(225) 733-9957" },
            };

            foreach (var customer in customers)
            {
                // db'de bu kullanıcı yok
                if (context.Customers.FirstOrDefault(x => x.FirstName == customer.FirstName && x.LastName == customer.LastName && x.Mail == customer.Mail) is null)
                {
                    context.Customers.Add(customer);
                }
            }

            context.SaveChanges();
        }
    }

}
/*
 {
  "firstName": "William",
  "lastName": "Jackson",
  "phone": "(225) 733-9957",
  "mail": "william.jackson@example.com"
}
 */