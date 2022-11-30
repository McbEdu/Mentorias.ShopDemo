package com.mcbmentorias.shopdemo.domain.entities.user.validations;

import br.com.fluentvalidator.context.Error;
import br.com.fluentvalidator.handler.HandlerInvalidField;
import br.com.fluentvalidator.predicate.ComparablePredicate;
import br.com.fluentvalidator.predicate.DatePredicate;
import br.com.fluentvalidator.predicate.LocalDatePredicate;
import br.com.fluentvalidator.predicate.StringPredicate;
import com.mcbmentorias.shopdemo.domain.entities.Customer;

import br.com.fluentvalidator.AbstractValidator;
import com.mcbmentorias.shopdemo.domain.entities.user.inputs.CreateNewCustomerInput;

import java.time.Instant;
import java.time.LocalDate;
import java.time.OffsetTime;
import java.time.ZoneId;
import java.util.Collection;
import java.util.TimeZone;

import static br.com.fluentvalidator.predicate.CollectionPredicate.empty;
import static br.com.fluentvalidator.predicate.ObjectPredicate.nullValue;
import static java.util.function.Predicate.not;

public class CreateNewCustomerInputValidation {


}

class CreateUserValidationFluent extends AbstractValidator<CreateNewCustomerInput> {

    @Override
    public void rules() {
        ruleFor(CreateNewCustomerInput::getName)
                .must(not(StringPredicate.stringEmptyOrNull()))
                .withMessage("Name is required!")
                .withFieldName("name")
                .must(StringPredicate.stringSizeLessThan(50))
                .when(not(StringPredicate.stringEmptyOrNull()))
                .withMessage("Name cannot be biggest than 50 character.")
                .withFieldName("name");

        ruleFor(CreateNewCustomerInput::getLastName)
                .must(not(StringPredicate.stringEmptyOrNull()))
                .withMessage("LastName is required!")
                .withFieldName("lastName")
                .must(StringPredicate.stringSizeLessThan(50))
                .when(not(StringPredicate.stringEmptyOrNull()))
                .withMessage("LastName cannot be biggest than 50 character.")
                .withFieldName("lastName");

        ruleFor(CreateNewCustomerInput::getBirthDate)
                .must(not(nullValue()))
                .withMessage("BirthDate is required!")
                .withFieldName("BirthDate")
                .must(LocalDatePredicate.localDateBeforeOrEqualToday())
                .when(not(nullValue()))
                .withMessage("BirthDate must be before or equal today.")
                .withFieldName("BirthDate");

        ruleFor(CreateNewCustomerInput::getEmail)
                .must(not(StringPredicate.stringEmptyOrNull()))
                .withMessage("Email is required!")
                .withFieldName("email")
                .must(StringPredicate.stringMatches("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$"))
                .when(not(StringPredicate.stringEmptyOrNull()))
                .withMessage("Email must be in pattern example@example.com?.br")
                .withFieldName("email");

    }
}
