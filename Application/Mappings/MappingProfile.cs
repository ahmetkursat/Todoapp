using Application.DTOs;
using AutoMapper;
using Core.Entities;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // TodoItem mapping'leri
            // TodoItem mapping'leri
            CreateMap<TodoItem, TodoItemDto>();

            // İhtiyacınız olan diğer mapping'ler
            CreateMap<TodoItem, CreateTodoItemDto>().ReverseMap();
            CreateMap<TodoItem, UpdateTodoItemDto>().ReverseMap();
            CreateMap<CreateTodoItemDto, TodoItem>();
            CreateMap<UpdateTodoItemDto, TodoItem>();
        }
    }
}