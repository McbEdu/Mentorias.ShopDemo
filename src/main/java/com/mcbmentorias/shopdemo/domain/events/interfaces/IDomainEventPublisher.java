package com.mcbmentorias.shopdemo.domain.events.interfaces;

import com.mcbmentorias.shopdemo.core.patterns.observer.intefaces.IPublisher;

public interface IDomainEventPublisher extends IPublisher {

    void subscriberDomainEvent(
            final Class<IDomainEventSubscriber> subscriber,
            final Class<? extends IDomainEvent> event
    );

    Boolean publisherDomainEvent(final IDomainEvent domainEvent);
}
