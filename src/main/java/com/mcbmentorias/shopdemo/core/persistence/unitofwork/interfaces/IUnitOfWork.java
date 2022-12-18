package com.mcbmentorias.shopdemo.core.persistence.unitofwork.interfaces;

public interface IUnitOfWork {
    void begin();
    void commit();
    void rollback();
}
