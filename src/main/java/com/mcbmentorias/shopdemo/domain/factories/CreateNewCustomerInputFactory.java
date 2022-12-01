package com.mcbmentorias.shopdemo.domain.factories;

import com.mcbmentorias.shopdemo.application.dtos.inputmodel.ImportCustomerInputModel;
import com.mcbmentorias.shopdemo.core.patterns.factory.BaseFactoryWithParams;
import com.mcbmentorias.shopdemo.domain.entities.customer.inputs.CreateNewCustomerInput;
import org.springframework.stereotype.Component;

@Component
public class CreateNewCustomerInputFactory extends BaseFactoryWithParams<ImportCustomerInputModel, CreateNewCustomerInput> {

    @Override
    public CreateNewCustomerInput create(final ImportCustomerInputModel inputModel) {
        return new CreateNewCustomerInput(
            inputModel.getNome(),
            inputModel.getLastName(),
            inputModel.getBirthDate(),
            inputModel.getEmail()
        );
    }
}
