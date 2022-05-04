using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashingAPI.Models;

namespace WashingAPI.Managers
{
    public class Manager
    {
        private List<Day> days = new List<Day>()
        {
            new Day(){Date="04-05-2022"},
            new Day(){Date="05-05-2022"},
            new Day(){Date="06-05-2022"},
            new Day(){Date="07-05-2022"},
        };

        public List<Day> GetAllDays()
        {
            return new(days);
        }


    }
}
