using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController:DbConnection
    {
        [HttpGet]
        public List<Category> GetAll()
        {
            return Context.Categories.ToList();
        }

    }
}
