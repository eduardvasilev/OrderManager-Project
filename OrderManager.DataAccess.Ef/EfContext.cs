using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManager.DomainModel;

namespace OrderManager.DataAccess.Ef
{
    public class EfContext : DbContext
    {
        public EfContext(DbContextOptions<EfContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<Order> orderBuilder = modelBuilder.Entity<Order>();
            orderBuilder
                .HasMany<OrderItem>(order => order.Items).WithOne(item => item.Order);
            orderBuilder.Property(order => order.CreationDate).IsRequired();
            orderBuilder.Property(order => order.StatusId).IsRequired();

            EntityTypeBuilder<OrderItem> orderItemBuilder = modelBuilder.Entity<OrderItem>();

            orderItemBuilder.HasOne<Order>(x => x.Order);

            orderItemBuilder.HasOne<Product>(x => x.Product);
            orderItemBuilder.Property(product => product.Amount).IsRequired();

            EntityTypeBuilder<Product> productBuilder = modelBuilder.Entity<Product>();

            productBuilder.Property(product => product.Name).IsRequired();
            productBuilder.Property(product => product.Price).IsRequired();
        }
    }
}
