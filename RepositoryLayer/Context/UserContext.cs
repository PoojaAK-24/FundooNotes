using CommonLayer;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Notes> Notes { get; set; }
        public DbSet<Collaboration> collaborations { get; set; }
        public DbSet<Label> Labels { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity => {
                entity.HasIndex(e => e.Email).IsUnique();
            });
         }
    }
}
