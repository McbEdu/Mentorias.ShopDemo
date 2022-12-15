package com.mcbmentorias.shopdemo.core.patterns.notification.models;

import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotification;
import lombok.AllArgsConstructor;
import lombok.Getter;

@Getter
@AllArgsConstructor
public class Notification implements INotification {

    private final String field;
    private final String message;
    private final Object attemptValue;

    public Notification() {
        this.field = "";
        this.message = "";
        this.attemptValue = null;
    }
}
