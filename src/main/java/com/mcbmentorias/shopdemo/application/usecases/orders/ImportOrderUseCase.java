package com.mcbmentorias.shopdemo.application.usecases.orders;

import com.mcbmentorias.shopdemo.application.dtos.inputmodel.ImportCustomerInputModel;
import com.mcbmentorias.shopdemo.application.dtos.inputmodel.ImportOrderInputModel;
import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotificationSubscriber;
import com.mcbmentorias.shopdemo.core.persistence.unitofwork.UnitOfWorkFactory;
import com.mcbmentorias.shopdemo.core.usecases.BaseUseCase;
import com.mcbmentorias.shopdemo.domain.factories.CreateImportCustomerInputFactory;
import com.mcbmentorias.shopdemo.domain.services.interfaces.ICustomerService;
import com.mcbmentorias.shopdemo.domain.services.interfaces.IOrderService;
import com.mcbmentorias.shopdemo.domain.services.interfaces.IProductService;

public class ImportOrderUseCase extends BaseUseCase<ImportOrderInputModel, Void> {

    private final IOrderService orderService;
    private final ICustomerService customerService;
    private final IProductService productService;

    private final CreateImportCustomerInputFactory customerInputFactory;

    public ImportOrderUseCase(
            final INotificationSubscriber notificationSubscriber,
            final UnitOfWorkFactory unitOfWorkFactory,
            final IOrderService orderService,
            final ICustomerService customerService,
            final IProductService productService,
            final CreateImportCustomerInputFactory customerInputFactory
    ) {
        super(notificationSubscriber, unitOfWorkFactory);
        this.orderService = orderService;
        this.customerService = customerService;
        this.productService = productService;
        this.customerInputFactory = customerInputFactory;
    }

    @Override
    public Void execute(final ImportOrderInputModel input) {

        this.importCustomer(input.getCostumer());

        return null;
    }

    private void importCustomer(final ImportCustomerInputModel input) {
        final var domainInput = this.customerInputFactory.create(input);
        if(this.customerService.check)
        this.customerService.importCustomer(domainInput);
    }
}
