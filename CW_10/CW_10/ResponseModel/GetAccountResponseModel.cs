using CW_10.Models;

namespace CW_10.ResponseModel;

public class GetAccountResponseModel
{
    public string firstName { get; set; }
    
    public string lastName { get; set; }
    
    public string email { get; set; }
    
    public string phone { get; set; }
    
    public string role { get; set; }
    
    public List<GetShoppingCartResponseModel> cart { get; set; }
    
}