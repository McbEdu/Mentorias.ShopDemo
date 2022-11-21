using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Infrascructure.Repositories.Extensions;
using McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories.Extensions;

public class ExtendsOrderRepository : OrderRepository, IExtendsRepository<Order>
{
    public ExtendsOrderRepository(DataContext dataContext) : base(dataContext)
    {
    }

    public async Task<bool> VerifyEntityExistsAsync(string information)
    {
        return await _dataContext.Orders.AnyAsync(p => p.Code == information);
    }

    public Task<bool> VerifyEntityExistsAsync(Guid identifier)
    {
        throw new NotImplementedException();
    }
}
