package com.mcbmentorias.shopdemo.core.patterns.notification.interfaces;

import com.mcbmentorias.shopdemo.core.patterns.observer.intefaces.ISubscriber;

import java.util.Collection;

public interface INotificationSubscriber extends ISubscriber<INotification> {

    Boolean hasNotification();

    Collection<INotification> getNotifications();
}
