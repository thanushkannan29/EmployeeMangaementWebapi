namespace EmployeeManagementWebApi.Interfaces
{
    public interface IRepository<K, T> where T : class
    {
        T? Get(K key);
        IEnumerable<T>? GetAll();
        T? Add(T item);
        T? Update(K key, T item);
        T? Delete(K key);
    }
}
