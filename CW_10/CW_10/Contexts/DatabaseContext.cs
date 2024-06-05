using CW_10.Models;
using Microsoft.EntityFrameworkCore;

namespace CW_10.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<Role> Roles { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<Category> Categories { get; set; }
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Role>().HasData(new List<Role>
        {
            new Role
            {
                RoleId = 1,
                RoleName = "User"
            }
        });
        
        modelBuilder.Entity<Account>().HasData(new List<Account>
        {
            new Account
            {
                AccountId = 1,
                AccountFirstName = "Jan",
                AccountLastName = "Kowalski",
                AccountEmail = "j@k.com",
                AccountPhoneNumber = "999888777",
                RoleId = 1,
            }
        });
        
        modelBuilder.Entity<Product>().HasData(new List<Product>
        {
            new Product
            {
                ProductId = 1,
                ProductName = "ściągi na egzamin z APBD",
                ProductWeight = 0.1,
                ProductWidth = 10,
                ProductHeight = 10,
                ProductDepth = 0.1
            }
        });
        
        modelBuilder.Entity<ShoppingCart>().HasData(new List<ShoppingCart>
        {
            new ShoppingCart
            {
                ProductId = 1,
                AccountId = 1,
                ShoppingCartAmount = 10
            }
        });
        
        modelBuilder.Entity<Category>().HasData(new List<Category>
        {
            new Category
            {
                CategoryId = 1,
                CategoryName = "pierwsza"
            },
            
            new Category
            {
                CategoryId = 2,
                CategoryName = "druga"
            },
            
            new Category
            {
                CategoryId = 3,
                CategoryName = "trzecia"
            }
            
        });
        
    }
}