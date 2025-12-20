using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        protected readonly DbContext _context;
        private readonly DbSet<T> _dbset;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T item)
        {
            await _dbset.AddAsync(item);
            _context.SaveChanges();
            return item;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbset.FindAsync();
            if (entity == null)
            {
                return false; // Silinecek kayıt bulunamadı
            }

            _dbset.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(int id, T item)
        {
            var existingEntity = await _dbset.FindAsync(id);

            if (existingEntity == null)
            {
                return null;
            }

            _context.Entry(existingEntity).CurrentValues.SetValues(item);
            return existingEntity;
        }
    }
}
