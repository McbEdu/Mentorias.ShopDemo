package com.mcbmentorias.shopdemo.application.controllers;

import com.mcbmentorias.shopdemo.application.controllers.base.BaseController;
import com.mcbmentorias.shopdemo.application.dtos.inputmodel.ImportProductInputModel;
import com.mcbmentorias.shopdemo.application.usecases.product.ImportProductBatchUseCase;
import com.mcbmentorias.shopdemo.application.usecases.product.ImportProductUseCase;
import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotificationSubscriber;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.Collection;

@RestController
@RequestMapping(value = "/api/v1/products")
public class ProductController extends BaseController {

    private final ImportProductUseCase importProductUseCase;
    private final ImportProductBatchUseCase importProductBatchUseCase;

    public ProductController(
            final INotificationSubscriber notificationSubscriber,
            final ImportProductUseCase importProductUseCase,
            final ImportProductBatchUseCase importProductBatchUseCase) {
        super(notificationSubscriber);
        this.importProductUseCase = importProductUseCase;
        this.importProductBatchUseCase = importProductBatchUseCase;
    }

    @PostMapping(value = "/import")
    public ResponseEntity importProduct(
            final @RequestBody ImportProductInputModel input
    ) {
        final var result = this.importProductUseCase.execute(input);

        if(!result) {
            return ResponseEntity.badRequest().body(this.getDomainNotifications());
        }

        return ResponseEntity.ok().build();
    }

    @PostMapping(value = "/import-batch")
    public ResponseEntity importProductBatch(
            final @RequestBody Collection<ImportProductInputModel> input
    ) {
        final var result = this.importProductBatchUseCase.execute(input);

        if(!result) {
            return ResponseEntity.badRequest().body(this.getDomainNotifications());
        }

        return ResponseEntity.ok().build();
    }
}
