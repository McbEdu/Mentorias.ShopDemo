package com.mcbmentorias.shopdemo.application.controllers;

import com.mcbmentorias.shopdemo.application.dtos.inputmodel.ImportCustomerInputModel;
import com.mcbmentorias.shopdemo.application.usecases.ImportUsersUseCase;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping(value = "/api/v1/users")
public class UserController {

    private final ImportUsersUseCase importUsersUseCase;

    public UserController(final ImportUsersUseCase importUsersUseCase) {
        this.importUsersUseCase = importUsersUseCase;
    }


    @PostMapping(value = "/import")
    public ResponseEntity<Void> importUser(
            @RequestBody ImportCustomerInputModel input
    ) {
        final var result = this.importUsersUseCase.execute(input);
        return ResponseEntity.ok(result);
    }

}
