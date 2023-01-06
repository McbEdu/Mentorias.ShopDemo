package com.mcbmentorias.shopdemo.infra.data;

import com.mcbmentorias.shopdemo.domain.entities.customer.Customer;
import com.mcbmentorias.shopdemo.infra.data.adapters.UserRepositoryAdapter;
import com.mcbmentorias.shopdemo.infra.data.interfaces.ICustomerRepository;
import org.springframework.stereotype.Repository;

@Repository
public class UserRepository implements ICustomerRepository {

    private final UserRepositoryAdapter adapter;

    public UserRepository(final UserRepositoryAdapter adapter) {
        this.adapter = adapter;
    }

    @Override
    public Customer save(final Customer entity) {
        return this.adapter.save(entity);
    }

    @Override
    public Boolean checkIfCustomerEmailExists(final String email) {
        return this.adapter.checkIfCustomerEmailExists(email);
    }

    @Override
    public Customer getByEmail(final String email) {
        return this.adapter.getByEmail(email);
    }
}
