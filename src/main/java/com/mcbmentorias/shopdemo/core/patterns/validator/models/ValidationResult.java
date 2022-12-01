package com.mcbmentorias.shopdemo.core.patterns.validator.models;

import com.mcbmentorias.shopdemo.core.patterns.validator.enums.ValidationTypeMessage;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.Objects;

public final class ValidationResult {

    private final Collection<ValidationMessage> messages;

    public ValidationResult() {
        this.messages = new ArrayList<>();
    }

    public ValidationResult(final Collection<ValidationMessage> messages) {
        this.messages = messages;
    }

    public Collection<ValidationMessage> getMessages() {
        return Collections.unmodifiableCollection(this.messages);
    }

    public Boolean isValid() {
        return !this.hasMessage() || !this.hasError();
    }

    public Boolean hasMessage() {
        return this.messages.size() > 0;
    }

    public Boolean hasError() {
        return this.getMessages().stream()
                .filter(message -> Objects.equals(message.getValidationTypeMessage(), ValidationTypeMessage.Error))
                .findAny()
                .map(it -> Boolean.TRUE)
                .orElse(Boolean.FALSE);
    }
}
