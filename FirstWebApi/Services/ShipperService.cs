namespace BootCamp.FirstWebApi.Services;
public class ShipperService : Service<Shipper, int>, IShipperService
{
    public ShipperService(ApplicationDbContext context) : base(context) { }
}
