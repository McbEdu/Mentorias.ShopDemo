package com.mcbmentorias.shopdemo.domain.entities.customer.inputs;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Getter;

import java.time.LocalDate;

@Getter
@AllArgsConstructor
public class ImportNewCustomerInput {

    private final String name;
    private final String lastName;
    private final LocalDate birthDate;
    private final String email;

    public ImportNewCustomerInput() {
        this.name = "";
        this.lastName = "";
        this.email = "";
        this.birthDate = null;
    }
}
