package com.mcbmentorias.shopdemo.application.usecases.customer;

import com.mcbmentorias.shopdemo.application.dtos.inputmodel.ImportCustomerInputModel;
import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotificationSubscriber;
import com.mcbmentorias.shopdemo.core.usecases.BaseUseCase;
import com.mcbmentorias.shopdemo.domain.factories.CreateImportCustomerInputFactory;
import com.mcbmentorias.shopdemo.domain.services.interfaces.ICustomerService;
import org.springframework.stereotype.Service;
import org.springframework.transaction.PlatformTransactionManager;
import org.springframework.transaction.support.DefaultTransactionDefinition;

import java.util.Collection;

@Service
public class ImportCustomerBatchesUseCase extends BaseUseCase<Collection<ImportCustomerInputModel>, Boolean> {

    private final ICustomerService service;
    private final CreateImportCustomerInputFactory factory;
    private final PlatformTransactionManager transactionManager;

    public ImportCustomerBatchesUseCase(
            final INotificationSubscriber notificationSubscriber,
            final ICustomerService service,
            final CreateImportCustomerInputFactory factory,
            final PlatformTransactionManager transactionManager
    ) {
        super(notificationSubscriber);
        this.service = service;
        this.factory = factory;
        this.transactionManager = transactionManager;
    }

    @Override
    public Boolean execute(final Collection<ImportCustomerInputModel> inputs) {
        final var transaction = new DefaultTransactionDefinition();
        final var status = this.transactionManager.getTransaction(transaction);

        inputs.forEach(input -> {
            final var domainInput = this.factory.create(input);
            this.service.importCustomer(domainInput);
        });

        this.transactionManager.commit(status);

        if(!this.hasNotification()) return Boolean.TRUE;

        return Boolean.FALSE;
    }
}
