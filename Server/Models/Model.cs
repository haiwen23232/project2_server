using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Server.Models;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }

}