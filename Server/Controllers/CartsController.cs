using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class CartsController : DbConnection
    {
        [HttpGet]
        public List<Cart> GetAll()
        {
            List<Cart> carts = Context.Carts.ToList();
            for (int i = 0; i < carts.Count; i++)
            {
                carts[i].User = Context.Users.SingleOrDefault(u => u.UserId == carts[i].UserId);
                carts[i].Product = Context.Products.SingleOrDefault(p => p.ProductId == carts[i].ProductId);
                carts[i].Product.Category =
                    Context.Categories.SingleOrDefault(c => c.CategoryId == carts[i].Product.CategoryId);
            }
            return carts;
        }

        [HttpGet("GetByUser/{userID}")]
        public List<Cart> GetByUser(string userId)
        {
            List<Cart> carts = Context.Carts.Where(c => c.UserId == Int32.Parse(userId)).ToList();
            for (int i = 0; i < carts.Count; i++)
            {
                carts[i].User = Context.Users.SingleOrDefault(u => u.UserId == carts[i].UserId);
                carts[i].Product = Context.Products.SingleOrDefault(p => p.ProductId == carts[i].ProductId);
                carts[i].Product.Category =
                    Context.Categories.SingleOrDefault(c => c.CategoryId == carts[i].Product.CategoryId);
            }
            return carts;
        }

        [HttpGet("GetUserTotal/{userID}")]
        public double GetUserTotal(string userId)
        {
            double total = 0;
            List<Cart> carts = Context.Carts.Where(c => c.UserId == Int32.Parse(userId)).ToList();
            for (int i = 0; i < carts.Count; i++)
            {
                double price = Context.Products.SingleOrDefault(p => p.ProductId == carts[i].ProductId).Price;
                int quantity = carts[i].Quantity;
                total += (price * quantity);
            }
            return total;
        }

        [HttpPost]
        public Cart CreateCart([FromBody] Cart cart)
        {
            Context.Carts.Add(cart);
            Context.SaveChanges();
            return cart;
        }

    }
}
