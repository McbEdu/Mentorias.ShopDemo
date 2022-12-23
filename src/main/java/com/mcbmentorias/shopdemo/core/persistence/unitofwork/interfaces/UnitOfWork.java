package com.mcbmentorias.shopdemo.core.persistence.unitofwork.interfaces;

import org.springframework.stereotype.Component;
import org.springframework.transaction.PlatformTransactionManager;
import org.springframework.transaction.TransactionStatus;
import org.springframework.transaction.support.DefaultTransactionDefinition;
import org.springframework.web.context.annotation.RequestScope;

import java.util.Objects;

@Component
@RequestScope
public class UnitOfWork implements IUnitOfWork {

    private final PlatformTransactionManager transactionManager;
    private TransactionStatus transaction;

    public UnitOfWork(
            final PlatformTransactionManager transactionManager
    ) {
        this.transactionManager = transactionManager;
        this.transaction = null;
    }

    @Override
    public void begin() {
        if(this.isTransactionActive()) throw new RuntimeException("Transaction is already active");

        final var transaction = new DefaultTransactionDefinition();
        this.transaction = this.transactionManager.getTransaction(transaction);
    }

    private Boolean isTransactionActive() {
        return !Objects.isNull(this.transaction);
    }

    @Override
    public void commit() {
        if(!this.isTransactionActive()) throw new RuntimeException("Transaction is not active.");
        this.transactionManager.commit(this.transaction);
    }

    @Override
    public void rollback() {
        if(!this.isTransactionActive()) throw new RuntimeException("Transaction is not active.");
        this.transactionManager.rollback(this.transaction);
    }
}
