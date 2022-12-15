package com.mcbmentorias.shopdemo.application.usecases.customer;

import com.mcbmentorias.shopdemo.application.dtos.inputmodel.ImportCustomerInputModel;
import com.mcbmentorias.shopdemo.core.usecases.BaseUseCaseWithParams;
import com.mcbmentorias.shopdemo.domain.factories.CreateImportCustomerInputFactory;
import com.mcbmentorias.shopdemo.domain.services.interfaces.ICustomerService;
import org.springframework.stereotype.Service;

import java.util.Collection;

@Service
public class ImportCustomerBatchesUseCase extends BaseUseCaseWithParams<Collection<ImportCustomerInputModel>, Void> {

    private final ICustomerService service;
    private final CreateImportCustomerInputFactory factory;

    public ImportCustomerBatchesUseCase(
            final ICustomerService service,
            final CreateImportCustomerInputFactory factory
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
