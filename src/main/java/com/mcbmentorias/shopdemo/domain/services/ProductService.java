package com.mcbmentorias.shopdemo.domain.services;

import com.mcbmentorias.shopdemo.core.patterns.notification.interfaces.INotificationPublisher;
import com.mcbmentorias.shopdemo.core.patterns.notification.models.Notification;
import com.mcbmentorias.shopdemo.core.patterns.validator.enums.ValidationTypeMessage;
import com.mcbmentorias.shopdemo.domain.entities.product.Product;
import com.mcbmentorias.shopdemo.domain.entities.product.factories.ProductFactory;
import com.mcbmentorias.shopdemo.domain.entities.product.inputs.CreateNewImportProductInput;
import com.mcbmentorias.shopdemo.domain.repositories.IProductRepository;
import com.mcbmentorias.shopdemo.domain.services.base.BaseService;
import com.mcbmentorias.shopdemo.domain.services.interfaces.IProductService;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import java.util.Objects;
import java.util.stream.Collectors;

@Service
public class ProductService extends BaseService implements IProductService {

    private final IProductRepository repository;
    private final ProductFactory productFactory;

    public ProductService(
            final INotificationPublisher notificationPublisher,
            final IProductRepository repository,
            final ProductFactory productFactory
    ) {
        super(notificationPublisher);
        this.repository = repository;
        this.productFactory = productFactory;
    }

    @Override
    public Boolean importProduct(final CreateNewImportProductInput input) {
        if(this.repository.checkIfProductExists(input.getCode())) {
            this.notificationPublisher.publisherNotification(
                    new Notification(
                            "code",
                            "11",
                            "product already exists",
                            input.getCode(),
                            ValidationTypeMessage.Error.name()
                    )
            );

            return Boolean.FALSE;
        }

        final var product = this.productFactory.create();
        product.importProduct(input);

        if(!this.validateDomainEntityAndNotification(product)) {
            return Boolean.FALSE;
        }

        this.repository.save(product);

        return Boolean.TRUE;
    }

    @Override
    public Boolean createImportProductOrNotifyDifferences(final CreateNewImportProductInput domainInput) {
        final var product = this.getByCode(domainInput.getCode());
        if(Objects.isNull(product)) {
            return this.importProduct(domainInput);
        }

        if( !Objects.equals(product.getDescription(), domainInput.getDescription())) {
            this.notificationPublisher.publisherNotification(
                    new Notification(
                            "product",
                            "16",
                            "Product with code ".concat(product.getCode()).concat(" already exists, buts with distinct information"),
                            product.toString(),
                            ValidationTypeMessage.Warning.name()
                    )
            );
        }

        return Boolean.FALSE;
    }

    @Override
    public Product getByCode(final String code) {
        return this.repository.getByCode(code);
    }

    @Override
    public Boolean createImportProductOrNotifyDifferences(final Collection<CreateNewImportProductInput> inputs) {
        final var sortedInputs = this.quickSort(inputs.stream().collect(Collectors.toList()));
        return null;
    }

    private List<CreateNewImportProductInput> quickSort(final List<CreateNewImportProductInput> unsortedCollection) {
        // Check if the list has more than one element
        if (unsortedCollection.size() == 1)  return unsortedCollection;

        // Choose the first element in the list as the pivot
        final var pivot = unsortedCollection.get(0);
        // Create two lists to store the elements before and after the pivot
        List<CreateNewImportProductInput> before = new ArrayList<CreateNewImportProductInput>();
        List<CreateNewImportProductInput> after = new ArrayList<CreateNewImportProductInput>();

        // Loop through the list, starting from the second element
        for (int i = 1; i < unsortedCollection.size(); i++) {
            // If the current element is less than the pivot, add it to the before list
            if (unsortedCollection.get(i).getCode().compareTo(pivot.getCode()) < 0) {
                before.add(unsortedCollection.get(i));
            }
            // Otherwise, add it to the after list
            else {
                after.add(unsortedCollection.get(i));
            }
        }

        // Recursively sort the before list
        before = quickSort(before);
        // Recursively sort the after list
        after = quickSort(after);

        // Clear the list
        unsortedCollection.clear();
        // Add the sorted before list to the list
        unsortedCollection.addAll(before);
        // Add the pivot to the list
        unsortedCollection.add(pivot);
        // Add the sorted after list to the list
        unsortedCollection.addAll(after);

        // Return the sorted list
        return unsortedCollection;
    }
}
