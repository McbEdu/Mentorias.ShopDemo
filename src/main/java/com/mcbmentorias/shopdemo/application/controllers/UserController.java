package com.mcbmentorias.shopdemo.application.controllers;

import com.mcbmentorias.shopdemo.application.dtos.inputmodel.ImportUserInputModel;
import com.mcbmentorias.shopdemo.application.usecases.ImportUsersUseCase;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.Collection;

@RestController
@RequestMapping(value = "/api/v1/users")
public class UserController {

    private final ImportUsersUseCase importUsersUseCase;




    @PostMapping(value = "/import")
    public ResponseEntity importUser(
            @RequestBody Collection<ImportUserInputModel> input
    ) {

    }

}
