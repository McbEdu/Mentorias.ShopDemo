package com.mcbmentorias.shopdemo.domain.events.product;

import com.mcbmentorias.shopdemo.domain.entities.product.Product;
import com.mcbmentorias.shopdemo.domain.events.interfaces.IDomainEvent;
import com.mcbmentorias.shopdemo.domain.events.models.BaseDomainEvent;
import lombok.Getter;

import java.time.Instant;
import java.util.UUID;

@Getter
public class ProductImported extends BaseDomainEvent implements IDomainEvent {

    private final Product product;

    public ProductImported(
            final UUID id,
            final UUID tenantId,
            final Instant timestamp,
            final String messageType,
            final Product product
    ) {
        super(id, tenantId, timestamp, messageType);
        this.product = product;
    }
}
