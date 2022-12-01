package com.mcbmentorias.shopdemo.core.patterns.validator.models;

import com.mcbmentorias.shopdemo.core.patterns.validator.enums.ValidationTypeMessage;
import lombok.AllArgsConstructor;
import lombok.Getter;

@Getter
@AllArgsConstructor
public class ValidationMessage {

    private ValidationTypeMessage validationTypeMessage;
    private Object attemptValue;
    private String code;
    private String description;
}
