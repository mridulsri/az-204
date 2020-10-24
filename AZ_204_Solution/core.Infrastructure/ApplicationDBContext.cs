using core.Infrastructure.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace core.Infrastructure
{
   public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
       : base(options) { }

        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
        
    }
}
