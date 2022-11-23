using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Infrascructure.Repositories.Extensions;
using McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories.Extensions;

public class ExtendsCustomerRepository : CustomerRepository, IExtendsRepository<Customer>
{
    public ExtendsCustomerRepository(DataContext dataContext) : base(dataContext)
    {

    }

    public async Task<Customer?> GetAsync(string information)
    {
        if (_dataContext.Customers is null) return null;

        return await _dataContext.Customers.Where(p => p.Email == information).FirstAsync();
    }

    public async Task<bool> VerifyEntityExistsAsync(string information)
    {
        if (_dataContext.Customers is null) return false;

        return await _dataContext.Customers.Where(p => p.Email == information).AnyAsync();
    }

    public async Task<bool> VerifyEntityExistsAsync(Guid identifier)
    {
        if (_dataContext.Customers is null) return false;

        return await _dataContext.Customers.Where(p => p.Identifier == identifier).AnyAsync();
    }
}
