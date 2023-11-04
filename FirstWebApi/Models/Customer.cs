namespace BootCamp.Models;

public class Customer : BaseEntity
{
    public Customer()
    {
        this.CreatedDate = DateTime.Now;
        this.Id = Guid.NewGuid();
    }

    public Guid Id { get; set; } // string, int - long - uniq (guid) 
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Mail { get; set; }
    public DateTime CreatedDate { get; set; }
}


// hbcv00004y5arb -> string 
// guid -> 9B92FA61-1DB2-4F02-9FA0-00578B115D54