package com.mcbmentorias.shopdemo.infra.data;

import com.mcbmentorias.shopdemo.domain.entities.Customer;
import com.mcbmentorias.shopdemo.infra.data.adapters.UserRepositoryAdapter;
import com.mcbmentorias.shopdemo.infra.data.interfaces.IUserRepository;
import org.springframework.stereotype.Repository;

@Repository
public class UserRepository implements IUserRepository {

    private final UserRepositoryAdapter adapter;

    public UserRepository(final UserRepositoryAdapter adapter) {
        this.adapter = adapter;
    }

    @Override
    public Customer save(final Customer entity) {
        return this.adapter.save(entity);
    }
}
