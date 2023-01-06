package com.mcbmentorias.shopdemo.application.usecases.orders;

import com.mcbmentorias.shopdemo.application.dtos.inputmodel.ImportCustomerInputModel;
import com.mcbmentorias.shopdemo.application.dtos.inputmodel.ImportOrderInputModel;
import com.mcbmentorias.shopdemo.application.dtos.inputmodel.ImportProductInputModel;
import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotificationSubscriber;
import com.mcbmentorias.shopdemo.core.persistence.unitofwork.UnitOfWorkFactory;
import com.mcbmentorias.shopdemo.core.usecases.BaseUseCase;
import com.mcbmentorias.shopdemo.domain.factories.CreateImportCustomerInputFactory;
import com.mcbmentorias.shopdemo.domain.factories.CreateImportNewProductInputFactory;
import com.mcbmentorias.shopdemo.domain.services.interfaces.ICustomerService;
import com.mcbmentorias.shopdemo.domain.services.interfaces.IOrderService;
import com.mcbmentorias.shopdemo.domain.services.interfaces.IProductService;

import java.util.Collection;
import java.util.stream.Collectors;

public class ImportOrderUseCase extends BaseUseCase<ImportOrderInputModel, Void> {

    private final IOrderService orderService;
    private final ICustomerService customerService;
    private final IProductService productService;

    private final CreateImportCustomerInputFactory customerInputFactory;
    private final CreateImportNewProductInputFactory productInputFactory;

    public ImportOrderUseCase(
            final INotificationSubscriber notificationSubscriber,
            final UnitOfWorkFactory unitOfWorkFactory,
            final IOrderService orderService,
            final ICustomerService customerService,
            final IProductService productService,
            final CreateImportCustomerInputFactory customerInputFactory,
            final CreateImportNewProductInputFactory productInputFactory
    ) {
        super(notificationSubscriber, unitOfWorkFactory);
        this.orderService = orderService;
        this.customerService = customerService;
        this.productService = productService;
        this.customerInputFactory = customerInputFactory;
        this.productInputFactory = productInputFactory;
    }

    @Override
    public Void execute(final ImportOrderInputModel input) {

        this.importCustomerOrNotifyDiffInformation(input.getCostumer());
        this.importProductOrNotifyDiffInformation(input.getProducts());

        return null;
    }

    private void importProductOrNotifyDiffInformation(final Collection<ImportProductInputModel> products) {
        final var domainCollection =
                products.stream().map(importProductInputModel -> this.productInputFactory.create(importProductInputModel))
                        .collect(Collectors.toList());

        this.productService.createImportProductOrNotifyDifferences(domainCollection);
    }

    private void importCustomerOrNotifyDiffInformation(final ImportCustomerInputModel input) {
        final var domainInput = this.customerInputFactory.create(input);
        this.customerService.createImportCustomerOrNotifyDifferences(domainInput);
    }
}
