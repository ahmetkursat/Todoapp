using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class TodoRepository : Repository<TodoItem>, ITodoRepository
    {
        public TodoRepository(DbContext context, DbSet<TodoItem> dbset) : base(context, dbset)
        {
        }

        public async Task <IEnumerable<TodoItem>> GetComletedAsync()
        {
            return await _context.Set<TodoItem>()
                .AsNoTracking().Where(x => x.IsCompleted)
             
        }
        public async Task<IEnumerable<TodoItem>> GetPendingAsync()
        {
            return await _context.Set<TodoItem>()
                                 .AsNoTracking()
                                 .Where(x => !x.IsCompleted) // Tamamlanmamışlar
                                 .ToListAsync();
        }
    }
}
