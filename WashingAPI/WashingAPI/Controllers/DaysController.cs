using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashingAPI.Managers;
using WashingAPI.DBModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WashingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaysController : ControllerBase
    {
        private readonly DaysManager manager = new();
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Day> Getdays([FromQuery]string room)
        {
            return manager.GetAllDays(room);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{date}")]
        public Day Get(string date)
        {
            return manager.GetDay(date);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string date)
        {
            manager.AddDay(date);
        }

        [HttpPost("{TimeslotID}/book")]
        public void BookTime(int TimeslotID, string loginId)
        {
            manager.BookTime(TimeslotID, loginId);
        }
        [HttpGet("week")]
        public IEnumerable<Day> WeekDays(int numdays = 7)
        {
            return manager.GetWeekDay(numdays);
        }
    }
}
