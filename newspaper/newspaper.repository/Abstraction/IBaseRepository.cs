namespace newspaper.repository.Abstraction;

public interface IBaseRepository<T, TKey>
{
    public Task Create(T entity);

    public Task Update(T entity);

    public Task<bool> Delete(TKey id);

    public Task<T?> GetById(TKey id);
}
