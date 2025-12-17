using Core.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.Entities
{
    public class TodoItem : BaseEntity
    {
        public TodoItem(int userId,string title,string description)
        {
            ValidateTitle(title);
            ValidateDescription(description);
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        private void ValidateTitle(string title)
        {
            if(string.IsNullOrWhiteSpace(title))
            {
                throw new TodoDomainException("Başlık boş veya null olamaz");
            }
            if(title.Length > 200)
            {
                throw new TodoDomainException("Başlık 200 karakterden uzun olamaz");
            }
        }

        private void ValidateDescription(string description)
        {
            if (description != null && description.Length > 500)
            {
                throw new TodoDomainException("Açıklama 500 karakterden büyük olamaz");
            }
        }


    }
}
