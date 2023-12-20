namespace courses.Interfaces
{
    public interface IRepository<T>
    {
        bool Create(T entity);
        T Get(int id);
        bool Delete(T entity);

        bool Update(T entity, Action<T> update);
        IEnumerable<T> GetAll();
    }
}
