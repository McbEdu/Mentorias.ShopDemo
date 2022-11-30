package com.mcbmentorias.shopdemo.core.patterns.validator.interfaces;

import br.com.fluentvalidator.context.ValidationResult;

public interface IValidator<T> {
    ValidationResult validate(T instance);
}
