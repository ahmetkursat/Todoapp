using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface ITodoRepository : IRepository<TodoItem>
    {
        Task<IEnumerable<TodoItem>> GetCompletedAsync();

        Task<IEnumerable<TodoItem>> GetPendingAsync();

    }
}
