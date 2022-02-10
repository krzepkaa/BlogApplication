using BlogApplication.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private BlogDbContext _dbContext;
        public ApiController(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("users")]
        public IActionResult Get()
        {
            try
            {
                var users = _dbContext.ApplicationUsers.ToList();
                if(users.Count == 0)
                {
                    return StatusCode(404, "No user found!");
                }

                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occurred!");
            }
        }
    }
}
