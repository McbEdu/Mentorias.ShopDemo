package com.mcbmentorias.shopdemo.domain.entities;

import com.mcbmentorias.shopdemo.core.interfaces.IAggregateRoot;
import com.mcbmentorias.shopdemo.domain.entities.user.inputs.CreateNewCustomerInput;
import com.mcbmentorias.shopdemo.domain.entities.user.validations.CreateNewCustomerInputValidation;
import jakarta.persistence.Entity;
import lombok.Getter;
import lombok.NoArgsConstructor;

import javax.persistence.Entity;
import java.time.LocalDate;
import java.util.UUID;

@Entity
@Getter
@NoArgsConstructor
public class Customer implements IAggregateRoot {

    private UUID id;

    private String name;

    private String lastName;

    private LocalDate birthDate;

    private String email;

    private CreateNewCustomerInputValidation validation;

    public void create(
        final CreateNewCustomerInput input
    ) {

        this.validation.validate();

        this.id = UUID.randomUUID();
        this.name = name;
        this.lastName = lastName;
        this.birthDate = birthDate;
        this.email = email;
    }

    public void fill(
            final UUID id,
            final String name,
            final String lastName,
            final LocalDate birthDate,
            final String email
    ) {
        this.id = id;
        this.name = name;
        this.lastName = lastName;
        this.birthDate = birthDate;
        this.email = email;
    }

}