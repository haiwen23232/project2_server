using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using EFGetStarted.AspNetCore.NewDb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : DbConnection 
    {
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return Context.Users.ToList();
        }

        [HttpGet("{userId}")]
        public User GetUserById(string userId)
        {
            return Context.Users.SingleOrDefault(c => c.UserId == Int32.Parse(userId));
        }

        [HttpGet("GetByEmail/{email}")]
        public bool CheckEmail(string email)
        {
            User user = Context.Users.FirstOrDefault(c => c.Email == email.ToLower());
            if (user == null)
                return true;
            else
                return false;
        }

        [HttpGet("GetByName/{name}")]
        public User GetByName(string name)
        {
           return Context.Users.FirstOrDefault(c => c.Name == name);
        }
        
        [HttpPost]
        public void CreateUser([FromBody]User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
        }

        [HttpPut("{userId}")]
        public void UpdateUser(int userId, [FromBody]User user)
        {
            var userInDb = Context.Users.SingleOrDefault(u => u.UserId == userId);
            if (userInDb != null)
                userInDb.Password = user.Password;
            Context.SaveChanges();
        }
    }
}
