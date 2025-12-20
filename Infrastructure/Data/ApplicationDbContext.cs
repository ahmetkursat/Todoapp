using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }

        public DbSet<TodoItem> todoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TodoItem>().HasKey(t => t.Id);

            modelBuilder.Entity<TodoItem>()
                .Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<TodoItem>()
                .Property(t => t.Description)
                .HasMaxLength(500);
            modelBuilder.Entity<TodoItem>()
                .Property(t => t.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");
            modelBuilder.Entity<TodoItem>()
                .Property(t => t.IsCompleted)
                .HasDefaultValue(false);
            modelBuilder.Entity<TodoItem>()
                .HasIndex(t => t.IsCompleted)
                .HasDatabaseName("IX_TodoItem_IsCompleted");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
