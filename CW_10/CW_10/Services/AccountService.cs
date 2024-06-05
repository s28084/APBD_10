using CW_10.Contexts;
using CW_10.Exceptions;
using CW_10.ResponseModel;
using Microsoft.EntityFrameworkCore;

namespace CW_10.Services;

public interface IAccountService
{
    Task<GetAccountResponseModel> GetAccountByIdAsync(int id, CancellationToken cancellationToken);
}

public class AccountService(DatabaseContext context) : IAccountService
{
    public async Task<GetAccountResponseModel> GetAccountByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await context.Accounts
            .Where(a => a.AccountId == id)
            .Select(e => new GetAccountResponseModel
            {
                firstName = e.AccountFirstName,
                lastName = e.AccountLastName,
                email = e.AccountEmail,
                phone = e.AccountPhoneNumber,
                role = e.Role.RoleName
                //cart = e.ShoppingCarts.Where(sc => sc.AccountId == id).Select(sc => new Get)
                //Dodać polecenie dla ShoppingCart
            }).FirstOrDefaultAsync(cancellationToken);
        if (result is null)
        {
            throw new NotFoundException($"Account with id: {id} does not exist");
        }

        return result;

    }
}