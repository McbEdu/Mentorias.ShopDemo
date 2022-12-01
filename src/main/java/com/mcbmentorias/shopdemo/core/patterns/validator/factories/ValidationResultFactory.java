package com.mcbmentorias.shopdemo.core.patterns.validator.factories;

import com.mcbmentorias.shopdemo.core.patterns.factory.BaseFactoryWithParams;
import com.mcbmentorias.shopdemo.core.patterns.validator.enums.ValidationTypeMessage;
import com.mcbmentorias.shopdemo.core.patterns.validator.models.ValidationMessage;
import com.mcbmentorias.shopdemo.core.patterns.validator.models.ValidationResult;

import java.util.stream.Collectors;

public class ValidationResultFactory extends BaseFactoryWithParams<br.com.fluentvalidator.context.ValidationResult, ValidationResult> {

    @Override
    public ValidationResult create(final br.com.fluentvalidator.context.ValidationResult params) {
        final var valiations = params.getErrors()
                .stream().map(errors -> {
                    return new ValidationMessage(
                            ValidationTypeMessage.Error,
                            errors.getAttemptedValue(),
                            errors.getCode(),
                            errors.getMessage()
                    );
                }).collect(Collectors.toList());

        return new ValidationResult(valiations);
    }
}
