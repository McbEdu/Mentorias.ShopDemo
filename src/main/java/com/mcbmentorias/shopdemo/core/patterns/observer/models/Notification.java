package com.mcbmentorias.shopdemo.core.patterns.observer.models;

import com.mcbmentorias.shopdemo.core.patterns.observer.intefaces.INotification;
import lombok.AllArgsConstructor;
import lombok.Getter;

@Getter
@AllArgsConstructor
public class Notification implements INotification {

    private final String code;
    private final String message;

    public Notification() {
        this.code = "";
        this.message = "";
    }

    @Override
    public String getCode() {
        return this.code;
    }

    @Override
    public String getMessage() {
        return this.message;
    }
}
