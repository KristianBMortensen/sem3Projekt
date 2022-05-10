using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashingAPI.DBModels;
using WashingAPI.Managers;
using WashingAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WashingAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginRequestController : ControllerBase
    {
        private readonly LoginRequestManager _manager;

        public LoginRequestController()
        {
            _manager = new();
        }

        // GET: api/<LoginRequestController>
        [HttpGet]

    public ActionResult<IEnumerable<LoginRequest>> Get()
        {
            IEnumerable<LoginRequest> requests = _manager.GetAllRequests();
            if (requests == null) return StatusCode(404);
            return Ok(requests);
        }

        [HttpGet("{id}")]
        public ActionResult<LoginRequest> GetRequest(string id)
        {
            LoginRequest pair = _manager.GetRequest(id);
            if (pair == null) return NotFound();
            return Ok(pair);
        }

        //Opretter request for at få et login for denne google konto og lejlighedsnummer
        [HttpPost]
        public ActionResult<bool> Post([FromBody] LoginRequest login)
        {
            bool oprettet = _manager.CreateSignupRequest(login);
            if (!oprettet) return StatusCode(418);
            return Ok(oprettet);
        }

        //Login anmodning accepteret
        //Opretter et login for denne google account
        [HttpPut("{id}")]
        public ActionResult<bool> Put(string id)
        {
            if (!_manager.CreateLogin(id)) return StatusCode(500,"Kunne ikke oprette login");
            return Ok(true);
        }

        //Sletter login anmodning fra systemet
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(string id)
        {
            if (!_manager.DeleteRequest(id)) return StatusCode(500);
            return Ok(true);
        }

    }
}
