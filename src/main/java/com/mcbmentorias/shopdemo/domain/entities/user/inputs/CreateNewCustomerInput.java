package com.mcbmentorias.shopdemo.domain.entities.user.inputs;

import lombok.Builder;
import lombok.Getter;

import java.time.LocalDate;

@Getter
@Builder
public class CreateNewCustomerInput {

    private final String name;
    private final String lastName;
    private final LocalDate birthDate;
    private final String email;

    public CreateNewCustomerInput() {
        this.name = "";
        this.lastName = "";
        this.email = "";
        this.birthDate = null;
    }
}
