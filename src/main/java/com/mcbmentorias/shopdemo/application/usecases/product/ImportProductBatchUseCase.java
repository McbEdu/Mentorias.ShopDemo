package com.mcbmentorias.shopdemo.application.usecases.product;

import com.mcbmentorias.shopdemo.application.dtos.inputmodel.ImportProductInputModel;
import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotificationSubscriber;
import com.mcbmentorias.shopdemo.core.persistence.unitofwork.UnitOfWorkFactory;
import com.mcbmentorias.shopdemo.core.usecases.BaseUseCase;
import com.mcbmentorias.shopdemo.domain.factories.CreateImportNewProductInputFactory;
import com.mcbmentorias.shopdemo.domain.services.interfaces.IProductService;
import org.springframework.stereotype.Service;

import java.util.Collection;

@Service
public class ImportProductBatchUseCase extends BaseUseCase<Collection<ImportProductInputModel>, Boolean> {

    private final IProductService service;
    private final CreateImportNewProductInputFactory factory;

    public ImportProductBatchUseCase(
            final INotificationSubscriber notificationSubscriber,
            final UnitOfWorkFactory unitOfWorkFactory,
            final IProductService service,
            final CreateImportNewProductInputFactory factory
    ) {
        super(notificationSubscriber, unitOfWorkFactory);
        this.service = service;
        this.factory = factory;
    }

    @Override
    public Boolean execute(final Collection<ImportProductInputModel> inputs) {
        final var unitOfWork = this.getUnitOfWork();

        try {
            unitOfWork.begin();

            inputs.forEach(input -> {
                this.service.importProduct(
                        this.factory.create(input)
                );
            });

            if(this.hasNotification()) {
                unitOfWork.rollback();
                return Boolean.FALSE;
            }

            unitOfWork.commit();
            return Boolean.TRUE;
        } catch (final Exception e) {
            unitOfWork.rollback();
            throw e;
        }
    }
}
