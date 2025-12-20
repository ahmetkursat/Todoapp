using Application.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface ITodoService
    {
        Task<TodoItemDto?> GetByIdAsync(int id);
        Task<IEnumerable<TodoItemDto>> GetAllAsync();
        Task<IEnumerable<TodoItemDto>> GetCompletedAsync();
        Task<IEnumerable<TodoItemDto>> GetPendingAsync();
        Task<TodoItemDto> CreateAsync(CreateTodoItemDto dto);
        Task<TodoItemDto> UpdateAsync(int id,UpdateTodoItemDto dto);
        Task<bool> DeleteAsync(int id);
        Task<int> SaveChangesAsync();
    }
}
