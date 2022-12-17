package com.mcbmentorias.shopdemo.core.usecases;

import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotificationSubscriber;
import com.mcbmentorias.shopdemo.core.usecases.interfaces.IBaseUseCase;

public abstract class BaseUseCase<TIn, TOut> implements IBaseUseCase<TIn, TOut> {

    private final INotificationSubscriber notificationSubscriber;

    public BaseUseCase(final INotificationSubscriber notificationSubscriber) {
        this.notificationSubscriber = notificationSubscriber;
    }

    public abstract TOut execute(final TIn params);

    protected Boolean hasNotification() {
        return this.notificationSubscriber.hasNotification();
    }
}
