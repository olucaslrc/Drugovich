using Drugovich.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Drugovich.Infrastructure.Data.Repositories
{
    public abstract class Repository<T> : IRepositoryBase<T> where T : class
    {
        private bool disposedValue;
        protected DrugovichDbContext _context;
        protected Repository(DrugovichDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                await _context.AddAsync(entity);
                await SaveAsync();
                return entity;
            }
            catch (DbException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(IEnumerable<T> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    var obj = await _context.FindAsync<T>(entity);
                    _context.Remove(obj!);
                }
                await SaveAsync();
                return true;
            }
            catch (DbException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (DbException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _context.Set<T>().FindAsync(id);

                if (result != null)
                {
                    return result;
                }
                return null;

            }
            catch (DbException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(IEnumerable<T> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    var get = await _context.Set<T>().FindAsync(entity);
                    _context.Update(get!);
                }
                await SaveAsync();
                return true;
            }
            catch (DbException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public async Task<Expression<T>>

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
