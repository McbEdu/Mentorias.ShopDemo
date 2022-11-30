package com.mcbmentorias.shopdemo.core.usecases.interfaces;

public interface IBaseUseCase<TOut> {
    TOut execute();
}
