using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface ITodoRepository<T> : IRepository<TodoItem>
    {
        Task<T> GetCompletedAsync();

        Task<T> GetPendingAsync();

    }
}
