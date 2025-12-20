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
            CreateMap<TodoItem, TodoItemDto>();
        }

    }
}
