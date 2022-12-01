package com.mcbmentorias.shopdemo.core.patterns.factory;

import com.mcbmentorias.shopdemo.core.patterns.factory.interfaces.IFactory;

public abstract class BaseFactory<TOut> implements IFactory<TOut> {

    @Override
    public abstract TOut create();
}
