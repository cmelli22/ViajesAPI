using Microsoft.EntityFrameworkCore;
using ViajesAPI.Models.Entities;

namespace ViajesAPI.Models.Contexts
{
    public class Context : DbContext
    {
        public DbSet<User> users { get; set; }

        public DbSet<Message> meesages { get; set; }
        public DbSet<Product> products { get; set; }

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
    

            builder.Entity<Product>().ToTable("products");
            builder.Entity<Product>().Property(p => p.productId).IsRequired();
            builder.Entity<Product>().HasKey(p => p.productId);
            builder.Entity<Product>().Property(p => p.name);
            builder.Entity<Product>().Property(p => p.description);
            builder.Entity<Product>().Property(p => p.Precio).IsRequired();
            builder.Entity<Product>().HasMany(p => p.messages).WithOne(p => p.product).HasForeignKey(p => p.productId);




        }
    }
}
