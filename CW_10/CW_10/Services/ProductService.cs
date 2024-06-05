using CW_10.Contexts;
using CW_10.Models;
using CW_10.ResponseModel;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CW_10.Services;

public interface IProductService
{
    Task<PostProductResponseModel> PostProductAsync(PostProductResponseModel model, CancellationToken cancellationToken);
}

public class ProductService(DatabaseContext context) : IProductService
{
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

        context.Products.Add(product);
        await context.SaveChangesAsync(cancellationToken);

        foreach (var productCategory in model.productCategories.Select(categoryId => new ProductCategory
                 {
                     ProductId = product.ProductId,
                     CategoryId = categoryId
                 }))
        {
            context.ProductsCategories.Add(productCategory);
        }

        await context.SaveChangesAsync(cancellationToken);
        
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