package com.mcbmentorias.shopdemo.domain.services.interfaces;

import com.mcbmentorias.shopdemo.domain.entities.product.inputs.CreateNewProductInput;

public interface IProductService {

    Boolean importProduct(
            final CreateNewProductInput input
    );
}
