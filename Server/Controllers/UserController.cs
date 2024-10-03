using Microsoft.AspNetCore.Mvc;
using Data.Models;
using Data;
using System.Collections.Generic;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<UserModel>> GetUsers()
        {
            return Ok(_context.Users.ToList());
        }

        [HttpPost]
        public ActionResult AddUser(UserModel user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }
    }
}
