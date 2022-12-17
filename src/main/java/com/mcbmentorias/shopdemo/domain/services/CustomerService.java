package com.mcbmentorias.shopdemo.domain.services;

import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotificationPublisher;
import com.mcbmentorias.shopdemo.core.patterns.notification.models.Notification;
import com.mcbmentorias.shopdemo.core.patterns.validator.enums.ValidationTypeMessage;
import com.mcbmentorias.shopdemo.domain.entities.customer.factories.CreateNewCustomerFactory;
import com.mcbmentorias.shopdemo.domain.entities.customer.inputs.ImportNewCustomerInput;
import com.mcbmentorias.shopdemo.domain.services.base.BaseService;
import com.mcbmentorias.shopdemo.domain.services.interfaces.ICustomerService;
import com.mcbmentorias.shopdemo.infra.data.interfaces.ICustomerRepository;
import org.springframework.stereotype.Service;

@Service
public class CustomerService extends BaseService implements ICustomerService {

    private final ICustomerRepository repository;
    private final CreateNewCustomerFactory createNewCustomerFactory;

    public CustomerService(
            final INotificationPublisher notificationPublisher,
            final ICustomerRepository repository,
            final CreateNewCustomerFactory createNewCustomerFactory
    ) {
        super(notificationPublisher);
        this.repository = repository;
        this.createNewCustomerFactory = createNewCustomerFactory;
    }

    @Override
    public Boolean importCustomer(
            final ImportNewCustomerInput input
    ) {
        if(this.repository.checkIfCustomerEmailExists(input.getEmail())) {
            this.notificationPublisher.publisherNotification(
                    new Notification(
                            "email",
                            "10",
                            "email already exists",
                            input.getEmail(),
                            ValidationTypeMessage.Error.name()
                    )
            );

            return Boolean.FALSE;
        }

        final var entity = this.createNewCustomerFactory.create();

        entity.importCustomer(input);

        if(!this.validateDomainEntityAndNotification(entity)) {
            return Boolean.FALSE;
        }

        this.repository.save(entity);

        return Boolean.TRUE;
    }
}
