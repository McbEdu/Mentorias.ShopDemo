package com.mcbmentorias.shopdemo.core.patterns.observer;

import com.mcbmentorias.shopdemo.core.patterns.observer.intefaces.IPublisher;
import com.mcbmentorias.shopdemo.core.patterns.observer.intefaces.ISubscriber;

import java.util.Collection;
import java.util.Collections;
import java.util.HashSet;
import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;

public abstract class BasePublisher implements IPublisher {

    private final Map<Class, Collection<Class<? extends ISubscriber>>> subscribers;

    public BasePublisher() {
        this.subscribers = new ConcurrentHashMap<>();
    }

    @Override
    public <TSubscriber extends ISubscriber, TSubject> void subscriber(
            final Class<TSubscriber> subscriber,
            final Class<TSubject> subject
    ) {
        this.addSubjectIfNotExists(subject);
        this.subscribers.get(subject).add(subscriber);
    }

    private <TSubject> void addSubjectIfNotExists(final Class<TSubject> subject) {
        if(this.subscribers.containsKey(subject)) {
            return;
        }

        this.subscribers.put(subject, new HashSet<>());
    }

    public abstract ISubscriber getSubscriberInstance(final Class<? extends ISubscriber> subscriber);

    @Override
    public <TSubject> Boolean publisher(final TSubject subject) {
        final var subscribers = this.getSubscribersBySubject(subject);

        subscribers
                .forEach(subscriber -> {
                    this.getSubscriberInstance(subscriber).update(subject);
                });

        return Boolean.TRUE;
    }

    private <TSubject> Collection<Class<? extends ISubscriber>> getSubscribersBySubject(final TSubject subject) {
        final var subjectType = subject.getClass();

        if(!this.subscribers.containsKey(subjectType)) {
            return Collections.emptyList();
        }

        return this.subscribers.get(subjectType);
    }
}
