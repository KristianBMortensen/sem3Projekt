using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashingAPI.Managers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WashingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreenDaysController : ControllerBase
    {
        private readonly GreenDaysManager _manager;

        public GreenDaysController()
        {
            _manager = new();
        }

        // GET: api/<GreenDaysController>
        [HttpGet]
        public bool Get()
        {
            return _manager.GetAction();
        }

        // POST api/<GreenDaysController>
        [HttpPost]
        public void Post()
        {
            _manager.UpdateLastAction();
        }
    }
}
