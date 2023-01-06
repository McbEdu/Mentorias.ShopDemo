package com.mcbmentorias.shopdemo.domain.services.interfaces;

import com.mcbmentorias.shopdemo.domain.entities.product.Product;
import com.mcbmentorias.shopdemo.domain.entities.product.inputs.CreateNewImportProductInput;

import java.util.Collection;
import java.util.List;

public interface IProductService {

    Boolean importProduct(
            final CreateNewImportProductInput input
    );

    Boolean createImportProductOrNotifyDifferences(final CreateNewImportProductInput domainInput);

    Product getByCode(final String code);

    Boolean createImportProductOrNotifyDifferences(final Collection<CreateNewImportProductInput> inputs);
}
