using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Sample.WebAPI.Entities;
using WoodenMoose.AspNetCore.SwaggerGen;

namespace Sample.WebAPI.Controllers
{
    [Route("applications")]
    public class ApplicationsController : Controller
    {
        [HttpGet]
        [SwaggerOperationName("GetApplications")]
        public IEnumerable<Application> Get()
        {
            return new List<Application>();
        }

        [HttpGet("{id}")]
        [SwaggerOperationName("GetApplicationById")]
        public User Get(int id)
        {
            return new User();
        }

        [HttpPost]
        [SwaggerOperationName("CreateApplication"), SwaggerConsumes("application/json")]
        public int CreateApplication([FromBody] Application application)
        {
            return 0;
        }

        [HttpDelete]
        [SwaggerOperationName("DeleteApplication")]
        public bool DeleteApplication(int id)
        {
            return false;
        }

        [HttpPost("~/users/{id}/applications")]
        [SwaggerGroup("Users"), SwaggerOperationName("AddApplicationToUser")]
        public IEnumerable<User> AddApplicationToUser(int id)
        {
            return new List<User>();
        }

        [HttpDelete("~/users/{idUser}/application/{idApplication}")]
        [SwaggerGroup("Users"), SwaggerOperationName("AddApplicationToUser")]
        public bool RemoveApplicationFromUser(int idUser, int idApplication)
        {
            return false;
        }
    }
}
