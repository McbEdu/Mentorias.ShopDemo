package com.mcbmentorias.shopdemo.core.patterns.observer;

import com.mcbmentorias.shopdemo.core.patterns.observer.intefaces.ISubscriber;

public abstract class BaseSubscriber<TSubject> implements ISubscriber<TSubject> {

    @Override
    public abstract void update(final TSubject subject);
}
