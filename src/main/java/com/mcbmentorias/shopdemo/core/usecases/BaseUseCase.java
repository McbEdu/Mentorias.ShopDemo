package com.mcbmentorias.shopdemo.core.usecases;

import com.mcbmentorias.shopdemo.core.usecases.interfaces.IBaseUseCase;

public abstract class BaseUseCase<TOut> implements IBaseUseCase<TOut> {

    public abstract TOut execute();
}
