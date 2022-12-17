package com.mcbmentorias.shopdemo.domain.entities.product;

import com.mcbmentorias.shopdemo.core.interfaces.IAggregateRoot;
import com.mcbmentorias.shopdemo.core.patterns.validator.models.ValidationResult;
import com.mcbmentorias.shopdemo.domain.entities.base.BaseEntity;
import com.mcbmentorias.shopdemo.domain.entities.product.inputs.CreateNewProductInput;
import com.mcbmentorias.shopdemo.domain.entities.product.validations.CreateNewProductInputValidation;
import lombok.Getter;
import org.apache.logging.log4j.util.Supplier;

import javax.persistence.Entity;
import javax.persistence.Transient;

@Entity
@Getter
public class Product extends BaseEntity implements IAggregateRoot {

    private String code;

    private String description;

    @Transient
    private CreateNewProductInputValidation createNewProductInputValidation;

    public Product(
        final CreateNewProductInputValidation createNewProductInputValidation
    ) {
        this.code = "";
        this.description = "";
    }



    public void importProduct(
            final CreateNewProductInput input
    ) {
        if(!this.validate(() -> createNewProductInputValidation.validate(input))) {
            return;
        }

        this.createNewEntity("import");

        this.setCode(input.getCode())
            .setDescription(input.getDescription());
    }

    private Product setCode(final String code) {
        this.code = code;
        return this;
    }

    private Product setDescription(final String description) {
        this.description = description;
        return this;
    }

}
