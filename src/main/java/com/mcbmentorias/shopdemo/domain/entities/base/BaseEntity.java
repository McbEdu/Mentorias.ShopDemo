package com.mcbmentorias.shopdemo.domain.entities.base;

import com.mcbmentorias.shopdemo.core.patterns.validator.models.ValidationMessage;
import com.mcbmentorias.shopdemo.core.patterns.validator.models.ValidationResult;
import com.mcbmentorias.shopdemo.domain.entities.base.valueobjects.AuditInfoVO;
import lombok.Getter;
import org.apache.logging.log4j.util.Supplier;

import javax.persistence.Id;
import javax.persistence.MappedSuperclass;
import javax.persistence.Transient;
import javax.persistence.Version;
import java.util.Collection;
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

    @Transient
    private ValidationResult validationResult;

    public BaseEntity() {
        this.validationResult = new ValidationResult();
    }

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

    public Boolean validate(final Supplier<ValidationResult> func) {
        this.validationResult = func.get();
        return this.validationResult.isValid();
    }

    public Boolean isValid() {
        return this.validationResult.isValid();
    }

    public Collection<ValidationMessage> getErrors() {
        return this.validationResult.getMessages();
    }
}
