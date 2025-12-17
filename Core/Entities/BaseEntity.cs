using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreatedAt = DateTime.UtcNow;
        }

        protected void SetUpdatedTime()
        {
            UpdateAt = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        
    }
}
