package com.mcbmentorias.shopdemo.domain.entities.customer.validations;

import br.com.fluentvalidator.predicate.LocalDatePredicate;
import br.com.fluentvalidator.predicate.StringPredicate;
import com.mcbmentorias.shopdemo.core.patterns.validator.BaseValidator;
import com.mcbmentorias.shopdemo.domain.entities.customer.inputs.ImportNewCustomerInput;
import org.springframework.beans.factory.config.ConfigurableBeanFactory;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

import static br.com.fluentvalidator.predicate.ObjectPredicate.nullValue;
import static java.util.function.Predicate.not;

@Component
@Scope(ConfigurableBeanFactory.SCOPE_SINGLETON)
public class ImportNewCustomerInputValidation extends BaseValidator<ImportNewCustomerInput> {

    @Override
    protected void configureConcreteValidator(
            final BaseValidator<ImportNewCustomerInput>.FluentValidatorWrapper<ImportNewCustomerInput> wrapper
    ) {
        wrapper.ruleFor(ImportNewCustomerInput::getName)
                .must(not(StringPredicate.stringEmptyOrNull()))
                .withMessage("Name is required!")
                .withFieldName("name")
                .withCode("1")
                .must(StringPredicate.stringSizeLessThan(50))
                .when(not(StringPredicate.stringEmptyOrNull()))
                .withMessage("Name cannot be biggest than 50 character.")
                .withFieldName("name")
                .withCode("2");

        wrapper.ruleFor(ImportNewCustomerInput::getLastName)
                .must(not(StringPredicate.stringEmptyOrNull()))
                .withMessage("LastName is required!")
                .withFieldName("lastName")
                .withCode("3")
                .must(StringPredicate.stringSizeLessThan(50))
                .when(not(StringPredicate.stringEmptyOrNull()))
                .withMessage("LastName cannot be biggest than 50 character.")
                .withFieldName("lastName")
                .withCode("4");

        wrapper.ruleFor(ImportNewCustomerInput::getBirthDate)
                .must(not(nullValue()))
                .withMessage("BirthDate is required!")
                .withFieldName("BirthDate")
                .withCode("5")
                .must(LocalDatePredicate.localDateBeforeOrEqualToday())
                .when(not(nullValue()))
                .withMessage("BirthDate must be before or equal today.")
                .withFieldName("BirthDate")
                .withCode("6");

        wrapper.ruleFor(ImportNewCustomerInput::getEmail)
                .must(not(StringPredicate.stringEmptyOrNull()))
                .withMessage("Email is required!")
                .withFieldName("email")
                .withCode("7")
                .must(StringPredicate.stringMatches("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$"))
                .when(not(StringPredicate.stringEmptyOrNull()))
                .withMessage("Email must be in pattern example@example.com?.br")
                .withFieldName("email")
                .withCode("8");

    }
}
