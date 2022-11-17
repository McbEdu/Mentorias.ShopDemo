﻿using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Infrascructure.Repositories.Extensions;
using McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories.Extensions;

public class ExtendsCustomerRepository : CustomerRepository, IExtendsRepository<Customer>
{
    public async Task<bool> VerifyEntityExistsAsync(string information)
    {
        if (await _dataContext.Customers.CountAsync() < 1) return false;

        return await _dataContext.Customers.Where(p => p.Email == information).AnyAsync();
    }

    public async Task<bool> VerifyEntityExistsAsync(Guid identifier)
    {
        if (await _dataContext.Customers.CountAsync() < 1) return false;

        return await _dataContext.Customers.Where(p => p.Identifier == identifier).AnyAsync();
    }
}
