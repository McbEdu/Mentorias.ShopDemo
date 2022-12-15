package com.mcbmentorias.shopdemo.domain.services;

import com.mcbmentorias.shopdemo.domain.entities.customer.Customer;
import com.mcbmentorias.shopdemo.domain.entities.customer.inputs.CreateNewCustomerInput;
import com.mcbmentorias.shopdemo.domain.services.interfaces.ICustomerService;
import com.mcbmentorias.shopdemo.infra.data.interfaces.ICustomerRepository;
import org.springframework.stereotype.Service;

@Service
public class CustomerService implements ICustomerService {

    private final ICustomerRepository repository;

    public CustomerService(final ICustomerRepository repository) {
        this.repository = repository;
    }

    @Override
    public Customer create(
            final CreateNewCustomerInput input
    ) {
        final var entity = new Customer();
        entity.importCustomer(input);
        return entity;
    }
}
