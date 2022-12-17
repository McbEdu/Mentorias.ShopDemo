package com.mcbmentorias.shopdemo.core.patterns.validator;

import br.com.fluentvalidator.AbstractValidator;
import com.mcbmentorias.shopdemo.core.patterns.validator.factories.ValidationResultFactory;
import com.mcbmentorias.shopdemo.core.patterns.validator.interfaces.IValidator;
import com.mcbmentorias.shopdemo.core.patterns.validator.models.ValidationResult;

public abstract class BaseValidator<T> implements IValidator<T> {

    private Boolean hasValidatorFluentValidatorWrapperInitialized = Boolean.FALSE;

    private FluentValidatorWrapper<T> wrapper;

    public BaseValidator() {
        this.wrapper = new FluentValidatorWrapper();
    }

    protected abstract void configureConcreteValidator(final FluentValidatorWrapper<T> wrapper);

    private void checkIfWrapperIsConfigured() {
        if(hasValidatorFluentValidatorWrapperInitialized) {
            return;
        }

        this.configureConcreteValidator(this.wrapper);

        this.hasValidatorFluentValidatorWrapperInitialized = Boolean.TRUE;
    }

    @Override
    public ValidationResult validate(final T instance) {
        this.checkIfWrapperIsConfigured();
        return this.createValidationResults(this.wrapper.validate(instance));
    }

    private ValidationResult createValidationResults(final br.com.fluentvalidator.context.ValidationResult validate) {
        return new ValidationResultFactory().create(validate);
    }

    public class FluentValidatorWrapper<T> extends AbstractValidator<T> {
        @Override
        public void rules() {

        }
    }

}
