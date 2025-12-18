using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class CreateTodoItemDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdateAt { get; set; }
    }
}
