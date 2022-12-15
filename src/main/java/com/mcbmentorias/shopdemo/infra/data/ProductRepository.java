package com.mcbmentorias.shopdemo.infra.data;

import com.mcbmentorias.shopdemo.domain.entities.product.Product;
import com.mcbmentorias.shopdemo.domain.repositories.IProductRepository;
import com.mcbmentorias.shopdemo.infra.data.adapters.ProductRepositoryAdapter;
import org.springframework.stereotype.Repository;

@Repository
public class ProductRepository implements IProductRepository {

    private final ProductRepositoryAdapter adapter;

    public ProductRepository(final ProductRepositoryAdapter adapter) {
        this.adapter = adapter;
    }

    @Override
    public Product save(final Product product) {
        return this.adapter.save(product);
    }
}
