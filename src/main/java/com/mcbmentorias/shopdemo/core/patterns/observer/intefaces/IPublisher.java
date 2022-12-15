package com.mcbmentorias.shopdemo.core.patterns.observer.intefaces;

public interface IPublisher {
    <TSubject> Boolean publisher(final  TSubject message);

    <TSubscriber extends ISubscriber, TSubject> void subscriber(
            final Class<TSubscriber> subscriber,
            final Class<TSubject> subject
    );
}
