package com.mcbmentorias.shopdemo.core.usecases.interfaces;

public interface IBaseUseCaseWithParams<TIn, TOut> extends IBaseUseCase<TOut> {
    TOut execute(TIn params);
}
