package com.mcbmentorias.shopdemo.core.patterns.validator.models;

import com.mcbmentorias.shopdemo.core.patterns.validator.enums.ValidationTypeMessage;
import lombok.Getter;

public final class ValidationMessage {

    private ValidationTypeMessage validationTypeMessage;
    private String code;
    private String description;

    public ValidationTypeMessage getValidationTypeMessage() {
        return validationTypeMessage;
    }

    public String getCode() {
        return code;
    }

    public String getDescription() {
        return description;
    }
}
