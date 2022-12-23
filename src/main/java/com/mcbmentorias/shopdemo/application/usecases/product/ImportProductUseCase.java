package com.mcbmentorias.shopdemo.application.usecases.product;

import com.mcbmentorias.shopdemo.application.dtos.inputmodel.ImportProductInputModel;
import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotificationSubscriber;
import com.mcbmentorias.shopdemo.core.persistence.unitofwork.UnitOfWorkFactory;
import com.mcbmentorias.shopdemo.core.usecases.BaseUseCase;
import com.mcbmentorias.shopdemo.domain.factories.CreateImportNewProductInputFactory;
import com.mcbmentorias.shopdemo.domain.services.interfaces.IProductService;
import org.springframework.stereotype.Service;

@Service
public class ImportProductUseCase extends BaseUseCase<ImportProductInputModel, Boolean> {

    private final IProductService service;
    private final CreateImportNewProductInputFactory factory;

    public ImportProductUseCase(
            final INotificationSubscriber notificationSubscriber,
            final IProductService service,
            final CreateImportNewProductInputFactory factory,
            final UnitOfWorkFactory unitOfWorkFactory
    ) {
        super(notificationSubscriber, unitOfWorkFactory);
        this.service = service;
        this.factory = factory;
    }

    @Override
    public Boolean execute(final ImportProductInputModel input) {
        this.service.importProduct(
            this.factory.create(input)
        );

        if(!this.hasNotification()) return Boolean.TRUE;

        return Boolean.FALSE;
    }
}
