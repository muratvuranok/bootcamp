using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BootCamp.FirstWebApi.Services;

public class Service<T, IdType> : IService<T, IdType>
    where T : BaseEntity
    where IdType : struct
{

    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;
    public Service(ApplicationDbContext context)
    {
        this._context = context;
        this._dbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        //await _context.Set<T>().AddAsync(entity);
        // _context.Categories.AddAsync(entity);


        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(IdType id)
    {
        var entity = await this.GetAsync(id);
        if (entity != null)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> exp)
    {
        return await _dbSet.Where(exp).ToListAsync();
    }

    public async Task<T> GetAsync(IdType id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
            return entity;

        throw new NotImplementedException();
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();

        return entity;
    }
}
