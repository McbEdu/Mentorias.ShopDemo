package com.mcbmentorias.shopdemo.application.usecases.customer;

import com.mcbmentorias.shopdemo.application.dtos.inputmodel.ImportCustomerInputModel;
import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotificationSubscriber;
import com.mcbmentorias.shopdemo.core.usecases.BaseUseCase;
import com.mcbmentorias.shopdemo.domain.factories.CreateImportCustomerInputFactory;
import com.mcbmentorias.shopdemo.domain.services.interfaces.ICustomerService;
import org.springframework.stereotype.Service;

import javax.transaction.Transactional;

@Service
public class ImportCustomerUseCase extends BaseUseCase<ImportCustomerInputModel, Boolean> {

    private final ICustomerService service;

    private final CreateImportCustomerInputFactory factory;

    public ImportCustomerUseCase(
            final INotificationSubscriber notificationSubscriber,
            final ICustomerService service,
            final CreateImportCustomerInputFactory factory
    ) {
        super(notificationSubscriber);
        this.service = service;
        this.factory = factory;
    }

    @Override
    @Transactional
    public Boolean execute(final ImportCustomerInputModel inputModel) {
        final var domainInput = this.factory.create(inputModel);
        this.service.importCustomer(domainInput);

        if(!this.hasNotification()) return Boolean.TRUE;

        return Boolean.FALSE;
    }
}
