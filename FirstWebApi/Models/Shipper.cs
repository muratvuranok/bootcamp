namespace BootCamp.FirstWebApi.Models;

public class Shipper
{
    public int ShipperId { get; set; }
    public string CompanyName { get; set; } = null!;
    public string? Phone { get; set; }
}
