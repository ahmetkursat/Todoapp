using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IRepository<T> where T :BaseEntity
    {
        Task<TodoItem?> GetByIdAsync(int id);
        Task<IEnumerable<TodoItem>> GetAllAsync();
        Task<TodoItem> AddAsync(TodoItem item);
        Task<TodoItem> UpdateAsync(int id ,TodoItem item);
        Task<bool> DeleteAsync(int id);

    }
}
