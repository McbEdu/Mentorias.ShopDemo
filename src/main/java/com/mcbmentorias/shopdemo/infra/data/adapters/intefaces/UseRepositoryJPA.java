package com.mcbmentorias.shopdemo.infra.data.adapters.intefaces;

import com.mcbmentorias.shopdemo.domain.entities.Customer;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;

public interface UseRepositoryJPA extends JpaRepository<Customer, Long>, JpaSpecificationExecutor<Customer> {
}
