package com.mcbmentorias.shopdemo.domain.entities.customer.validations;

import br.com.fluentvalidator.predicate.LocalDatePredicate;
import br.com.fluentvalidator.predicate.StringPredicate;
import com.mcbmentorias.shopdemo.core.patterns.validator.BaseValidator;
import com.mcbmentorias.shopdemo.domain.entities.customer.inputs.CreateNewCustomerInput;

import static br.com.fluentvalidator.predicate.ObjectPredicate.nullValue;
import static java.util.function.Predicate.not;

public class CreateNewCustomerInputValidation extends BaseValidator<CreateNewCustomerInput> {

    @Override
    protected void configureConcreteValidator(
            final BaseValidator<CreateNewCustomerInput>.FluentValidatorWrapper<CreateNewCustomerInput> wrapper
    ) {
        wrapper.ruleFor(CreateNewCustomerInput::getName)
                .must(not(StringPredicate.stringEmptyOrNull()))
                .withMessage("Name is required!")
                .withFieldName("name")
                .must(StringPredicate.stringSizeLessThan(50))
                .when(not(StringPredicate.stringEmptyOrNull()))
                .withMessage("Name cannot be biggest than 50 character.")
                .withFieldName("name");

        wrapper.ruleFor(CreateNewCustomerInput::getLastName)
                .must(not(StringPredicate.stringEmptyOrNull()))
                .withMessage("LastName is required!")
                .withFieldName("lastName")
                .must(StringPredicate.stringSizeLessThan(50))
                .when(not(StringPredicate.stringEmptyOrNull()))
                .withMessage("LastName cannot be biggest than 50 character.")
                .withFieldName("lastName");

        wrapper.ruleFor(CreateNewCustomerInput::getBirthDate)
                .must(not(nullValue()))
                .withMessage("BirthDate is required!")
                .withFieldName("BirthDate")
                .must(LocalDatePredicate.localDateBeforeOrEqualToday())
                .when(not(nullValue()))
                .withMessage("BirthDate must be before or equal today.")
                .withFieldName("BirthDate");

        wrapper.ruleFor(CreateNewCustomerInput::getEmail)
                .must(not(StringPredicate.stringEmptyOrNull()))
                .withMessage("Email is required!")
                .withFieldName("email")
                .must(StringPredicate.stringMatches("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$"))
                .when(not(StringPredicate.stringEmptyOrNull()))
                .withMessage("Email must be in pattern example@example.com?.br")
                .withFieldName("email");

    }
}
