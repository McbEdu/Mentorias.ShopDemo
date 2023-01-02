package com.mcbmentorias.shopdemo.application.dtos.inputmodel;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;

import java.time.OffsetDateTime;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;

@Getter
@AllArgsConstructor
public class ImportOrderInputModel {
    private final String code;
    private final OffsetDateTime date;
    private final ImportCustomerInputModel costumer;
    private final Collection<ImportProductInputModel> products;

    public ImportOrderInputModel() {
        this.code = "";
        this.date = null;
        this.costumer = null;
        this.products = new ArrayList<>();
    }
}
