package com.mcbmentorias.shopdemo.application.usecases;

import com.mcbmentorias.shopdemo.application.dtos.inputmodel.ImportCustomerInputModel;
import com.mcbmentorias.shopdemo.core.usecases.BaseUseCaseWithParams;
import com.mcbmentorias.shopdemo.domain.factories.CreateNewCustomerInputFactory;
import com.mcbmentorias.shopdemo.domain.services.interfaces.ICustomerService;

import java.util.Collection;

public class ImportCustomerBatchsUseCase extends BaseUseCaseWithParams<Collection<ImportCustomerInputModel>, Void> {

    private final ICustomerService service;
    private final CreateNewCustomerInputFactory factory;

    public ImportCustomerBatchsUseCase(
            final ICustomerService service,
            final CreateNewCustomerInputFactory factory
    ) {
        this.service = service;
        this.factory = factory;
    }

    @Override
    public Void execute(final Collection<ImportCustomerInputModel> inputs) {

        inputs.forEach(input -> {
            final var domainInput = this.factory.create(input);
            this.service.create(domainInput);
        });

        return null;
    }
}
