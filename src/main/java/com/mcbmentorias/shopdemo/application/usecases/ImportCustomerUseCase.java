package com.mcbmentorias.shopdemo.application.usecases;

import com.mcbmentorias.shopdemo.application.dtos.inputmodel.ImportCustomerInputModel;
import com.mcbmentorias.shopdemo.core.usecases.BaseUseCaseWithParams;
import com.mcbmentorias.shopdemo.domain.factories.CreateNewCustomerInputFactory;
import com.mcbmentorias.shopdemo.domain.services.interfaces.ICustomerService;

public class ImportCustomerUseCase extends BaseUseCaseWithParams<ImportCustomerInputModel, Void> {

    private final ICustomerService service;

    private final CreateNewCustomerInputFactory factory;

    public ImportCustomerUseCase(
            final ICustomerService service,
            final CreateNewCustomerInputFactory factory
    ) {
        this.service = service;
        this.factory = factory;
    }

    @Override
    public Void execute(final ImportCustomerInputModel inputModel) {
        final var domainInput = this.factory.create(inputModel);
        this.service.create(domainInput);
        return null;
    }
}
