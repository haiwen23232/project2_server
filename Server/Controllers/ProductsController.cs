using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : DbConnection 
    {
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            List<Product> products = Context.Products.ToList();
            for (int i = 0; i < products.Count; i++)
                products[i].Category = Context.Categories.SingleOrDefault(c => c.CategoryId == products[i].CategoryId);
            return products;
        }

        [HttpGet("{id}")]
        public Product GetById(string id)
        {
            Product product = Context.Products.SingleOrDefault(p => p.ProductId == Int32.Parse(id));
            product.Category = Context.Categories.SingleOrDefault(c => c.CategoryId == product.CategoryId);
            return product;
        }

        [HttpGet("category/{catId}")]
        public IEnumerable<Product> GetProductByCategory(string catId)
        {
            List<Product> list;
            if (Int32.Parse(catId) == 1)
            {
                list = Context.Products.ToList();
                for (int i = 0; i < list.Count; i++)
                    list[i].Category = Context.Categories.SingleOrDefault(c => c.CategoryId == list[i].CategoryId);
            }
            else
            {
                list = Context.Products.Where(p => p.CategoryId == Int32.Parse(catId)).ToList();
                for (int i = 0; i < list.Count; i++)
                    list[i].Category = Context.Categories.SingleOrDefault(c => c.CategoryId == list[i].CategoryId);
            }

            return list;
        }

        [HttpGet("search/{keyword}")]
        public IEnumerable<Product> GetProductsByKeyword(string keyword)
        {
            List<Product> list = Context.Products.Where(p => p.Name.ToLower().Contains(keyword)).ToList();
            for (int i = 0; i < list.Count; i++)
                list[i].Category = Context.Categories.SingleOrDefault(c => c.CategoryId == list[i].CategoryId);
            return list;
        }

    }
}
