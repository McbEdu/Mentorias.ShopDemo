package com.mcbmentorias.shopdemo.infra.data.adapters.intefaces;

import com.mcbmentorias.shopdemo.domain.entities.product.Product;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.UUID;

@Repository
public interface ProductRepositoryJPA extends JpaRepository<Product, UUID> {
    Boolean existsByCode(final String productCode);
}
