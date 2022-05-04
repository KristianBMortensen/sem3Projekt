using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WashingAPI.Models
{
    public class Day
    {
        public string Date { get; set; }

        public Dictionary<string, string> Timeslots = new Dictionary<string, string>()
        {
            {"7:30-9:00", null },
            {"9:00-10:30", null },
            {"10:30-12:00", null },
            {"12:00-13:30", null },
            {"13:30-15:00", null },
            {"15:00-16:30", null },
            {"16:30-18:00", null },
            {"18:00-19:30", null },
            {"19:30-21:00", null },
        }
            

    }
}
