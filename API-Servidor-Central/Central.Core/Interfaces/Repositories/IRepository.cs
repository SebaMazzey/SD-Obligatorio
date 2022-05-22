using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.Core.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        Task<IReadOnlyList<T>> ListAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChangesAsync();
        void SaveChanges();
    }
}
