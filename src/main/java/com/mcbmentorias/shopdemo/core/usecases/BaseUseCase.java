package com.mcbmentorias.shopdemo.core.usecases;

import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotificationSubscriber;
import com.mcbmentorias.shopdemo.core.persistence.unitofwork.UnitOfWorkFactory;
import com.mcbmentorias.shopdemo.core.persistence.unitofwork.interfaces.IUnitOfWork;
import com.mcbmentorias.shopdemo.core.usecases.interfaces.IBaseUseCase;

public abstract class BaseUseCase<TIn, TOut> implements IBaseUseCase<TIn, TOut> {

    private final INotificationSubscriber notificationSubscriber;
    private final UnitOfWorkFactory unitOfWorkFactory;

    public BaseUseCase(
            final INotificationSubscriber notificationSubscriber,
            final UnitOfWorkFactory unitOfWorkFactory
    ) {
        this.notificationSubscriber = notificationSubscriber;
        this.unitOfWorkFactory = unitOfWorkFactory;
    }

    public abstract TOut execute(final TIn params);

    @Override
    public IUnitOfWork getUnitOfWork() {
        return this.unitOfWorkFactory.create();
    }

    protected Boolean hasNotification() {
        return this.notificationSubscriber.hasNotification();
    }
}
