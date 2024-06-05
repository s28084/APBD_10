/*using CW_10.Contexts;
using CW_10.Exceptions;
using CW_10.ResponseModel;
using Microsoft.EntityFrameworkCore;

namespace CW_10.Services;

public interface IShoppingCartService
{
    Task<GetShoppingCartResponseModel> GetShoppingCartByIdAsync(int id, CancellationToken cancellationToken);
}

public class ShoppingCartService(DatabaseContext context) : IShoppingCartService
{
    public async Task<GetShoppingCartResponseModel> GetShoppingCartByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await context.ShoppingCarts
            .Where(sc => sc.AccountId == id)
            .Select(e => new GetShoppingCartResponseModel
            {
                productId = e.ProductId
            }
    }
}*/