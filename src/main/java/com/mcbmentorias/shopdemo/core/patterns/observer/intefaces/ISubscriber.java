package com.mcbmentorias.shopdemo.core.patterns.observer.intefaces;

public interface ISubscriber<Subject> {
    void update(final Subject subject);
}
