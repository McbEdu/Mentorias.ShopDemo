package com.mcbmentorias.shopdemo.domain.services;

import com.mcbmentorias.shopdemo.domain.entities.Customer;
import com.mcbmentorias.shopdemo.domain.services.interfaces.IUserService;
import com.mcbmentorias.shopdemo.infra.data.interfaces.IUserRepository;
import org.springframework.stereotype.Service;

import java.time.LocalDate;

@Service
public class UserService implements IUserService {

    private final IUserRepository repository;

    public UserService(final IUserRepository repository) {
        this.repository = repository;
    }

    @Override
    public Customer create(
            final String nome,
            final String lastName,
            final LocalDate birthDate,
            final String email
    ) {
        final var entity = new Customer();
        entity.create(nome, lastName, birthDate, email);
        return entity;
    }
}
