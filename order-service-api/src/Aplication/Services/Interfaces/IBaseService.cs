namespace OrderServiceAPI.src.Aplication.Services.Interfaces;

public interface IBaseService<T> where T : class
{
    Task AddAsync(T entity);
    Task<T?> GetByIdAsync(Guid id);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
}