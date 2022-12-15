package com.mcbmentorias.shopdemo.domain.entities.product.validations;

import br.com.fluentvalidator.predicate.StringPredicate;
import com.mcbmentorias.shopdemo.core.patterns.validator.BaseValidator;
import com.mcbmentorias.shopdemo.domain.entities.product.inputs.CreateNewProductInput;
import org.springframework.stereotype.Component;

import java.util.function.Predicate;

@Component
public class CreateNewProductInputValidation extends BaseValidator<CreateNewProductInput> {

    @Override
    protected void configureConcreteValidator(
            final BaseValidator<CreateNewProductInput>.FluentValidatorWrapper<CreateNewProductInput> wrapper
    ) {
        wrapper.ruleFor(CreateNewProductInput::getCode)
                .must(Predicate.not(StringPredicate.stringEmptyOrNull()))
                .withMessage("Code is requied!")
                .withFieldName("code")
                .must(StringPredicate.stringSizeLessThan(150))
                .when(Predicate.not(StringPredicate.stringEmptyOrNull()))
                .withMessage("Code length must be less than 150 characters.")
                .withFieldName("code");

        wrapper.ruleFor(CreateNewProductInput::getDescription)
                .must(Predicate.not(StringPredicate.stringEmptyOrNull()))
                .withMessage("Description is requied!")
                .withFieldName("description")
                .must(StringPredicate.stringSizeLessThan(500))
                .when(Predicate.not(StringPredicate.stringEmptyOrNull()))
                .withMessage("Description length must be less than 500 characters.")
                .withFieldName("description");
    }
}
