using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Infrascructure.Mappings;
using McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data;

public class DataContext : DbContext
{
    public DbSet<Customer> Customers { get; protected set; }
    public DbSet<Product> Products { get; protected set; }

    private IBaseMapping<Customer> CustomerBaseMapping { get; }
    private IBaseMapping<Product> ProductBaseMapping { get; }

    public DataContext(DbContextOptions options, IBaseMapping<Customer> customerBaseMapping, IBaseMapping<Product> productBaseMapping) : base(options)
    {
        CustomerBaseMapping = customerBaseMapping;
        ProductBaseMapping = productBaseMapping;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        CustomerBaseMapping.CreateBaseMapping(modelBuilder.Entity<Customer>());
        ProductBaseMapping.CreateBaseMapping(modelBuilder.Entity<Product>());

        base.OnModelCreating(modelBuilder);
    }
}
