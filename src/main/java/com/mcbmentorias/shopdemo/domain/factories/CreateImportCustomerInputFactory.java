package com.mcbmentorias.shopdemo.domain.factories;

import com.mcbmentorias.shopdemo.application.dtos.inputmodel.ImportCustomerInputModel;
import com.mcbmentorias.shopdemo.core.patterns.factory.BaseFactoryWithParams;
import com.mcbmentorias.shopdemo.domain.entities.customer.inputs.ImportNewCustomerInput;
import org.springframework.stereotype.Component;

@Component
public class CreateImportCustomerInputFactory extends BaseFactoryWithParams<ImportCustomerInputModel, ImportNewCustomerInput> {

    @Override
    public ImportNewCustomerInput create(final ImportCustomerInputModel inputModel) {
        return new ImportNewCustomerInput(
            inputModel.getName(),
            inputModel.getLastName(),
            inputModel.getBirthDate(),
            inputModel.getEmail()
        );
    }
}
