﻿using McbEdu.Mentorias.General.Infrascructure.Abstractions.Repositories;
using McbEdu.Mentorias.ShopDemo.Domain.DTOs;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories.Interfaces;

public interface IExtendsProductRepository : IBaseRepository<Product>
{
    Task<bool> VerifyEntityExistsAsync(string code);
    Task<Product?> GetByCode(string code);
}
