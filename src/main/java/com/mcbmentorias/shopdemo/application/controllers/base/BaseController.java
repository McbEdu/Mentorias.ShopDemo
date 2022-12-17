package com.mcbmentorias.shopdemo.application.controllers.base;

import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotification;
import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotificationSubscriber;

import java.util.Collection;

public abstract class BaseController {

    private final INotificationSubscriber notificationSubscriber;

    public BaseController(final INotificationSubscriber notificationSubscriber) {
        this.notificationSubscriber = notificationSubscriber;
    }

    protected Collection<INotification> getDomainNotifications() {
        return this.notificationSubscriber.getNotifications();
    }
}
