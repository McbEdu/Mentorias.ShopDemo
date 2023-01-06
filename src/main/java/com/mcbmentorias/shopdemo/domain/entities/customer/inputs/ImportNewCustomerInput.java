package com.mcbmentorias.shopdemo.domain.entities.customer.inputs;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Getter;

import java.time.LocalDate;
import java.util.Objects;

@Getter
@AllArgsConstructor
public class ImportNewCustomerInput {

    private final String name;
    private final String lastName;
    private final LocalDate birthDate;
    private final String email;

    public ImportNewCustomerInput() {
        this.name = "";
        this.lastName = "";
        this.email = "";
        this.birthDate = null;
    }

    @Override
    public boolean equals(final Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        final ImportNewCustomerInput that = (ImportNewCustomerInput) o;
        return name.equals(that.name) && lastName.equals(that.lastName) && birthDate.equals(that.birthDate) && email.equals(that.email);
    }

    @Override
    public int hashCode() {
        return Objects.hash(name, lastName, birthDate, email);
    }
}
