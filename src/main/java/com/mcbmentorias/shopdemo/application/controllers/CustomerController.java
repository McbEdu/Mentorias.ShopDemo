package com.mcbmentorias.shopdemo.application.controllers;

import com.mcbmentorias.shopdemo.application.controllers.base.BaseController;
import com.mcbmentorias.shopdemo.application.dtos.inputmodel.ImportCustomerInputModel;
import com.mcbmentorias.shopdemo.application.usecases.customer.ImportCustomerBatchesUseCase;
import com.mcbmentorias.shopdemo.application.usecases.customer.ImportCustomerUseCase;
import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotificationSubscriber;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.Collection;

@RestController
@RequestMapping(value = "/api/v1/customer")
public class CustomerController extends BaseController {

    private final ImportCustomerUseCase importUsersUseCase;
    private final ImportCustomerBatchesUseCase importCustomerBatchUseCase;

    public CustomerController(
            final INotificationSubscriber notificationSubscriber,
            final ImportCustomerUseCase importUsersUseCase,
            final ImportCustomerBatchesUseCase importCustomerBatchUseCase
    ) {
        super(notificationSubscriber);
        this.importUsersUseCase = importUsersUseCase;
        this.importCustomerBatchUseCase = importCustomerBatchUseCase;
    }

    @PostMapping(value = "/import")
    public ResponseEntity importCustomer(
            @RequestBody ImportCustomerInputModel input
    ) {
        final var result = this.importUsersUseCase.execute(input);

        if(!result) {
            return ResponseEntity.badRequest().body(this.getDomainNotifications());
        }

        return ResponseEntity.ok().build();
    }

    @PostMapping(value = "/import-batch")
    public ResponseEntity importCustomerBatch(
            @RequestBody Collection<ImportCustomerInputModel> input
    ) {
        final var result = this.importCustomerBatchUseCase.execute(input);

        if(!result) {
            return ResponseEntity.badRequest().build();
        }

        return ResponseEntity.ok().build();
    }

}
