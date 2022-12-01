package com.mcbmentorias.shopdemo.core.patterns.factory.interfaces;

public interface IFactoryWithParams<TIn, TOut> extends IFactory<TOut> {
    TOut create(final TIn params);
}
