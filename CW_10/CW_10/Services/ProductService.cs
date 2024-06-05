using CW_10.Contexts;
using CW_10.Models;
using CW_10.ResponseModel;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CW_10.Services;

public interface IProductService
{
    Task<PostProductResponseModel> PostProductAsync(PostProductResponseModel model, CancellationToken cancellationToken);
}

public class ProductService : IProductService
{
    private readonly DatabaseContext _context;

    public ProductService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<PostProductResponseModel> PostProductAsync(PostProductResponseModel model, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            ProductName = model.productName,
            ProductWeight = model.productWeight,
            ProductWidth = model.productWidht,
            ProductHeight = model.productHeight,
            ProductDepth = model.productDepth
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);

        foreach (var categoryId in model.productCategories)
        {
            var productCategory = new ProductCategory
            {
                ProductId = product.ProductId,
                CategoryId = categoryId
            };

            _context.ProductsCategories.Add(productCategory);
        }

        await _context.SaveChangesAsync(cancellationToken);

        // Create and return a response model
        return new PostProductResponseModel
        {
            productName = product.ProductName,
            productWeight = product.ProductWeight,
            productWidht = product.ProductWidth,
            productHeight = product.ProductHeight,
            productDepth = product.ProductDepth,
            productCategories = model.productCategories
        };
    }
}