using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViajesAPI.Models.Entities;

namespace ViajesAPI.Models.Contexts
{
    public class Context : DbContext
    {
        public DbSet<User> users { get; set; }

        public DbSet<Message> meesages { get; set; } 

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().HasKey(p => p.id);
            builder.Entity<User>().Property(p => p.name).IsRequired();
            builder.Entity<User>().Property(p => p.lastName).IsRequired();
            builder.Entity<User>().Property(p => p.email).IsRequired();
            builder.Entity<User>().Property(p => p.telefono);
            builder.Entity<User>().HasMany(p => p.messages).WithOne(p => p.user).HasForeignKey(p => p.userId);      


            builder.Entity<Message>().ToTable("Messages");
            builder.Entity<Message>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Message>().HasKey(p => p.id);
            builder.Entity<Message>().Property(p => p.message).IsRequired();
            builder.Entity<Message>().Property(p => p.readed).IsRequired();





        }
    }
}
