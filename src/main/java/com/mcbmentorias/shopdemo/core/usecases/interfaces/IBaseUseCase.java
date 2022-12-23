package com.mcbmentorias.shopdemo.core.usecases.interfaces;

import com.mcbmentorias.shopdemo.core.persistence.unitofwork.interfaces.IUnitOfWork;

public interface IBaseUseCase<TIn, TOut> {
    TOut execute(final TIn params);

    IUnitOfWork getUnitOfWork();
}
