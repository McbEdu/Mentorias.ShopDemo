package com.mcbmentorias.shopdemo.domain.services;

import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotificationPublisher;
import com.mcbmentorias.shopdemo.core.patterns.notification.models.Notification;
import com.mcbmentorias.shopdemo.core.patterns.validator.enums.ValidationTypeMessage;
import com.mcbmentorias.shopdemo.domain.entities.customer.Customer;
import com.mcbmentorias.shopdemo.domain.entities.customer.factories.CreateNewCustomerFactory;
import com.mcbmentorias.shopdemo.domain.entities.customer.inputs.ImportNewCustomerInput;
import com.mcbmentorias.shopdemo.domain.services.base.BaseService;
import com.mcbmentorias.shopdemo.domain.services.interfaces.ICustomerService;
import com.mcbmentorias.shopdemo.infra.data.interfaces.ICustomerRepository;
import org.springframework.stereotype.Service;

import java.util.Objects;

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
        if(this.checkIfCustomerExistsByEmail(input.getEmail())) {
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

    @Override
    public Boolean checkIfCustomerExistsByEmail(final String email) {
        return this.repository.checkIfCustomerEmailExists(email);
    }

    @Override
    public Customer getByEmail(final String email) {
        return this.repository.getByEmail(email);
    }

    @Override
    public Boolean createImportCustomerOrNotifyDifferences(final ImportNewCustomerInput input) {
        final var customer = this.getByEmail(input.getEmail());
        if(Objects.isNull(customer)) {
            return this.importCustomer(input);
        }

        if( !Objects.equals(customer.getBirthDate(), input.getBirthDate())) {
            this.notificationPublisher.publisherNotification(
                    new Notification(
                            "birthdate",
                            "11",
                            "Customer already registered buts with distinct birthdate",
                            input.getBirthDate(),
                            ValidationTypeMessage.Warning.name()
                    )
            );
        }

        if( !Objects.equals(customer.getLastName(), input.getLastName())) {
            this.notificationPublisher.publisherNotification(
                    new Notification(
                            "lastName",
                            "12",
                            "Customer already registered buts with distinct last name.",
                            input.getLastName(),
                            ValidationTypeMessage.Warning.name()
                    )
            );
        }

        if(!Objects.equals(customer.getName(), input.getName())) {
            this.notificationPublisher.publisherNotification(
                    new Notification(
                            "name",
                            "13",
                            "Customer already registered buts with distinct name.",
                            input.getName(),
                            ValidationTypeMessage.Warning.name()
                    )
            );
        }

        return Boolean.FALSE;
    }
}
