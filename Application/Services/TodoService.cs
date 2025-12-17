using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class TodoService : ITodoRepository
    {
        public Task<TodoItem> AddAsync(TodoItem entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoItem>> GetCompletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoItem>> GetPendingAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TodoItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
