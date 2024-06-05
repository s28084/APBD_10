namespace CW_10.ResponseModel;

public class PostProductResponseModel
{
    public string productName { set; get; }
    
    public double productWeight { set; get; }
    
    public double productWidht { set; get; }
    
    public double productHeight { set; get; }
    
    public double productDepth { set; get; }
    
    public List<int> productCategories { get; set; }
}