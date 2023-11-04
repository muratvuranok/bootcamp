namespace BootCamp.Models.Dtos.CustomersDto;
public class CustomerDto
{
    public Guid Id { get; set; }
    public string Adi { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Mail { get; set; }


    //public string? FullName { get => Adi + " " + LastName; }
    public string? FullName { get; set; }
}


public class CustomerCreateDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Mail { get; set; }
}