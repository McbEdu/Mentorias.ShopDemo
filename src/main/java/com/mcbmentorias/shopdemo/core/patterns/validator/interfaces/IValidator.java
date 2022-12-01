package com.mcbmentorias.shopdemo.core.patterns.validator.interfaces;

import com.mcbmentorias.shopdemo.core.patterns.validator.models.ValidationResult;

public interface IValidator<T> {
    ValidationResult validate(T instance);
}
