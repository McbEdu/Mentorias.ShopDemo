package com.mcbmentorias.shopdemo.application.controllers;

import com.mcbmentorias.shopdemo.application.dtos.inputmodel.ImportCustomerInputModel;
import com.mcbmentorias.shopdemo.application.usecases.ImportCustomerBatchsUseCase;
import com.mcbmentorias.shopdemo.application.usecases.ImportCustomerUseCase;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.Collection;

@RestController
@RequestMapping(value = "/api/v1/users")
public class UserController {

    private final ImportCustomerUseCase importUsersUseCase;
    private final ImportCustomerBatchsUseCase importCustomerBatchUseCase;

    public UserController(
            final ImportCustomerUseCase importUsersUseCase,
            final ImportCustomerBatchsUseCase importCustomerBatchsUseCase
    ) {
        this.importUsersUseCase = importUsersUseCase;
        this.importCustomerBatchUseCase = importCustomerBatchsUseCase;
    }


    @PostMapping(value = "/import")
    public ResponseEntity<Void> importUser(
            @RequestBody ImportCustomerInputModel input
    ) {
        final var result = this.importUsersUseCase.execute(input);
        return ResponseEntity.ok(result);
    }

    @PostMapping(value = "/import-batch")
    public ResponseEntity<Void> importUser(
            @RequestBody Collection<ImportCustomerInputModel> input
    ) {
        final var result = this.importCustomerBatchUseCase.execute(input);
        return ResponseEntity.ok(result);
    }

}
