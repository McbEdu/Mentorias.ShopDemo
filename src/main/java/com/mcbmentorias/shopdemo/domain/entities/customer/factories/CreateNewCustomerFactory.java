package com.mcbmentorias.shopdemo.domain.entities.customer.factories;


import com.mcbmentorias.shopdemo.core.patterns.factory.BaseFactory;
import com.mcbmentorias.shopdemo.domain.entities.customer.Customer;
import com.mcbmentorias.shopdemo.domain.entities.customer.validations.ImportNewCustomerInputValidation;
import org.springframework.stereotype.Component;

@Component
public class CreateNewCustomerFactory extends BaseFactory<Customer> {

    private final ImportNewCustomerInputValidation importNewCustomerInputValidation;

    public CreateNewCustomerFactory(final ImportNewCustomerInputValidation importNewCustomerInputValidation) {
        this.importNewCustomerInputValidation = importNewCustomerInputValidation;
    }

    @Override
    public Customer create() {
        return new Customer(
                this.importNewCustomerInputValidation
        );
    }
}
