using McbEdu.Mentorias.General.Infrascructure.Abstractions.Mappings;
using McbEdu.Mentorias.ShopDemo.Domain.DTOs;
using Microsoft.EntityFrameworkCore;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data;

public class DataContext : DbContext
{
    public DbSet<Customer> Customers { get; protected set; }
    public DbSet<Product> Products { get; protected set; }

    private readonly BaseMapping<Customer> _customerMapping;
    private readonly BaseMapping<Product> _productMapping;

    public DataContext(BaseMapping<Customer> customerMapping, BaseMapping<Product> productMapping, DbContextOptions options) : base(options)
    {
        _customerMapping = customerMapping;
        _productMapping = productMapping;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _productMapping.CreateMapping(modelBuilder.Entity<Product>());
        _customerMapping.CreateMapping(modelBuilder.Entity<Customer>());

        base.OnModelCreating(modelBuilder);
    }
}
