package com.mcbmentorias.shopdemo.application.dtos.inputmodel;

import lombok.AllArgsConstructor;
import lombok.Getter;

import java.time.LocalDate;

@Getter
@AllArgsConstructor
public class ImportCustomerInputModel {

    private final String name;

    private final String lastName;

    private final LocalDate birthDate;

    private final String email;

    public ImportCustomerInputModel() {
        this.name = "";
        this.lastName = "";
        this.email = "";
        this.birthDate = null;
    }
}