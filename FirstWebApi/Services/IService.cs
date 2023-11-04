namespace BootCamp.FirstWebApi.Services;

public interface IService<T, IdType>
    where T : BaseEntity
    where IdType : struct
{
    Task AddAsync(T entity);
    Task DeleteAsync(IdType id);
    Task DeleteAsync(T entity);
    Task<IEnumerable<T>> GetAsync();
    Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> exp);
    Task<T> GetAsync(IdType id);
    Task<T> UpdateAsync(T entity);
}
