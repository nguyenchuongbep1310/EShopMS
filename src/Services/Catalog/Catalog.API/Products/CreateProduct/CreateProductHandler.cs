using BuildingBlocks.CQRS;
using Catalog.API.DTOs;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductComand(ProductDTO ProductDTO) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
internal class CreateProductCommandHandler : ICommandHandler<CreateProductComand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductComand comand, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = comand.ProductDTO.Name,
            Category = comand.ProductDTO.Category,
            Description = comand.ProductDTO.Description,
            ImageFile = comand.ProductDTO.ImageFile,
        };

        return new CreateProductResult(Guid.NewGuid());
    }
}

