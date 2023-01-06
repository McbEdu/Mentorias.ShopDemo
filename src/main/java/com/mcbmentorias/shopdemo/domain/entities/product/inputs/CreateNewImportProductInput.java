package com.mcbmentorias.shopdemo.domain.entities.product.inputs;

import lombok.AllArgsConstructor;
import lombok.Getter;

@Getter
@AllArgsConstructor
public class CreateNewImportProductInput {

    private String code;
    private String description;

    public CreateNewImportProductInput() {
        this.code = "";
        this.description = "";
    }
}
