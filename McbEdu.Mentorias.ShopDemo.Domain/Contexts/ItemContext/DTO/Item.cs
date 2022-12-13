﻿using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.ValueObjects;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.DTO;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.DTO;

public class Item
{
    public Guid Identifier { get; set; }
    public int Sequence { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }
    public decimal UnitaryValue { get; set; }
    public Guid ProductIdentifier { get; set; }
    public string ProductCode { get;set; }
    public string ProductDescription { get; set; }
    public Order Order { get; set; }

    public Item()
    {
        Order = new Order();
        Description = ProductCode = ProductDescription = string.Empty;
    }
}
