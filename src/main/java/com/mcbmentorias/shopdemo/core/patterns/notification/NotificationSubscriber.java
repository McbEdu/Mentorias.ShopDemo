package com.mcbmentorias.shopdemo.core.patterns.notification;

import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotification;
import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotificationSubscriber;
import com.mcbmentorias.shopdemo.core.patterns.observer.BaseSubscriber;
import org.springframework.stereotype.Component;
import org.springframework.web.context.annotation.RequestScope;

import java.util.Collection;
import java.util.Collections;
import java.util.concurrent.ConcurrentLinkedQueue;

@Component
@RequestScope
public class NotificationSubscriber extends BaseSubscriber<INotification> implements INotificationSubscriber {

    protected final Collection<INotification> notifications;

    public NotificationSubscriber() {
        this.notifications = new ConcurrentLinkedQueue<>();
    }

    public Boolean hasNotification() {
        return this.notifications.size() > 0;
    }

    public Collection<INotification> getNotifications() {
        return Collections.unmodifiableCollection(this.notifications);
    }

    @Override
    public void update(final INotification notification) {
        this.notifications.add(notification);
    }
}
