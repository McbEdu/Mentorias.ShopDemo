package com.mcbmentorias.shopdemo.core.patterns.notification.interfaces;

public interface INotificationPublisher {
    void subscriber(final Class<INotificationSubscriber> subscriber);
    void publisherNotification(final INotification notification);
}
