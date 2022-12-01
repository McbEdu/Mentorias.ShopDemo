package com.mcbmentorias.shopdemo.domain.services;

import com.mcbmentorias.shopdemo.domain.entities.customer.Customer;
import com.mcbmentorias.shopdemo.domain.entities.customer.inputs.CreateNewCustomerInput;
import com.mcbmentorias.shopdemo.domain.services.interfaces.IUserService;
import com.mcbmentorias.shopdemo.infra.data.interfaces.IUserRepository;
import org.springframework.stereotype.Service;

@Service
public class UserService implements IUserService {

    private final IUserRepository repository;

    public UserService(final IUserRepository repository) {
        this.repository = repository;
    }

    @Override
    public Customer create(
            final CreateNewCustomerInput input
    ) {
        final var entity = new Customer();
        entity.create(input);
        return entity;
    }
}
