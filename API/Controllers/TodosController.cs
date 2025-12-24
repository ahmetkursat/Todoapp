using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetAllTodos()
        {
            var todos = await _todoService.GetAllAsync();
            return Ok(todos);
        }
        [HttpGet ("id")]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetByIdTodos(int id)
        {
            var todos = await _todoService.GetByIdAsync(id);

            if (todos == null)
            {
                return NotFound(new { message = $"Todo with ID {id} not found." }); // 404
            }
            return Ok(todos);
        }
        [HttpGet("completed")]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetTodoCompleted()
        {
            var todos = await _todoService.GetCompletedAsync();
            return Ok(todos);
        }
        [HttpGet("pending")]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetTodoPending()
        {
            var todos = await _todoService.GetPendingAsync();
            return Ok(todos);
        }
        [HttpPost]
        public async Task<ActionResult<TodoItemDto>> CreateTodos([FromBody] CreateTodoItemDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad Request
            }

            var createdTodo = await _todoService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetByIdTodos),
                new { id = createdTodo.Id },
                createdTodo);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TodoItemDto>> UpdateTodos(int id, [FromBody] UpdateTodoItemDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad Request
            }

            var updatedTodo = await _todoService.UpdateAsync(id, dto);

            if (updatedTodo == null)
            {
                return NotFound(new { message = $"Todo with ID {id} not found." }); // 404
            }

            return Ok(updatedTodo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDto(int id )
        {
            var result = await _todoService.DeleteAsync(id);

            if (!result)
            {
                return NotFound(new { message = $"Todo with ID {id} not found." }); // 404
            }

            return NoContent();
        }
    }
}
