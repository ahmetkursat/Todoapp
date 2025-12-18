using Application.DTOs;
using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Application.Mappings.Extensions
{
    public static class TodoMappingExtensions
    {
        public static TodoItemDto ToDto(this TodoItemDto entity,IMapper mapper)
        {
            return mapper.Map<TodoItemDto>(entity);
        }

        public static IEnumerable<TodoItemDto> ToDto(this IEnumerable<TodoItem> entities,IMapper mapper)
        {
            return mapper.Map<IEnumerable<TodoItemDto>>(entities);
        }

        public static TodoItem ToEntity(this CreateTodoItemDto dto,IMapper mapper)
        {
            return mapper.Map<TodoItem>(dto);
        }

        public static void UpdateEntity(this UpdateTodoItemDto dto,TodoItem entity,IMapper mapper)
        {
            mapper.Map(dto, entity);
        }
    }
}
