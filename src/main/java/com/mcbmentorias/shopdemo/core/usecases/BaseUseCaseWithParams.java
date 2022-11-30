package com.mcbmentorias.shopdemo.core.usecases;

import com.mcbmentorias.shopdemo.core.usecases.interfaces.IBaseUseCaseWithParams;

public abstract class BaseUseCaseWithParams<TIn, TOut> extends BaseUseCase<TOut> implements IBaseUseCaseWithParams<TIn, TOut> {

    @Override
    public TOut execute() {
        return null;
    }

    @Override
    public abstract TOut execute(final TIn params);
}
