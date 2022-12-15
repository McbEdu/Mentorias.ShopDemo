package com.mcbmentorias.shopdemo.domain.events.interfaces;

import com.mcbmentorias.shopdemo.core.patterns.observer.intefaces.ISubscriber;

import java.util.Collection;

public interface IDomainEventSubscriber extends ISubscriber<IDomainEvent> {
    Collection<IDomainEvent> getDomainEvents();
}
