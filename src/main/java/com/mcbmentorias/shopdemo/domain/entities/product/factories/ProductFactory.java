package com.mcbmentorias.shopdemo.domain.entities.product.factories;

import com.mcbmentorias.shopdemo.core.patterns.factory.BaseFactory;
import com.mcbmentorias.shopdemo.domain.entities.product.Product;
import com.mcbmentorias.shopdemo.domain.entities.product.validations.CreateNewProductInputValidation;
import org.springframework.stereotype.Component;

@Component
public class ProductFactory extends BaseFactory<Product> {

    private final CreateNewProductInputValidation createNewProductInputValidation;

    public ProductFactory(final CreateNewProductInputValidation createNewProductInputValidation) {
        this.createNewProductInputValidation = createNewProductInputValidation;
    }

    @Override
    public Product create() {
        return new Product(
                this.createNewProductInputValidation
        );
    }
}
