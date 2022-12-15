package com.mcbmentorias.shopdemo.domain.entities.base.valueobjects;

import lombok.Getter;
import lombok.NoArgsConstructor;

import javax.persistence.Embeddable;
import java.time.Instant;

@Getter
@Embeddable
@NoArgsConstructor
public class AuditInfoVO {

    private Instant createdAt;

    private String createdBy;

    private Instant updatedAt;

    private String updatedBy;

    private String lastPlatformUpdated;

    public AuditInfoVO(
            final String createdBy,
            final String lastPlatformUpdated
    ) {
        this.createdAt = Instant.now();
        this.createdBy = createdBy;
        this.lastPlatformUpdated = lastPlatformUpdated;
    }

    public AuditInfoVO(
            final String createdBy,
            final String lastPlatformUpdated,
            final Instant createdAt
    ) {
        this(createdBy, lastPlatformUpdated);
        this.createdAt = createdAt;
    }

    public AuditInfoVO(
            final String createdBy,
            final String lastPlatformUpdated,
            final Instant createdAt,
            final String updatedBy
    ) {
        this(createdBy, lastPlatformUpdated, createdAt);
        this.updatedAt = Instant.now();
        this.updatedBy = updatedBy;
    }

    public AuditInfoVO(
        final String createdBy,
        final String lastPlatformUpdated,
        final Instant createdAt,
        final String updatedBy,
        final Instant updatedAt
    ) {
        this(
            createdBy,
            lastPlatformUpdated,
            createdAt,
            updatedBy
        );

        this.updatedAt = updatedAt;
    }
}
