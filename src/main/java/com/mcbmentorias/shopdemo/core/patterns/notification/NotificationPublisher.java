package com.mcbmentorias.shopdemo.core.patterns.notification;

import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotification;
import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotificationPublisher;
import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotificationSubscriber;
import com.mcbmentorias.shopdemo.core.patterns.observer.BasePublisher;
import com.mcbmentorias.shopdemo.core.patterns.observer.intefaces.ISubscriber;
import org.springframework.context.ApplicationContext;
import org.springframework.stereotype.Component;

import java.util.Objects;

@Component
public class NotificationPublisher extends BasePublisher implements INotificationPublisher {

    private final ApplicationContext context;

    public NotificationPublisher(final ApplicationContext context) {
        super();
        this.context = context;
    }

    @Override
    public void subscriber(final Class<INotificationSubscriber> subscriber) {
        this.subscriber(
            subscriber,
            INotification.class
        );
    }

    @Override
    public ISubscriber getSubscriberInstance(final Class<? extends ISubscriber> subscriber) {
        final var instance = this.context.getBean(subscriber);

        if(Objects.isNull(instance)) {
            throw new RuntimeException("Deu erro");
        }
        return instance;
    }

    public void publisherNotification(final INotification notification) {
        this.publisher(notification);
    }
}
