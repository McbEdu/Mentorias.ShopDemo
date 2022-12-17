package com.mcbmentorias.shopdemo.application.usecases.product;

import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotificationPublisher;
import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotificationSubscriber;
import com.mcbmentorias.shopdemo.domain.events.interfaces.IDomainEventPublisher;
import com.mcbmentorias.shopdemo.domain.events.interfaces.IDomainEventSubscriber;
import com.mcbmentorias.shopdemo.domain.events.product.ProductImported;
import org.springframework.boot.CommandLineRunner;
import org.springframework.context.annotation.Configuration;

@Configuration
public class ProductBoostrap implements CommandLineRunner {

    private final IDomainEventPublisher domainEventPublisher;

    public ProductBoostrap(
            final IDomainEventPublisher domainEventPublisher
    ) {
        this.domainEventPublisher = domainEventPublisher;
    }

    @Override
    public void run(final String... args) throws Exception {
        this.domainEventPublisher.subscriberDomainEvent(
                IDomainEventSubscriber.class,
                ProductImported.class
        );
    }
}
