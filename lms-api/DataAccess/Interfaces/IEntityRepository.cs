namespace LMS_API.DataAccess.Interfaces;

public interface IEntityRepository<T> where T : class
{
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    T Get(System.Func<T, bool> predicate);
    List<T> GetAll();
}

