using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CW_10.Models;

[Table("Products_Categories")]
[PrimaryKey("ProductId", "CategoryId")]
public class ProductCategory
{
    [ForeignKey("Product")]
    [Column("FK_protuct")]
    public int ProductId { get; set; }
    
    public Product Product { get; set; }
    
    [ForeignKey("Category")]
    [Column("FK_category")]
    public int CategoryId { get; set; }
    
    public Category Category { get; set; }
}