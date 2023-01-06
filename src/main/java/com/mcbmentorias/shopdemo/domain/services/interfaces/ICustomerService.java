package com.mcbmentorias.shopdemo.domain.services.interfaces;

import com.mcbmentorias.shopdemo.domain.entities.customer.Customer;
import com.mcbmentorias.shopdemo.domain.entities.customer.inputs.ImportNewCustomerInput;

public interface ICustomerService extends IService<Customer> {

    Boolean importCustomer(final ImportNewCustomerInput input);

    Boolean checkIfCustomerExistsByEmail(final String email);

    Customer getByEmail(final String email);

    Boolean createImportCustomerOrNotifyDifferences(final ImportNewCustomerInput inputModel);
}
