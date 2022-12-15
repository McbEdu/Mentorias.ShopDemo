package com.mcbmentorias.shopdemo.infra.domain.events;

import com.mcbmentorias.shopdemo.core.patterns.observer.BasePublisher;
import com.mcbmentorias.shopdemo.core.patterns.observer.intefaces.ISubscriber;
import com.mcbmentorias.shopdemo.domain.events.interfaces.IDomainEvent;
import com.mcbmentorias.shopdemo.domain.events.interfaces.IDomainEventPublisher;
import com.mcbmentorias.shopdemo.domain.events.interfaces.IDomainEventSubscriber;
import org.springframework.context.ApplicationContext;
import org.springframework.stereotype.Component;

import java.util.Objects;

@Component
public class DomainEventPublisher extends BasePublisher implements IDomainEventPublisher {

    private final ApplicationContext dependencyContainer;

    public DomainEventPublisher(final ApplicationContext dependencyContainer) {
        this.dependencyContainer = dependencyContainer;
    }

    @Override
    public ISubscriber getSubscriberInstance(final Class<? extends ISubscriber> subscriber) {
        final var instance = this.dependencyContainer.getBean(subscriber);

        if(Objects.isNull(instance)) {
            throw new RuntimeException("Cannot instantiate " + subscriber.getName() + " class not found");
        }

        return instance;
    }

    @Override
    public Boolean publisherDomainEvent(final IDomainEvent domainEvent) {
        return this.publisher(domainEvent);
    }

    @Override
    public void subscriberDomainEvent(
            final Class<IDomainEventSubscriber> subscriber,
            final Class<? extends IDomainEvent> event
    ) {
        this.subscriber(
                subscriber,
                event
        );
    }
}
