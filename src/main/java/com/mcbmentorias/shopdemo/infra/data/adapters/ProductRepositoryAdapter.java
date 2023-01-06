package com.mcbmentorias.shopdemo.infra.data.adapters;

import com.mcbmentorias.shopdemo.domain.entities.product.Product;
import com.mcbmentorias.shopdemo.infra.data.adapters.intefaces.ProductRepositoryJPA;
import org.springframework.stereotype.Component;

@Component
public class ProductRepositoryAdapter {

    private final ProductRepositoryJPA to;

    public ProductRepositoryAdapter(final ProductRepositoryJPA to) {
        this.to = to;
    }

    public Product save(final Product product) {
        return this.to.save(product);
    }

    public Boolean checkIfProductExists(final String productCode) {
        return this.to.existsByCode(productCode);
    }

    public Product getByCode(final String code) {
        return this.to.getByCode(code);
    }
}
