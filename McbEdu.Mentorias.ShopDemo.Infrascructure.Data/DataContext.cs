using McbEdu.Mentorias.General.Infrascructure.Abstractions.Mappings;
using McbEdu.Mentorias.ShopDemo.Domain.DTOs;
using Microsoft.EntityFrameworkCore;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data;

public class DataContext : DbContext
{
    public DbSet<Customer> Customers { get; protected set; }

    private readonly BaseMapping<Customer> _customerMapping;

    public DataContext(BaseMapping<Customer> customerMapping, DbContextOptions options) : base(options)
    {
        _customerMapping = customerMapping;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _customerMapping.CreateMapping(modelBuilder.Entity<Customer>());

        base.OnModelCreating(modelBuilder);
    }
}
