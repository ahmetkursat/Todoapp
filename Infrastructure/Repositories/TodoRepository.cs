using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class TodoRepository : Repository<TodoItem>, ITodoRepository<TodoItem>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        // DbContext yerine ApplicationDbContext kullanın
        public TodoRepository(ApplicationDbContext context) : base(context)
        {
            _applicationDbContext = context;
        }

        public Task<TodoItem> GetCompletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> GetPendingAsync()
        {
            throw new NotImplementedException();
        }
    }
}