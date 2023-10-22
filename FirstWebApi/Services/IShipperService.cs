using BootCamp.FirstWebApi.Data;
using BootCamp.FirstWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BootCamp.FirstWebApi.Services;

public interface IShipperService
{
    Task<List<Shipper>> GetAllAsync();
    Task<Shipper> GetByIdAsync(int id);
    Task<Shipper> AddAsync(Shipper shipper);
    Task<Shipper> UpdateAsync(Shipper shipper);
    Task<Shipper> DeleteAsync(int id);
}



public class ShipperService : IShipperService
{
    private readonly ApplicationDbContext _context;
    public ShipperService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Shipper> AddAsync(Shipper shipper)
    {
        _context.Shippers.Add(shipper);
        await _context.SaveChangesAsync();
        return shipper;
    }

    public async Task<Shipper> DeleteAsync(int id)
    {
        var deleted = _context.Shippers.Remove(new Shipper { ShipperId = id });
        await _context.SaveChangesAsync();
        return deleted.Entity;
    }

    public async Task<List<Shipper>> GetAllAsync()
    {
        return await _context.Shippers.ToListAsync();
    }

    public async Task<Shipper> GetByIdAsync(int id)
    {
        if (_context.Shippers == null)
        {
            return null;
        }

        return await _context.Shippers.FindAsync(id);
    }

    public async Task<Shipper> UpdateAsync(Shipper shipper)
    {
        _context.Shippers.Update(shipper);
        await _context.SaveChangesAsync();
        return shipper;
    }
}