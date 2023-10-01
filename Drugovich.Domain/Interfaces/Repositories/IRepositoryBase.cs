using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugovich.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> : IDisposable where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> UpdateAsync(IEnumerable<T> entities);
        Task<bool> DeleteAsync(IEnumerable<T> entities);
        Task<bool> SaveAsync();
    }
}
