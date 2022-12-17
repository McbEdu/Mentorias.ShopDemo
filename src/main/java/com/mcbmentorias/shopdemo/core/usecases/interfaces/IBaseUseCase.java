package com.mcbmentorias.shopdemo.core.usecases.interfaces;

public interface IBaseUseCase<TIn, TOut> {
    TOut execute(final TIn params);
}
