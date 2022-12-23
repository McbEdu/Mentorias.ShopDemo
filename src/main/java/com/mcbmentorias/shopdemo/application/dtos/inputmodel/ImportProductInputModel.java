package com.mcbmentorias.shopdemo.application.dtos.inputmodel;

import lombok.AllArgsConstructor;
import lombok.Getter;

@Getter
@AllArgsConstructor
public class ImportProductInputModel {

    private String code;
    private String description;

    public ImportProductInputModel() {
        this.code = "";
        this.description = "";
    }
}