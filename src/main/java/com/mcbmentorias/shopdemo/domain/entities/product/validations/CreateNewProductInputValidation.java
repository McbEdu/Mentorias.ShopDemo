package com.mcbmentorias.shopdemo.domain.entities.product.validations;

import br.com.fluentvalidator.predicate.StringPredicate;
import com.mcbmentorias.shopdemo.core.patterns.validator.BaseValidator;
import com.mcbmentorias.shopdemo.domain.entities.product.inputs.CreateNewImportProductInput;
import org.springframework.stereotype.Component;

import java.util.function.Predicate;

@Component
public class CreateNewProductInputValidation extends BaseValidator<CreateNewImportProductInput> {

    @Override
    protected void configureConcreteValidator(
            final BaseValidator<CreateNewImportProductInput>.FluentValidatorWrapper<CreateNewImportProductInput> wrapper
    ) {
        wrapper.ruleFor(CreateNewImportProductInput::getCode)
                .must(Predicate.not(StringPredicate.stringEmptyOrNull()))
                .withMessage("Code is requied!")
                .withFieldName("code")
                .must(StringPredicate.stringSizeLessThan(150))
                .when(Predicate.not(StringPredicate.stringEmptyOrNull()))
                .withMessage("Code length must be less than 150 characters.")
                .withFieldName("code");

        wrapper.ruleFor(CreateNewImportProductInput::getDescription)
                .must(Predicate.not(StringPredicate.stringEmptyOrNull()))
                .withMessage("Description is requied!")
                .withFieldName("description")
                .must(StringPredicate.stringSizeLessThan(500))
                .when(Predicate.not(StringPredicate.stringEmptyOrNull()))
                .withMessage("Description length must be less than 500 characters.")
                .withFieldName("description");
    }
}
