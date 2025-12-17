using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class TodoItemDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdateAt { get; set; }

    }
}
