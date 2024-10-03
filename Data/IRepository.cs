using System.Collections.Generic;

namespace Data
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
    }
}
