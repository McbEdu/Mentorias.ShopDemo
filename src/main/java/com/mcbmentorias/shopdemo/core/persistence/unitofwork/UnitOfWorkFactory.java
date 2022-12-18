package com.mcbmentorias.shopdemo.core.persistence.unitofwork;

import com.mcbmentorias.shopdemo.core.patterns.factory.BaseFactory;
import com.mcbmentorias.shopdemo.core.persistence.unitofwork.interfaces.IUnitOfWork;
import org.springframework.beans.factory.config.ConfigurableBeanFactory;
import org.springframework.context.ApplicationContext;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

@Component
@Scope(ConfigurableBeanFactory.SCOPE_SINGLETON)
public class UnitOfWorkFactory extends BaseFactory<IUnitOfWork> {

    private final ApplicationContext dependencyContainer;

    public UnitOfWorkFactory(final ApplicationContext dependencyContainer) {
        this.dependencyContainer = dependencyContainer;
    }


    @Override
    public IUnitOfWork create() {
        return this.dependencyContainer.getBean(IUnitOfWork.class);
    }
}
