package com.mcbmentorias.shopdemo.domain.entities.base;

import com.mcbmentorias.shopdemo.domain.entities.base.valueobjects.AuditInfoVO;
import lombok.Getter;

import javax.persistence.Id;
import javax.persistence.MappedSuperclass;
import javax.persistence.Version;
import java.util.UUID;

@Getter
@MappedSuperclass
public abstract class BaseEntity {

    private static final String LAST_PLATAFORM_UPDATED = "MCB-MENTORIA-MONOLITO-API";

    @Id
    private UUID id;

    private AuditInfoVO auditInfoVO;

    @Version
    private Long version;

    public BaseEntity createNewEntity(final String createdBy) {
        this.id = UUID.randomUUID();

        this.auditInfoVO = new AuditInfoVO(createdBy, LAST_PLATAFORM_UPDATED);

        this.version = 1L;

        return this;
    }

    protected BaseEntity fillBase(
            final UUID id
    ) {
        this.id = id;

        return this;
    }
}
