package com.mcbmentorias.shopdemo.domain.factories;

import com.mcbmentorias.shopdemo.application.dtos.inputmodel.ImportProductInputModel;
import com.mcbmentorias.shopdemo.core.patterns.factory.BaseFactoryWithParams;
import com.mcbmentorias.shopdemo.domain.entities.product.inputs.CreateNewImportProductInput;
import org.springframework.stereotype.Component;

@Component
public class CreateImportNewProductInputFactory extends BaseFactoryWithParams<ImportProductInputModel, CreateNewImportProductInput> {

    @Override
    public CreateNewImportProductInput create(final ImportProductInputModel input) {
        return new CreateNewImportProductInput(
                input.getCode(),
                input.getDescription()
        );
    }
}
