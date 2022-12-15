package com.mcbmentorias.shopdemo.application.usecases.product;

import com.mcbmentorias.shopdemo.application.dtos.inputmodel.ImportProductInputModel;
import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotificationSubscriber;
import com.mcbmentorias.shopdemo.core.usecases.BaseUseCaseWithParams;
import com.mcbmentorias.shopdemo.domain.factories.CreateImportNewProductInputFactory;
import com.mcbmentorias.shopdemo.domain.services.interfaces.IProductService;
import org.springframework.stereotype.Service;

@Service
public class ImportProductUseCase extends BaseUseCaseWithParams<ImportProductInputModel, Void> {

    private final INotificationSubscriber notificationSubscriber;
    private final IProductService service;
    private final CreateImportNewProductInputFactory factory;

    public ImportProductUseCase(
            final INotificationSubscriber notificationSubscriber,
            final IProductService service,
            final CreateImportNewProductInputFactory factory
    ) {
        this.notificationSubscriber = notificationSubscriber;
        this.service = service;
        this.factory = factory;
    }

    @Override
    public Void execute(final ImportProductInputModel input) {
        this.service.importProduct(
            this.factory.create(input)
        );

        if(this.notificationSubscriber.hasNotification()) return null;

        final var notifications = this.notificationSubscriber.getNotifications();
        return null;
    }
}
