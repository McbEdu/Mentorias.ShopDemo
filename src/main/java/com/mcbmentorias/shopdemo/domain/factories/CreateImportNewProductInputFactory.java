package com.mcbmentorias.shopdemo.domain.factories;

import com.mcbmentorias.shopdemo.application.dtos.inputmodel.ImportProductInputModel;
import com.mcbmentorias.shopdemo.core.patterns.factory.BaseFactoryWithParams;
import com.mcbmentorias.shopdemo.domain.entities.product.inputs.CreateNewProductInput;
import org.springframework.stereotype.Component;

@Component
public class CreateImportNewProductInputFactory extends BaseFactoryWithParams<ImportProductInputModel, CreateNewProductInput> {

    @Override
    public CreateNewProductInput create(final ImportProductInputModel input) {
        return new CreateNewProductInput(
                input.getCode(),
                input.getDescription()
        );
    }
}
