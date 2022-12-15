package com.mcbmentorias.shopdemo.domain.entities.customer;

import com.mcbmentorias.shopdemo.core.interfaces.IAggregateRoot;
import com.mcbmentorias.shopdemo.domain.entities.base.BaseEntity;
import com.mcbmentorias.shopdemo.domain.entities.customer.inputs.CreateNewCustomerInput;
import com.mcbmentorias.shopdemo.domain.entities.customer.validations.CreateNewCustomerInputValidation;
import lombok.Getter;
import lombok.NoArgsConstructor;

import javax.persistence.Entity;
import javax.persistence.Transient;
import java.time.LocalDate;
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
    private CreateNewCustomerInputValidation validation;

    public void importCustomer(
        final CreateNewCustomerInput input
    ) {
        this.validation.validate(input);

        this.createNewEntity("import");

        this.name = input.getName();
        this.lastName = input.getLastName();
        this.birthDate = input.getBirthDate();
        this.email = input.getEmail();
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