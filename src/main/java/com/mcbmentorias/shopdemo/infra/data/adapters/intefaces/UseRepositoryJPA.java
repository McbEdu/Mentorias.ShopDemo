package com.mcbmentorias.shopdemo.infra.data.adapters.intefaces;

import com.mcbmentorias.shopdemo.domain.entities.customer.Customer;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;

public interface UseRepositoryJPA extends JpaRepository<Customer, Long>, JpaSpecificationExecutor<Customer> {
    Boolean existsByEmail(final String email);

    Customer getByEmail(final String email);
}
