﻿using System.Threading.Tasks;
using NovinCommerce.Entities.Products;
using NovinCommerce.Exceptions;
using NovinCommerce.Repositories.Products;
using Volo.Abp.Domain.Services;

namespace NovinCommerce.Services;

public class ProductManagerService : DomainService
{
    private readonly IProductRepository _productRepository;

    public ProductManagerService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> CreateAsync(Product inputProduct)
    {
        var products = await _productRepository.GetByCategoryTypeAsync(inputProduct.Category.Name);

        if (await _productRepository.GetByNameAsync(products, inputProduct.Name) is not null)
        {
            throw new ProductAlreadyExistException(inputProduct.Name);
        }

        Product product = new(inputProduct.Name,
            inputProduct.Description,
            inputProduct.Price,
            inputProduct.Quantity,
            inputProduct.StockState,
            inputProduct.Category,
            inputProduct.Company);

        return product;
    }
}