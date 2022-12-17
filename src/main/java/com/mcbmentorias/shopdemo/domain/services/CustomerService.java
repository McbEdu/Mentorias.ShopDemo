package com.mcbmentorias.shopdemo.domain.services;

import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotificationPublisher;
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
        final var entity = this.createNewCustomerFactory.create();
        entity.importCustomer(input);

        if(!this.validateDomainEntityAndNotification(entity)) {
            return Boolean.FALSE;
        }

        this.repository.save(entity);

        return Boolean.TRUE;
    }
}
