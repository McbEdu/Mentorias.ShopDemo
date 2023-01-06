package com.mcbmentorias.shopdemo.domain.repositories;

import com.mcbmentorias.shopdemo.domain.entities.product.Product;
import com.mcbmentorias.shopdemo.infra.data.interfaces.IRepository;

public interface IProductRepository extends IRepository<Product> {

    Product save(final Product product);

    Boolean checkIfProductExists(final String productCode);

    Product getByCode(final String code);
}
