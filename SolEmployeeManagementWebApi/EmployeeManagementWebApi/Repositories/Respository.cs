using EmployeeManagementWebApi.Contexts;
using EmployeeManagementWebApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementWebApi.Repositories
{
    public class Respository<K, T> : IRepository<K, T> where T : class
    {
        protected EmployeeContext _context;
        public Respository(EmployeeContext _context) 
        {

        }
        public T? Add(T item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        public T? Delete(K key)
        {
            var item = Get(key);
            if (item != null)
            {
                _context.Remove(item);
                _context.SaveChanges();
                return item;
            }
            return null;
        }

        public T? Get(K key)
        {
            var item = _context.Find<T>(key);
            return item != null ? item : null;
        }

        public IEnumerable<T>? GetAll()
        {
            var items = _context.Set<T>().ToList();
            if (items.Any())
                return items;
            return null;
        }

        public T? Update(K key, T item)
        {
            var existingItem = Get(key);
            if (existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(item);
                _context.SaveChanges();
                return existingItem;
            }
            return null;
        }
    }
}
