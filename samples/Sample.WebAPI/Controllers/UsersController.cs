using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Sample.WebAPI.Entities;
using WoodenMoose.AspNetCore.SwaggerGen;

namespace Sample.WebAPI.Controllers
{
    [Route("users")]
    public class UsersController : Controller
    {
        [HttpGet]
        [SwaggerOperationName("GetUsers")]
        public IEnumerable<User> Get()
        {
            return new List<User>();
        }

        [HttpGet("{id}")]
        [SwaggerOperationName("GetUserById")]
        public User Get(int id)
        {
            return new User();
        }

        [HttpPost]
        [SwaggerOperationName("CreateUser"), SwaggerConsumes("application/json")]
        public int CreateUser([FromBody] User user)
        {
            return 0;
        }

        [HttpDelete]
        [SwaggerOperationName("DeleteUser")]
        public bool DeleteUser(int id)
        {
            return false;
        }

        [HttpGet("~/applications/{id}/users")]
        [SwaggerGroup("Applications"), SwaggerOperationName("GetUsersForApplication")]
        public IEnumerable<User> GetUsersForApplication(int id)
        {
            return new List<User>();
        }
    }
}
