package com.mcbmentorias.shopdemo.configurations;

import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotificationPublisher;
import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotificationSubscriber;
import org.springframework.boot.CommandLineRunner;
import org.springframework.context.annotation.Configuration;

@Configuration
public class NotificationPublisherConfig implements CommandLineRunner {

    private final INotificationPublisher notificationPublisher;

    public NotificationPublisherConfig(final INotificationPublisher notificationPublisher) {
        this.notificationPublisher = notificationPublisher;
    }

    @Override
    public void run(final String... args) {
        this.notificationPublisher.subscriber(
                INotificationSubscriber.class
        );
    }
}
