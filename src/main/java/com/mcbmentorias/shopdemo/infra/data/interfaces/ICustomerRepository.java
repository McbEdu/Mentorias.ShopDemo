package com.mcbmentorias.shopdemo.infra.data.interfaces;

import com.mcbmentorias.shopdemo.domain.entities.customer.Customer;

public interface ICustomerRepository extends IRepository<Customer> {

    Customer save(final Customer entity);

    Boolean checkIfCustomerEmailExists(final String email);

    Customer getByEmail(final String email);
}
