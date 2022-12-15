package com.mcbmentorias.shopdemo.domain.events.models;

import com.mcbmentorias.shopdemo.domain.events.interfaces.IDomainEvent;
import lombok.AllArgsConstructor;
import lombok.Getter;

import java.time.Instant;
import java.util.UUID;

@Getter
@AllArgsConstructor
public abstract class BaseDomainEvent implements IDomainEvent {

    private final UUID id;
    private final UUID tenantId;
    private final Instant timestamp;
    private final String messageType;

    public BaseDomainEvent() {
        this.id = UUID.randomUUID();
        this.tenantId = UUID.randomUUID();
        this.timestamp = Instant.now();
        this.messageType = this.getClass().getSimpleName();
    }
}
