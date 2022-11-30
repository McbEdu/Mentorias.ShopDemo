package com.mcbmentorias.shopdemo.domain.services.interfaces;

import com.mcbmentorias.shopdemo.domain.entities.Customer;

import java.time.LocalDate;

public interface IUserService extends IService<Customer> {

    Customer create(final String nome, final String lastName, final LocalDate birthDate, final String email);
}
