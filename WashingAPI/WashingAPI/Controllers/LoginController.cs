using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashingAPI.DBModels;
using WashingAPI.Managers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WashingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginManager _manager;

        public LoginController()
        {
            _manager = new();
        }

        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<Login> Get()
        {
            return _manager.GetAllTokens();
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(string id)
        {
            string token = _manager.GetToken(id);
            if (token == null)
                return StatusCode(204);
            return Ok(token);
        }

        // POST api/<LoginController>
        [HttpPost]
        public bool Post(Login login)
        {
            return _manager.CreateToken(login);
        }

        // PUT api/<LoginController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            bool success = _manager.DeleteLogin(id);
            if (!success) return StatusCode(500);
            return Ok();
        }
    }
}
