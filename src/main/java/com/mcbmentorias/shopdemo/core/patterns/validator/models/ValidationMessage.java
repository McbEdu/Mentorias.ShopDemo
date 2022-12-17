package com.mcbmentorias.shopdemo.core.patterns.validator.models;

import com.mcbmentorias.shopdemo.core.patterns.validator.enums.ValidationTypeMessage;
import lombok.AllArgsConstructor;
import lombok.Getter;

@Getter
@AllArgsConstructor
public class ValidationMessage {

    private final ValidationTypeMessage validationTypeMessage;
    private final String field;
    private final Object attemptValue;
    private final String code;
    private final String description;
}
