using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFGetStarted.AspNetCore.NewDb.Models;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers
{
    public class DbConnection
    {
        static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EFGetStarted.AspNetCore.NewDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public ShopContext Context = new ShopContext(new DbContextOptionsBuilder<ShopContext>().UseSqlServer(connectionString).Options);


    }
}
