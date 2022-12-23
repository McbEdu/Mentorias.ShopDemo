package com.mcbmentorias.shopdemo.domain.services.base;

import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotificationPublisher;
import com.mcbmentorias.shopdemo.core.patterns.notification.models.Notification;
import com.mcbmentorias.shopdemo.domain.entities.base.BaseEntity;

public abstract class BaseService {

    protected final INotificationPublisher notificationPublisher;

    public BaseService(final INotificationPublisher notificationPublisher) {
        this.notificationPublisher = notificationPublisher;
    }

    protected Boolean validateDomainEntityAndNotification(final BaseEntity entity) {
        if(entity.isValid())
            return Boolean.TRUE;

        entity.getErrors().forEach(notification -> {
                this.notificationPublisher.publisherNotification(
                        new Notification(
                                notification.getField(),
                                notification.getCode(),
                                notification.getDescription(),
                                notification.getAttemptValue(),
                                notification.getValidationTypeMessage().name()
                        )
                );
        });

        return Boolean.FALSE;
    }
}
