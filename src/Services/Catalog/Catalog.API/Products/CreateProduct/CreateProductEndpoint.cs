﻿using Catalog.API.DTOs;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductRequest(ProductDTO ProductDTO);
    public record CreateProductResponse(Guid Id);
    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("products", async (CreateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateProductComand>();
                
                var result = await sender.Send(command);

                var response = result.Adapt<CreateProductResponse>();

                return Results.Created($"/products/{response.Id}", response);
            }).WithName("CreateProduct")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Product")
            .WithDescription("Create Product");
        }
    }
}
