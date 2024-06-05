using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CW_10.Models;

[Table("Accounts")]
public class Account
{
    [Key]
    [Column("PK_account")]
    public int AccountId { get; set; }
    
    [Column("first_name")]
    [MaxLength(50)]
    public string AccountFirstName { get; set; }
    
    [Column("last_name")]
    [MaxLength(50)]
    public string AccountLastName { get; set; }
    
    [Column("email")]
    [MaxLength(80)]
    [EmailAddress]
    public string AccountEmail { get; set; }
    
    [Column("phone")]
    [MaxLength(9)]
    [Phone]
    public string? AccountPhoneNumber { get; set; }
    
    [ForeignKey("Role")]
    [Column("FK_role")]
    public int RoleId { get; set; }
    
    public Role Role { get; set; }
    
    public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }
    
    
}