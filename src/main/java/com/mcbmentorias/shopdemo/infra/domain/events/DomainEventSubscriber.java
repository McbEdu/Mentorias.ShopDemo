package com.mcbmentorias.shopdemo.infra.domain.events;

import com.mcbmentorias.shopdemo.core.patterns.observer.BaseSubscriber;
import com.mcbmentorias.shopdemo.core.patterns.observer.intefaces.ISubscriber;
import com.mcbmentorias.shopdemo.domain.events.interfaces.IDomainEvent;
import com.mcbmentorias.shopdemo.domain.events.interfaces.IDomainEventSubscriber;
import org.springframework.context.ApplicationContext;
import org.springframework.stereotype.Component;
import org.springframework.web.context.annotation.RequestScope;

import java.util.Collection;
import java.util.Collections;
import java.util.Objects;
import java.util.concurrent.ConcurrentLinkedQueue;

@Component
@RequestScope
public class DomainEventSubscriber extends BaseSubscriber<IDomainEvent> implements IDomainEventSubscriber {

    private final Collection<IDomainEvent> domainEvents;

    public DomainEventSubscriber() {
        this.domainEvents = new ConcurrentLinkedQueue<>();
    }

    @Override
    public void update(final IDomainEvent domainEvent) {
        this.domainEvents.add(domainEvent);
    }

    @Override
    public Collection<IDomainEvent> getDomainEvents() {
        return Collections.unmodifiableCollection(this.domainEvents);
    }
}
