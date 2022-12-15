package com.mcbmentorias.shopdemo.application.controllers;

import com.mcbmentorias.shopdemo.application.dtos.inputmodel.ImportProductInputModel;
import com.mcbmentorias.shopdemo.application.usecases.product.ImportProductUseCase;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping(value = "/api/v1/products")
public class ProductController {

    private final ImportProductUseCase importProductUseCase;

    public ProductController(
            final ImportProductUseCase importProductUseCase
    ) {
        this.importProductUseCase = importProductUseCase;
    }

    @PostMapping(value = "/import")
    public ResponseEntity importProduct(
            final ImportProductInputModel input
    ) {
        final var result = this.importProductUseCase.execute(input);
        return ResponseEntity.ok(result);
    }
}
