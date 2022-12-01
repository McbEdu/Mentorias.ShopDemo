package com.mcbmentorias.shopdemo.domain.services.interfaces;

import com.mcbmentorias.shopdemo.domain.entities.customer.Customer;
import com.mcbmentorias.shopdemo.domain.entities.customer.inputs.CreateNewCustomerInput;

import java.time.LocalDate;

public interface IUserService extends IService<Customer> {

    Customer create(final CreateNewCustomerInput input);
}
