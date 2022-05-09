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
    public class LoginRequestController : ControllerBase
    {
        private readonly LoginRequestManager _manager;

        public LoginRequestController()
        {
            _manager = new();
        }
            // GET: api/<LoginRequestController>
            [HttpGet("requests")]
        public ActionResult<Dictionary<string, LoginOprettelsesRequest>> Get()
        {
            Dictionary<string, LoginOprettelsesRequest> requests = _manager.GetAllRequests();
            if (requests == null) return StatusCode(404);
            return Ok(requests);
        }

        [HttpPost("{id}/opretRequest")]
        public ActionResult<int> Post(string id, string fornavn, string efternavn, string lejlighedsnummer)
        {
            int oprettet = _manager.CreateSignupRequest(id, fornavn, efternavn, lejlighedsnummer);
            if (oprettet == 0) return StatusCode(418);
            return Ok(oprettet);
        }

    }
}
