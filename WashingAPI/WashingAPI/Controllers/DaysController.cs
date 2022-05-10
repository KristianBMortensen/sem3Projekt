﻿using Microsoft.AspNetCore.Mvc;
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
    public class DaysController : ControllerBase
    {
        private readonly DaysManager manager = new();
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Day> Get()
        {
            return manager.GetAllDays();
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

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpPost("{date}/book")]
        public void BookTime(string date, string time, string room)
        {
            manager.BookTime(date, time, room);
        }
    }
}
