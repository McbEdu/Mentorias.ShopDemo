package com.mcbmentorias.shopdemo.infra.data.adapters;

import com.mcbmentorias.shopdemo.domain.entities.customer.Customer;
import com.mcbmentorias.shopdemo.infra.data.adapters.intefaces.UseRepositoryJPA;
import org.springframework.stereotype.Component;

@Component
public class UserRepositoryAdapter {

    private final UseRepositoryJPA jpa;

    public UserRepositoryAdapter(final UseRepositoryJPA jpa) {
        this.jpa = jpa;
    }

    public Customer save(final Customer entity) {
        return this.jpa.save(entity);
    }



}
