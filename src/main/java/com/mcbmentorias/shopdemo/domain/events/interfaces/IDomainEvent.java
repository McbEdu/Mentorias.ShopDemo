package com.mcbmentorias.shopdemo.domain.events.interfaces;

import java.time.Instant;
import java.util.UUID;

public interface IDomainEvent {
    UUID getId();
    UUID getTenantId();
    Instant getTimestamp();
    String getMessageType();
}
