using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace TodoApi.Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<TodoService> _logger;

        public TodoService(ITodoRepository repository, IMapper mapper, ILogger<TodoService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<TodoItemDto> CreateAsync(CreateTodoItemDto dto)
        {
            _logger.LogInformation("Creating todo item: {Title}", dto.Title);
            var entity = _mapper.Map<TodoItem>(dto);
            var created = await _repository.AddAsync(entity);

            _logger.LogInformation("Todo item created with id: {Id}", created.Id);

            return _mapper.Map<TodoItemDto>(created);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            _logger.LogInformation("Deleting todo item with id: {Id}", id);

            var result = await _repository.DeleteAsync(id);

            if (result)
            {
                _logger.LogInformation("Todo item with id {Id} deleted successfully", id);
            }
            else
            {
                _logger.LogWarning("Todo item with id {Id} not found for deletion", id);
            }

            return result;
        }

        public async Task<IEnumerable<TodoItemDto>> GetAllAsync()
        {
            _logger.LogInformation("Getting all todo items");
            var entities = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<TodoItemDto>>(entities);
        }

        public async Task<TodoItemDto?> GetByIdAsync(int id)
        {
            _logger.LogInformation("Getting todo item with id: {Id}", id);

            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
            {
                _logger.LogInformation("Todo item with id {Id} not found", id);
                return null;
            }
            return _mapper.Map<TodoItemDto>(entity);
        }

        public async Task<IEnumerable<TodoItemDto>> GetCompletedAsync()
        {
            _logger.LogInformation("Getting completed todo items");
            var entity = await _repository.GetCompletedAsync();
            return _mapper.Map<IEnumerable<TodoItemDto>>(entity);
        }

        public async Task<IEnumerable<TodoItemDto>> GetPendingAsync()
        {
            _logger.LogInformation("Getting pending todo items");
            var entity = await _repository.GetPendingAsync();
            return _mapper.Map<IEnumerable<TodoItemDto>>(entity);
        }

        public async Task<TodoItemDto> UpdateAsync(int id,UpdateTodoItemDto dto)
        {
            _logger.LogInformation("Updating todo item with id: {Id}", dto);

            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
            {
                _logger.LogWarning("Todo item with id {Id} not found", id);
                return null;
            }

            _mapper.Map(dto, entity);

            if (dto.IsCompleted.HasValue)
            {
                entity.IsCompleted = dto.IsCompleted.Value;
            }

            // Database'de güncelle
            var updated = await _repository.UpdateAsync(id,entity);

            _logger.LogInformation("Todo item with id {Id} updated successfully", id);

            // Entity -> DTO (AutoMapper)
            return _mapper.Map<TodoItemDto>(updated);
        }

        
    }
}