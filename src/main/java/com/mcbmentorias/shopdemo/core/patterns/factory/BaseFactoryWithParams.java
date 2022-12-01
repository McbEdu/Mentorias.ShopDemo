package com.mcbmentorias.shopdemo.core.patterns.factory;

import com.mcbmentorias.shopdemo.core.patterns.factory.interfaces.IFactoryWithParams;

public abstract class BaseFactoryWithParams<TIn, TOut> extends BaseFactory<TOut> implements IFactoryWithParams<TIn, TOut> {

    @Override
    public TOut create() {
        return null;
    }

    @Override
    public abstract TOut create(final TIn params);
}
