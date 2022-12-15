package com.mcbmentorias.shopdemo.domain.services;

import com.mcbmentorias.shopdemo.domain.entities.product.factories.ProductFactory;
import com.mcbmentorias.shopdemo.domain.entities.product.inputs.CreateNewProductInput;
import com.mcbmentorias.shopdemo.domain.repositories.IProductRepository;
import com.mcbmentorias.shopdemo.domain.services.interfaces.IProductService;
import org.springframework.stereotype.Service;

@Service
public class ProductService implements IProductService {

    private final IProductRepository repository;
    private final ProductFactory productFactory;

    public ProductService(
            final IProductRepository repository,
            final ProductFactory productFactory
    ) {
        this.repository = repository;
        this.productFactory = productFactory;
    }

    @Override
    public void importProduct(final CreateNewProductInput input) {
        final var product = this.productFactory.create();
        product.importProduct(input);


    }
}
