package com.mcbmentorias.shopdemo.core.patterns.notification.models;

import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotification;
import lombok.AllArgsConstructor;
import lombok.Getter;

@Getter
@AllArgsConstructor
public class Notification implements INotification {

    private final String field;
    private final String code;
    private final String message;
    private final Object attemptValue;
    private final String typeMessage;

    public Notification() {
        this.field = "";
        this.code = "";
        this.message = "";
        this.attemptValue = null;
        this.typeMessage = "";
    }
}
