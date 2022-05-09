using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashingAPI.Managers;
using WashingAPI.Models;

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
        public Dictionary<string,string> Get()
        {
            return _manager.GetAllTokens();
        }

        [HttpGet("requests")]
        public ActionResult<Dictionary<string, LoginOprettelsesRequest>> GetRequests()
        {
            Dictionary<string, LoginOprettelsesRequest> requests = _manager.GetAllRequests();
            if (requests == null) return StatusCode(404);
            return Ok(requests);
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

        [HttpPost("{id}/opretRequest")]
        public ActionResult<bool> Post(string id, string fornavn, string efternavn, string lejlighedsnummer)
        {
            bool oprettet = _manager.CreateSignupRequest(id, fornavn, efternavn, lejlighedsnummer);
            if (!oprettet) return StatusCode(418);
            return Ok(oprettet);
        }

        // POST api/<LoginController>
        [HttpPost("{id}/opretToken")]
        public bool Post(string id, string lejlighedNummer)
        {
            return _manager.CreateToken(id, lejlighedNummer);
        }

        // PUT api/<LoginController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<LoginController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
