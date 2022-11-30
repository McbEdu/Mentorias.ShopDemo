package com.mcbmentorias.shopdemo.infra.data.interfaces;

import com.mcbmentorias.shopdemo.domain.entities.Customer;

public interface IUserRepository extends IRepository<Customer> {

    Customer save(final Customer entity);
}
