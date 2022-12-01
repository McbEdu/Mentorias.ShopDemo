package com.mcbmentorias.shopdemo.application.dtos.inputmodel;

import lombok.AllArgsConstructor;
import lombok.Getter;

import java.time.LocalDate;

@Getter
@AllArgsConstructor
public class ImportCustomerInputModel {

    private String nome;

    private String lastName;

    private LocalDate birthDate;

    private String email;

    public ImportCustomerInputModel() {
        this.nome = "";
        this.lastName = "";
        this.email = "";
    }
}
