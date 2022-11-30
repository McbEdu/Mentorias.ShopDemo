package com.mcbmentorias.shopdemo.core.patterns.validator.enums;

public enum ValidationTypeMessage {
    Information(1),
    Warning(2),
    Error(3);

    private int value;

    ValidationTypeMessage(final int value) {
        this.value = value;
    }
}
