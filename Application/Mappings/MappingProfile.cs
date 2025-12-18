using Application.DTOs;
using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
       public MappingProfile()
        {
            // Entity -> DTO (Basit mapping)
            CreateMap<TodoItem, TodoItemDto>();

            // CreateDTO -> Entity
            CreateMap<CreateTodoItemDto, TodoItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
       

            // UpdateDTO -> Entity (SADECE NULL OLMAYAN ALANLAR)
            CreateMap<UpdateTodoItemDto, TodoItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.IsCompleted, opt => opt.Ignore())
               
                // Title: Sadece null değilse map et
                .ForMember(dest => dest.Title, opt => opt.Condition(src => src.Title != null))
                // Description: Sadece null değilse map et
                .ForMember(dest => dest.Description, opt => opt.Condition(src => src.Description != null));
        }

    }
}
