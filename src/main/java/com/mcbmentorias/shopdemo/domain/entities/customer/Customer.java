package com.mcbmentorias.shopdemo.domain.entities.customer;

import com.mcbmentorias.shopdemo.core.interfaces.IAggregateRoot;
import com.mcbmentorias.shopdemo.domain.entities.base.BaseEntity;
import com.mcbmentorias.shopdemo.domain.entities.customer.inputs.ImportNewCustomerInput;
import com.mcbmentorias.shopdemo.domain.entities.customer.validations.ImportNewCustomerInputValidation;
import lombok.Getter;
import lombok.NoArgsConstructor;

import javax.persistence.Entity;
import javax.persistence.Transient;
import java.time.LocalDate;
import java.util.Objects;
import java.util.UUID;

@Entity
@Getter
@NoArgsConstructor
public class Customer extends BaseEntity implements IAggregateRoot {

    private String name;

    private String lastName;

    private LocalDate birthDate;

    private String email;

    @Transient
    private ImportNewCustomerInputValidation importNewCustomerInputValidation;

    public Customer(
            final ImportNewCustomerInputValidation importNewCustomerInputValidation
    ) {
        this.importNewCustomerInputValidation = importNewCustomerInputValidation;
    }

    public void importCustomer(
        final ImportNewCustomerInput input
    ) {
        if(!this.validate(() -> this.importNewCustomerInputValidation.validate(input))) {
            return;
        }

        this.createNewEntity("import");

        this.setName(input.getName())
            .setLastName(input.getLastName())
            .setBirthDate(input.getBirthDate())
            .setEmail(input.getEmail());
    }

    //Private Method
    private Customer setEmail(final String email) {
        this.email = email;
        return this;
    }

    private Customer setBirthDate(final LocalDate birthDate) {
        this.birthDate = birthDate;
        return this;
    }

    private Customer setLastName(final String lastName) {
        this.lastName = lastName;
        return this;
    }

    private Customer setName(final String name) {
        this.name = name;
        return this;
    }

    public void fill(
            final UUID id,
            final String name,
            final String lastName,
            final LocalDate birthDate,
            final String email
    ) {
        this.fillBase(id);

        this.name = name;
        this.lastName = lastName;
        this.birthDate = birthDate;
        this.email = email;
    }



}