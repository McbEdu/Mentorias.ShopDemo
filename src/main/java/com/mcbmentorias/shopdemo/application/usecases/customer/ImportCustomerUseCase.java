package com.mcbmentorias.shopdemo.application.usecases.customer;

import com.mcbmentorias.shopdemo.application.dtos.inputmodel.ImportCustomerInputModel;
import com.mcbmentorias.shopdemo.core.usecases.BaseUseCaseWithParams;
import com.mcbmentorias.shopdemo.domain.factories.CreateImportCustomerInputFactory;
import com.mcbmentorias.shopdemo.domain.services.interfaces.ICustomerService;
import org.springframework.stereotype.Service;

@Service
public class ImportCustomerUseCase extends BaseUseCaseWithParams<ImportCustomerInputModel, Void> {

    private final ICustomerService service;

    private final CreateImportCustomerInputFactory factory;

    public ImportCustomerUseCase(
            final ICustomerService service,
            final CreateImportCustomerInputFactory factory
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
