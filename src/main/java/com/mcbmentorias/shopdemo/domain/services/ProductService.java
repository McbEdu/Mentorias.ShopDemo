package com.mcbmentorias.shopdemo.domain.services;

import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotificationPublisher;
import com.mcbmentorias.shopdemo.core.patterns.notification.models.Notification;
import com.mcbmentorias.shopdemo.core.patterns.validator.enums.ValidationTypeMessage;
import com.mcbmentorias.shopdemo.domain.entities.product.factories.ProductFactory;
import com.mcbmentorias.shopdemo.domain.entities.product.inputs.CreateNewProductInput;
import com.mcbmentorias.shopdemo.domain.repositories.IProductRepository;
import com.mcbmentorias.shopdemo.domain.services.base.BaseService;
import com.mcbmentorias.shopdemo.domain.services.interfaces.IProductService;
import org.springframework.stereotype.Service;

@Service
public class ProductService extends BaseService implements IProductService {

    private final IProductRepository repository;
    private final ProductFactory productFactory;

    public ProductService(
            final INotificationPublisher notificationPublisher,
            final IProductRepository repository,
            final ProductFactory productFactory
    ) {
        super(notificationPublisher);
        this.repository = repository;
        this.productFactory = productFactory;
    }

    @Override
    public Boolean importProduct(final CreateNewProductInput input) {
        if(this.repository.checkIfProductExists(input.getCode())) {
            this.notificationPublisher.publisherNotification(
                    new Notification(
                            "code",
                            "11",
                            "product already exists",
                            input.getCode(),
                            ValidationTypeMessage.Error.name()
                    )
            );

            return Boolean.FALSE;
        }

        final var product = this.productFactory.create();
        product.importProduct(input);

        if(!this.validateDomainEntityAndNotification(product)) {
            return Boolean.FALSE;
        }

        this.repository.save(product);

        return Boolean.TRUE;
    }
}
