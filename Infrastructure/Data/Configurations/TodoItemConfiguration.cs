using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Configurations
{
    public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem> 
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.ToTable("TodoItems");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Description)
                .HasMaxLength(500);

            builder.Property(t => t.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.HasIndex(t => t.IsCompleted)
                .HasDatabaseName("IX_TodoItem_IsCompleted");

        }
    }
}
