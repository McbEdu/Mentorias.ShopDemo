package com.mcbmentorias.shopdemo.application.controllers;

import com.mcbmentorias.shopdemo.application.dtos.inputmodel.ImportOrderInputModel;
import com.mcbmentorias.shopdemo.application.usecases.orders.ImportOrderUseCase;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping(value = "/api/v1/orders")
public class OrderController {

    private final ImportOrderUseCase importOrderUseCase;

    public OrderController(final ImportOrderUseCase importOrderUseCase) {
        this.importOrderUseCase = importOrderUseCase;
    }

    @PostMapping
    public void importOrder(
            final @RequestBody ImportOrderInputModel input
    ) {
        this.importOrderUseCase.execute(input);

    }
}
