package com.mcbmentorias.shopdemo.application.usecases;

import com.mcbmentorias.shopdemo.application.dtos.inputmodel.ImportUserInputModel;
import com.mcbmentorias.shopdemo.core.usecases.BaseUseCaseWithParams;
import com.mcbmentorias.shopdemo.domain.services.interfaces.IUserService;

import java.time.LocalDate;
import java.util.Collection;

public class ImportUsersUseCase extends BaseUseCaseWithParams<Collection<ImportUserInputModel>, Void> {

    private final IUserService service;

    public ImportUsersUseCase(final IUserService service) {
        this.service = service;
    }

    @Override
    public Void execute(final Collection<ImportUserInputModel> inputs) {
        inputs.forEach(input -> {
            this.service.create(
                    input.getNome(),
                    input.getLastName(),
                    input.getBirthDate(),
                    input.getEmail()
            );
        });
        return null;
    }
}
