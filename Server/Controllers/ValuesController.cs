using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ValuesController : ControllerBase
    {
        private ConfigurationDbContext _context;
        public ValuesController(ConfigurationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [Authorize(Roles ="admin")]
        [HttpPost]
        public IActionResult Post([FromBody] IdentityServer4.EntityFramework.Entities.Client client)
        {
            var res = _context.Clients.Add(client);
            if(_context.SaveChanges() >0)
                return Ok(true);
            else
                return Ok(false);
        }

      
    }
}
