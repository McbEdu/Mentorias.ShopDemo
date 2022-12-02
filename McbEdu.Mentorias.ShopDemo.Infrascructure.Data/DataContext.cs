using McbEdu.Mentorias.General.Infrascructure.Abstractions.Mappings;
using McbEdu.Mentorias.ShopDemo.Domain.DTOs;
using Microsoft.EntityFrameworkCore;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data;

public class DataContext : DbContext
{
    public DbSet<Customer> Customers { get; protected set; }
    public DbSet<Product> Products { get; protected set; }
    public DbSet<Item> Items { get; protected set; }
    public DbSet<Order> Orders { get; protected set; }

    private readonly BaseMapping<Customer> _customerMapping;
    private readonly BaseMapping<Product> _productMapping;
    private readonly BaseMapping<Item> _itemMapping;
    private readonly BaseMapping<Order> _orderMapping;

    public DataContext(
        BaseMapping<Customer> customerMapping,
        BaseMapping<Product> productMapping, 
        BaseMapping<Item> itemMapping,
        BaseMapping<Order> orderMapping,
        DbContextOptions options) 
        : base(options)
    {
        _customerMapping = customerMapping;
        _productMapping = productMapping;
        _itemMapping = itemMapping;
        _orderMapping = orderMapping;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _productMapping.CreateMapping(modelBuilder.Entity<Product>());
        _customerMapping.CreateMapping(modelBuilder.Entity<Customer>());
        _itemMapping.CreateMapping(modelBuilder.Entity<Item>());
        _orderMapping.CreateMapping(modelBuilder.Entity<Order>());

        base.OnModelCreating(modelBuilder);
    }
}
