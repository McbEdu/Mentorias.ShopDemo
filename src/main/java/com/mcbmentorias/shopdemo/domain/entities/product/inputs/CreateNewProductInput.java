package com.mcbmentorias.shopdemo.domain.entities.product.inputs;

import lombok.AllArgsConstructor;
import lombok.Getter;

@Getter
@AllArgsConstructor
public class CreateNewProductInput {

    private String code;
    private String description;

    public CreateNewProductInput() {
        this.code = "";
        this.description = "";
    }
}
